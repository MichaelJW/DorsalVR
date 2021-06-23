using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

// No longer used - but kept temporarily for reference

public class DorsalDriver : MonoBehaviour {
    /*
    OldDorsalDevice dorsalDevice;

    [SerializeField]
    OldDorsalDeviceManager dorsalDeviceManager;
    [SerializeField]
    public OldDorsalDevice.DeviceType deviceType;

    public void Start() {
        ConnectToChosenDevice();
        Application.onBeforeRender += OnBeforeRender;
    }

    public void ConnectToChosenDevice() {
        switch (deviceType) {
            case OldDorsalDevice.DeviceType.Undefined:
                dorsalDevice = null;
                break;
            case OldDorsalDevice.DeviceType.HMD:
                dorsalDevice = dorsalDeviceManager.hmdDorsalDevice;
                break;
            case OldDorsalDevice.DeviceType.LeftHand:
                dorsalDevice = dorsalDeviceManager.leftHandDorsalDevice;
                break;
            case OldDorsalDevice.DeviceType.RightHand:
                dorsalDevice = dorsalDeviceManager.rightHandDorsalDevice;
                break;
            default:
                break;
        }
    }

    public void Update() {
        if (dorsalDevice != null) {
            transform.localPosition = dorsalDevice.devicePosition;
            transform.localRotation = dorsalDevice.deviceRotation;
        }
    }

    public void FixedUpdate() {
        if (dorsalDevice != null) {
            transform.localPosition = dorsalDevice.devicePosition;
            transform.localRotation = dorsalDevice.deviceRotation;
        }
    }

    public void OnBeforeRender() {
        if (dorsalDevice != null) {
            transform.localPosition = dorsalDevice.devicePosition;
            transform.localRotation = dorsalDevice.deviceRotation;
        }
    }
    */
}
