using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;
using System.Runtime.InteropServices;

namespace Dorsal.Devices {
    [StructLayout(LayoutKind.Auto)]
    public struct DorsalIMUState : IInputStateTypeInfo {
        public FourCC format => new FourCC('D', 'I', 'M', 'U');

        [InputControl(name = "devicePosition", layout = "Vector3")]
        public Vector3 devicePosition;
        [InputControl(name = "deviceRotation", layout = "Quaternion")]
        public Quaternion deviceRotation;
        [InputControl(name = "eulerDeviceRotation", layout = "Vector3")]
        public Vector3 eulerDeviceRotation;
        [InputControl(name = "accelerometer", layout = "Vector3")]
        public Vector3 accelerometer;
        [InputControl(name = "gyroscope", layout = "Vector3")]
        public Vector3 gyroscope;
    }

    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    [InputControlLayout(displayName = "Dorsal IMU Device", stateType = typeof(DorsalIMUState))]
    public class IMU : InputDevice, IDevice, IInputUpdateCallbackReceiver {
        private string _id;
        public string ID {
            get => _id;
            set => _id = value;
        }

        public Vector3Control devicePosition { get; private set; }
        public QuaternionControl deviceRotation { get; private set; }
        public Vector3Control eulerDeviceRotation { get; private set; }
        public Vector3Control accelerometer { get; private set; }
        public Vector3Control gyroscope { get; private set; }

        protected override void FinishSetup() {
            base.FinishSetup();

            devicePosition = GetChildControl<Vector3Control>("devicePosition");
            deviceRotation = GetChildControl<QuaternionControl>("deviceRotation");
            eulerDeviceRotation = GetChildControl<Vector3Control>("eulerDeviceRotation");
            accelerometer = GetChildControl<Vector3Control>("accelerometer");
            gyroscope = GetChildControl<Vector3Control>("gyroscope");
        }

        static IMU() {
            InputSystem.RegisterLayout<IMU>();
        }
        public static IMU current { get; private set; }
        public override void MakeCurrent() {
            base.MakeCurrent();
            current = this;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeInPlayer() { }

        [SerializeField]
        private InputAction _positionAction;
        public InputAction positionAction {
            get { return _positionAction; }
            set {
                UnbindPosition();
                _positionAction = value;
                BindActions();
            }
        }
        private bool _positionBound = false;

        private InputAction _rotationAction;
        public InputAction rotationAction {
            get { return _rotationAction; }
            set {
                UnbindRotation();
                _rotationAction = value;
                BindActions();
            }
        }
        private bool _rotationBound = false;

        private Vector3 _positionOffset = Vector3.zero;
        public Vector3 positionOffset {
            get { return _positionOffset; }
            set {
                _positionOffset = value;
            }
        }

        private Quaternion _rotationOffset = Quaternion.identity;
        public Quaternion rotationOffset {
            get { return _rotationOffset; }
            set {
                _rotationOffset = value;
            }
        }

        private void BindActions() {
            BindPosition();
            BindRotation();
        }

        private void BindPosition() {
            if (!_positionBound && _positionAction != null) {
                _positionAction.performed += OnPositionUpdate;
                _positionBound = true;
                _positionAction.Enable();
            }
        }

        private void BindRotation() {
            if (!_rotationBound && _rotationAction != null) {
                _rotationAction.performed += OnRotationUpdate;
                _rotationBound = true;
                _rotationAction.Enable();
            }
        }

        private void UnbindActions() {
            UnbindPosition();
            UnbindRotation();
        }

        private void UnbindPosition() {
            if (_positionBound && _positionAction != null) {
                _positionAction.Disable();
                _positionAction.performed -= OnPositionUpdate;
                _positionBound = false;
            }
        }

        private void UnbindRotation() {
            if (_rotationBound && _rotationAction != null) {
                _rotationAction.Disable();
                _rotationAction.performed -= OnRotationUpdate;
                _rotationBound = false;
            }
        }

        private void OnRotationUpdate(InputAction.CallbackContext context) {
            // We update when Position is updated
        }

        private void OnPositionUpdate(InputAction.CallbackContext context) {
            UpdateOutputs(context.time);
        }

        public void SetPositionBinding(string path = "", string interactions = "", string processors = "") {
            UnbindPosition();
            InputAction inputAction = new InputAction();
            inputAction.AddBinding(path, interactions, processors);
            this.positionAction = inputAction;
        }

        public void SetRotationBinding(string path = "", string interactions = "", string processors = "") {
            UnbindPosition();
            InputAction inputAction = new InputAction();
            inputAction.AddBinding(path, interactions, processors);
            this.rotationAction = inputAction;
        }

        // For internal representation of controller
        Vector3[] dPos;  // device position
        double[] velX;
        double[] velY;
        double[] velZ;
        Vector3[] accel;
        Quaternion[] dRot;  // device rotation
        Quaternion[] gyro;
        Vector3[] angVel;
        Vector3[] dGravity;
        double[] timestamp;
        double minTimeDiff = 0.1; // seconds
        private int samples = 50;
        private int samplesTaken = 0;
        Vector3 dRight;
        Vector3 dUp;
        Vector3 dForward;

        public IMU() {
            dPos = new Vector3[samples];  // metres
            velX = new double[samples];  // m/s
            velY = new double[samples];
            velZ = new double[samples];
            accel = new Vector3[samples];  // g
            dRot = new Quaternion[samples];
            gyro = new Quaternion[samples];  // deg
            angVel = new Vector3[samples];  // deg/s
            timestamp = new double[samples];  // seconds
        }

        private void OnEnable() {
            BindActions();
        }

        private void UpdateOutputs(double time) {
            // Update our samples with the latest data
            for (int i = samplesTaken - 1; i >= 1; i--) {
                dPos[i] = dPos[i - 1];

                velX[i] = velX[i - 1];
                velY[i] = velY[i - 1];
                velZ[i] = velZ[i - 1];

                accel[i] = accel[i - 1];

                dRot[i] = dRot[i - 1];

                gyro[i] = gyro[i - 1];
                angVel[i] = angVel[i - 1];
                timestamp[i] = timestamp[i - 1];
            }
            samplesTaken = Math.Min(samplesTaken + 1, samples);

            dPos[0] = _positionAction.ReadValue<Vector3>();
            dRot[0] = _rotationAction.ReadValue<Quaternion>();

            if ((float)time - timestamp[0] > 1) {
                timestamp[0] = Time.realtimeSinceStartup;
            } else {
                timestamp[0] = (float)time;
            }
        }

        // NB this is IInputUpdateCallbackReceiver.OnUpdate(); it's synced to the InputSystem, not
        // to the framerate. Put InputSystem.QueueStateEvent() in here to make it work well.
        public void OnUpdate() {
            // Use samples to calculate latest outputs to send

            // Apply smoothing if samples are too close together
            int j = 1;
            while (timestamp[0] - timestamp[j] <= minTimeDiff & j < samplesTaken) {
                j++;
            }

            if (j > 0) {
                double diffTime = timestamp[0] - timestamp[j];
                // m/s
                velX[0] = (dPos[0].x - dPos[j].x) / diffTime;
                velY[0] = (dPos[0].y - dPos[j].y) / diffTime;
                velZ[0] = (dPos[0].z - dPos[j].z) / diffTime;

                //gyroRate[0] = dRotRate * (float)(180f / Math.PI);
                Quaternion diffRot = dRot[0] * Quaternion.Inverse(dRot[j]);
                diffRot.ToAngleAxis(out float angle, out Vector3 axis);
                angVel[0] = (axis * angle) / (float)diffTime;

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
            dForward = dRot[0] * _rotationOffset * Vector3.forward;
            dUp = dRot[0] * _rotationOffset * Vector3.up;
            dRight = dRot[0] * _rotationOffset * Vector3.right;

            Vector3 dGyroscope = new Vector3(
                Vector3.Dot(angVel[0], -dRight),
                Vector3.Dot(angVel[0], dUp),
                Vector3.Dot(angVel[0], -dForward)
            );

            Vector3 dGravity = new Vector3(
                Vector3.Dot(Vector3.up, -dRight),
                Vector3.Dot(Vector3.up, -dUp),
                Vector3.Dot(Vector3.up, dForward)
            );

            Vector3 dAccel = new Vector3(
                Vector3.Dot(accel[0], dRight),
                Vector3.Dot(accel[0], dUp),
                Vector3.Dot(accel[0], -dForward)
            );


            DorsalIMUState state = new DorsalIMUState();

            // Only queue the update if we have enough samples going far enough back to get a decent result
            if (timestamp[0] - timestamp[j] >= minTimeDiff) {
                // If we have enough samples going far enough back to get a decent result, use them...
                state.accelerometer = dAccel + dGravity;
                state.devicePosition = dPos[0] + positionOffset;
                state.deviceRotation = dRot[0] * rotationOffset;
                state.eulerDeviceRotation = state.deviceRotation.eulerAngles;
                state.gyroscope = dGyroscope;

                InputSystem.QueueStateEvent<DorsalIMUState>(this, state, timestamp[0]);
            } else {
                // ...otherwise, just send values as if static, to try to stop calibration screwups.
                // (e.g. https://github.com/MichaelJW/DorsalVR/issues/7)
                state.accelerometer = dGravity;
                state.devicePosition = positionOffset;
                state.deviceRotation = rotationOffset;
                state.eulerDeviceRotation = state.deviceRotation.eulerAngles;
                state.gyroscope = Vector3.zero;

                InputSystem.QueueStateEvent<DorsalIMUState>(this, state, timestamp[0]);
            }
        }
    }
}
