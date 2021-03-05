using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class DorsalDevice {
    // Hacky - for callback. Fix later.
    public DSU.DSUDevice callbackDSUDevice;

    // For internal representation of controller
    Vector3[] pos;
    double[] velX;
    double[] velY;
    double[] velZ;
    Vector3[] accel;
    Quaternion[] gyro;
    Vector3[] gyroRate;
    Vector3[] dGravity;
    double[] timestamp;
    double minTimeDiff = 0.1; // s
    private int samples = 50;
    private int samplesTaken = 0;
    Quaternion relativeRotation = Quaternion.identity;
    Vector3 dRight;
    Vector3 dUp;
    Vector3 dForward;

    // For other classes to read from this device
    DeviceType deviceType = DeviceType.Undefined;
    public Vector3 gyroscopeRate = new Vector3();
    public Vector3 accelerometer = new Vector3();
    public Int64 lastTimestamp = 0;
    public bool primaryButton = false;
    public bool secondaryButton = false;
    public bool gripButton = false;
    public float grip = 0f;
    public bool triggerButton = false;
    public float trigger = 0f;
    public Vector2 primary2DAxis = new Vector2();
    public bool primary2DAxisClick = false;
    public Quaternion deviceRotation = new Quaternion();
    public Vector3 devicePosition = new Vector3();

    // For getting data from physical controller
    InputAction poseAction;
    InputAction positionAction;
    InputAction rotationAction;
    UnityEngine.XR.InputDevice inputDevice;

    // For screen position, to calculate pointer
    Vector3 screenCentre;
    Vector3 screenNormal;
    float screenWidth;  // m
    float screenHeight; // m

    public enum DeviceType {
        Undefined = 0,
        HMD = 1,
        LeftHand = 2,
        RightHand = 3
    }

    public DorsalDevice(DeviceType _deviceType) {
        pos = new Vector3[samples];  // metres
        velX = new double[samples];  // m/s
        velY = new double[samples];
        velZ = new double[samples];
        accel = new Vector3[samples];  // g
        gyro = new Quaternion[samples];  // deg
        gyroRate = new Vector3[samples];  // deg/s
        dGravity = new Vector3[samples];  // g
        timestamp = new double[samples];  // seconds

        screenCentre = GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().position;
        screenNormal = -GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().forward;
        // Multiply by ten because the assets have a scale factor of 0.1
        screenWidth = GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().localScale.x * 10f;
        screenHeight = GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().localScale.y * 10f;

        SetDeviceType(_deviceType);
    }

    public void SetRelativeRotation(Quaternion _relativeRotation) {
        relativeRotation = _relativeRotation;
    }

    public void SetDeviceType(DeviceType _deviceType) {
        deviceType = _deviceType;
        RegisterDevices();
        UnityEngine.XR.InputDevices.deviceConnected += OnDeviceConnected;
    }

    private void OnDeviceConnected(UnityEngine.XR.InputDevice device) {
        RegisterDevices();
    }

    private void RegisterDevices() {
        // For now, we keep this simple:
        // We look at all connected devices and add as "the" inputDevice if the type matches the `device` field selected.
        // We don't do anything with ambidextrous controllers or if, say, the user has two HMDs connected.
        // Nor do we do anything if a controller is disconnected.
        List<UnityEngine.XR.InputDevice> allInputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(allInputDevices);
        List<XRNodeState> allNodeStates = new List<XRNodeState>();
        UnityEngine.XR.InputTracking.GetNodeStates(allNodeStates);

        for (int i = 0; i < allInputDevices.Count; i++) {
            if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.HeadMounted) == UnityEngine.XR.InputDeviceCharacteristics.HeadMounted) {
                if (deviceType == DeviceType.HMD) {
                    inputDevice = allInputDevices[i];

                    positionAction = new InputAction();
                    positionAction.AddBinding(new InputBinding("<XRHMD>/centerEyePosition"));
                    positionAction.performed += OnPositionAction;
                    positionAction.Enable();
                    rotationAction = new InputAction();
                    rotationAction.AddBinding(new InputBinding("<XRHMD>/centerEyeRotation"));
                    rotationAction.performed += OnRotationAction;
                    rotationAction.Enable();
                }
            } else if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.HeldInHand) == UnityEngine.XR.InputDeviceCharacteristics.HeldInHand) {
                if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.Left) == UnityEngine.XR.InputDeviceCharacteristics.Left) {
                    if (deviceType == DeviceType.LeftHand) {
                        inputDevice = allInputDevices[i];

                        poseAction = new InputAction();
                        poseAction.AddBinding("<XRController>{LeftHand}/devicePose");
                        poseAction.performed += OnPoseAction;
                        poseAction.Enable();
                    }
                } else if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.Right) == UnityEngine.XR.InputDeviceCharacteristics.Right) {
                    if (deviceType == DeviceType.RightHand) {
                        inputDevice = allInputDevices[i];

                        poseAction = new InputAction();
                        poseAction.AddBinding("<XRController>{RightHand}/devicePose");
                        poseAction.performed += OnPoseAction;
                        poseAction.Enable();
                    }
                }
            }
        }
    }

    private void OnRotationAction(InputAction.CallbackContext obj) {
        deviceRotation = relativeRotation * obj.action.ReadValue<Quaternion>();
    }

    private void OnPoseAction(InputAction.CallbackContext obj) {
        UnityEngine.XR.OpenXR.Input.Pose pose = (UnityEngine.XR.OpenXR.Input.Pose)obj.action.ReadValueAsObject();
        deviceRotation = pose.rotation * relativeRotation;
        devicePosition = pose.position;

        if (obj.time > timestamp[0]) {
            UpdateOutputs(pose.position, obj.time);
        }
    }

    private void UpdateOutputs(Vector3 pos, double time) {
        inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion dRot);
        inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity, out Vector3 dRotRate);

        dForward = (dRot * relativeRotation * Vector3.forward);
        dUp = (dRot * relativeRotation * Vector3.up);
        dRight = (dRot * relativeRotation * Vector3.right);

        for (int i = samplesTaken - 1; i >= 1; i--) {
            this.pos[i] = this.pos[i - 1];

            velX[i] = velX[i - 1];
            velY[i] = velY[i - 1];
            velZ[i] = velZ[i - 1];

            accel[i] = accel[i - 1];

            gyro[i] = gyro[i - 1];
            gyroRate[i] = gyroRate[i - 1];
            dGravity[i] = dGravity[i - 1];
            timestamp[i] = timestamp[i - 1];
        }

        if ((float)time - timestamp[0] > 1) {
            timestamp[0] = Time.realtimeSinceStartup;
        } else {
            timestamp[0] = (float)time;
        }

        this.pos[0] = pos;

        // Apply smoothing if samples are too close together
        int j = 1;
        while (timestamp[0] - timestamp[j] <= minTimeDiff & j < samplesTaken) {
            j++;
        }

        if (j > 0) {
            double diffTime = timestamp[0] - timestamp[j];
            // m/s
            velX[0] = (this.pos[0].x - this.pos[j].x) / diffTime;
            velY[0] = (this.pos[0].y - this.pos[j].y) / diffTime;
            velZ[0] = (this.pos[0].z - this.pos[j].z) / diffTime;

            gyroRate[0] = dRotRate * (float)(180f / Math.PI);

            if (samplesTaken >= samples) {
                // Divide by 9.8 to get g since v/dt will be in m/s/s
                accel[0] = new Vector3(
                    (float)((velX[0] - velX[j]) / (9.8f * diffTime)), 
                    (float)((velY[0] - velY[j]) / (9.8f * diffTime)), 
                    (float)((velZ[0] - velZ[j]) / (9.8f * diffTime))
                );
            }
        }

        // We need movement relative to the device's own axes, so use dot products

        dGravity[0] = new Vector3(
            Vector3.Dot(Vector3.up, -dRight),
            Vector3.Dot(Vector3.up, -dUp),
            Vector3.Dot(Vector3.up, dForward)
        );

        Vector3 dAccel = new Vector3(
            Vector3.Dot(accel[0], dRight),
            Vector3.Dot(accel[0], dUp),
            Vector3.Dot(accel[0], -dForward)
        );

        samplesTaken++;

        if (samplesTaken >= samples) {
            samplesTaken = samples;
            // Debug here if needed
        }

        // Don't forget to get pointer location and buttons
        // Also will need to check that gyro rate works OK with this smoothing - may also need to derive that

        if (timestamp[0] - timestamp[j] >= minTimeDiff) {
            lastTimestamp = (Int64)(timestamp[0] * 1000000);
            accelerometer = dAccel + dGravity[0];
            gyroscopeRate = new Vector3(
                gyroRate[0].x,
                gyroRate[0].z,
                -gyroRate[0].y
            );

            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryButton);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out secondaryButton);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripButton);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out grip);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerButton);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out trigger);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis);
            inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out primary2DAxisClick);

            if (callbackDSUDevice != null) {
                callbackDSUDevice.UpdateFromDorsalDevice();
            }
        }
    }

    private void OnPositionAction(InputAction.CallbackContext obj) {
        devicePosition = obj.action.ReadValue<Vector3>();

        UpdateOutputs(obj.action.ReadValue<Vector3>(), obj.time);
    }

    public Vector2 GetScreenPoint() {
        float d = Vector3.Dot(screenCentre - pos[0], screenNormal) / Vector3.Dot(dForward, screenNormal);
        Vector3 intersection = pos[0] + (d * dForward);
        Vector2 nIntersection = new Vector2(
            (intersection.x - screenCentre.x + (screenWidth / 2)) / screenWidth,
            (screenCentre.y - intersection.y + (screenHeight / 2)) / screenHeight
        );
        return nIntersection;
    }
}
