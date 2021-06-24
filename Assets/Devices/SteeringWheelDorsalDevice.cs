using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

public class SteeringWheel : MonoBehaviour
{
    //[StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct SteeringWheelDorsalDeviceState : IInputStateTypeInfo {
        public FourCC format => new FourCC('S', 'T', 'W', 'L');

        [InputControl(layout = "axis")]
        public float tilt;
    }

    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    [InputControlLayout(displayName = "Steering Wheel Dorsal Device", stateType = typeof(SteeringWheelDorsalDeviceState))]
    public class SteeringWheelDorsalDevice : InputDevice, IInputUpdateCallbackReceiver {
        public AxisControl axis { get; private set; }

        private UnityEngine.XR.InputDevice leftHand;
        private UnityEngine.XR.InputDevice rightHand;

        static SteeringWheelDorsalDevice() {
            InputSystem.RegisterLayout<SteeringWheelDorsalDevice>();
        }

        public static SteeringWheelDorsalDevice current { get; private set; }

        public override void MakeCurrent() {
            base.MakeCurrent();
            current = this;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeInPlayer() { }

        public SteeringWheelDorsalDevice() {
            RegisterXRDevices();
            UnityEngine.XR.InputDevices.deviceConnected += OnDeviceConnected;
        }

        private void OnDeviceConnected(UnityEngine.XR.InputDevice device) {
            RegisterXRDevices();
        }

        private void RegisterXRDevices() {
            List<UnityEngine.XR.InputDevice> allInputDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevices(allInputDevices);

            for (int i = 0; i < allInputDevices.Count; i++) {
                if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.HeldInHand) == UnityEngine.XR.InputDeviceCharacteristics.HeldInHand) {
                    if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.Left) == UnityEngine.XR.InputDeviceCharacteristics.Left) {
                        leftHand = allInputDevices[i];
                    } else if ((allInputDevices[i].characteristics & UnityEngine.XR.InputDeviceCharacteristics.Right) == UnityEngine.XR.InputDeviceCharacteristics.Right) {
                        rightHand = allInputDevices[i];
                    }
                }
            }
        }

        protected override void FinishSetup() {
            base.FinishSetup();

            axis = GetChildControl<AxisControl>("tilt");
        }

        public void OnUpdate() {
            var state = new SteeringWheelDorsalDeviceState();

            state.tilt = 0.0f;
            if (leftHand != null && rightHand != null) {
                leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out Vector3 leftPos);
                rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out Vector3 rightPos);

                //Debug.Log(string.Format("y: {0}\tx: {1}\tatan2: {2}", rightPos.y - leftPos.y, rightPos.x - leftPos.x, Mathf.Atan2(rightPos.y - leftPos.y, rightPos.x - leftPos.x)));

                state.tilt = -Mathf.Clamp(Mathf.Atan2(rightPos.y - leftPos.y, rightPos.x - leftPos.x) / (Mathf.PI / 4), -1.0f, 1.0f);
            }

            InputSystem.QueueStateEvent(this, state);
        }



    }
}
