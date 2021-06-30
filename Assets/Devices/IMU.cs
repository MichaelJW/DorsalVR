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

namespace Dorsal.Devices {
    public struct DorsalIMUState : IInputStateTypeInfo {
        public FourCC format => new FourCC('D', 'I', 'M', 'U');

        [InputControl(layout = "Vector3")]
        public Vector3 devicePosition;
        [InputControl(layout = "Quaternion")]
        public Quaternion deviceRotation;
        [InputControl(layout = "Vector3")]
        public Vector3 accelerometer;
        [InputControl(layout = "Quaternion")]
        public Quaternion gyroscope;
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
        public Vector3Control accelerometer { get; private set; }
        public QuaternionControl gyroscope { get; private set; }

        protected override void FinishSetup() {
            base.FinishSetup();

            devicePosition = GetChildControl<Vector3Control>("devicePosition");
            deviceRotation = GetChildControl<QuaternionControl>("deviceRotation");
            accelerometer = GetChildControl<Vector3Control>("accelerometer");
            gyroscope = GetChildControl<QuaternionControl>("gyroscope");
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
            Debug.Log("Bind");
            if (!_positionBound && _positionAction != null) {
                _positionAction.performed += OnPositionUpdate;
                _positionBound = true;
                _positionAction.Enable();
                Debug.Log("Bound");
                Debug.Log(_positionAction.bindings[0].groups);
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
            Debug.Log("Unbind");
            if (_positionBound && _positionAction != null) {
                _positionAction.Disable();
                _positionAction.performed -= OnPositionUpdate;
                _positionBound = false;
                Debug.Log("Unbound");
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
        double minTimeDiff = 0.1; // seconds
        private int samples = 50;
        private int samplesTaken = 0;
        Vector3 dRight;
        Vector3 dUp;
        Vector3 dForward;

        public IMU() {
            pos = new Vector3[samples];  // metres
            velX = new double[samples];  // m/s
            velY = new double[samples];
            velZ = new double[samples];
            accel = new Vector3[samples];  // g
            gyro = new Quaternion[samples];  // deg
            gyroRate = new Vector3[samples];  // deg/s
            dGravity = new Vector3[samples];  // g
            timestamp = new double[samples];  // seconds
        }

        private void OnEnable() {
            BindActions();
        }

        private void UpdateOutputs(double time) {
            Vector3 dPos = _positionAction.ReadValue<Vector3>();
            Quaternion dRot = _rotationAction.ReadValue<Quaternion>();

            dForward = dRot * _rotationOffset * Vector3.forward;
            dUp = dRot * _rotationOffset * Vector3.up;
            dRight = dRot * _rotationOffset * Vector3.right;

            for (int i = samplesTaken - 1; i >= 1; i--) {
                pos[i] = pos[i - 1];

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

            pos[0] = dPos;

            // Apply smoothing if samples are too close together
            int j = 1;
            while (timestamp[0] - timestamp[j] <= minTimeDiff & j < samplesTaken) {
                j++;
            }

            if (j > 0) {
                double diffTime = timestamp[0] - timestamp[j];
                // m/s
                velX[0] = (pos[0].x - pos[j].x) / diffTime;
                velY[0] = (pos[0].y - pos[j].y) / diffTime;
                velZ[0] = (pos[0].z - pos[j].z) / diffTime;

                //gyroRate[0] = dRotRate * (float)(180f / Math.PI);

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

            if (timestamp[0] - timestamp[j] >= minTimeDiff) {
                var state = new DorsalIMUState();
                state.accelerometer = dAccel + dGravity[0];
                state.devicePosition = dPos + positionOffset;
                state.deviceRotation = dRot * rotationOffset;
                state.gyroscope = Quaternion.identity;
                InputSystem.QueueStateEvent(this, state);
            }
        }

        public void OnUpdate() {
            // Not needed?
            // Could perhaps split previous method in two; that one logs the new input values, and this one updates state
        }
    }
}
