using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldDorsalDeviceManager : MonoBehaviour
{
    public OldDorsalDevice rightHandDorsalDevice;
    public OldDorsalDevice leftHandDorsalDevice;
    public OldDorsalDevice hmdDorsalDevice;
    public bool devicesAreReady = false;
    private Quaternion controllerRelativeRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rightHandDorsalDevice = new OldDorsalDevice(OldDorsalDevice.DeviceType.RightHand);
        leftHandDorsalDevice = new OldDorsalDevice(OldDorsalDevice.DeviceType.LeftHand);
        hmdDorsalDevice = new OldDorsalDevice(OldDorsalDevice.DeviceType.HMD);

        leftHandDorsalDevice.SetRelativeRotation(controllerRelativeRotation);
        rightHandDorsalDevice.SetRelativeRotation(controllerRelativeRotation);

        devicesAreReady = true;
    }

    private void Update() {
        rightHandDorsalDevice.GetScreenPoint();
    }

    public void SetControllerRelativeRotations(Quaternion _relativeRotation) {
        controllerRelativeRotation = _relativeRotation;
        if (leftHandDorsalDevice != null) leftHandDorsalDevice.SetRelativeRotation(controllerRelativeRotation);
        if (rightHandDorsalDevice != null) rightHandDorsalDevice.SetRelativeRotation(controllerRelativeRotation);
    }
}

