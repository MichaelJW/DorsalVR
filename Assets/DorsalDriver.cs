using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

// Based on TrackedPoseDriver, but stripped down and modified to do what we need here
public class DorsalDriver : MonoBehaviour {
    DorsalDevice dorsalDevice;

    [SerializeField]
    DorsalDeviceManager dorsalDeviceManager;
    [SerializeField]
    public DorsalDevice.DeviceType deviceType;

    public void Start() {
        ConnectToChosenDevice();
        Application.onBeforeRender += OnBeforeRender;
    }

    public void ConnectToChosenDevice() {
        switch (deviceType) {
            case DorsalDevice.DeviceType.Undefined:
                break;
            case DorsalDevice.DeviceType.HMD:
                dorsalDevice = dorsalDeviceManager.hmdDorsalDevice;
                break;
            case DorsalDevice.DeviceType.LeftHand:
                dorsalDevice = dorsalDeviceManager.leftHandDorsalDevice;
                break;
            case DorsalDevice.DeviceType.RightHand:
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
}
