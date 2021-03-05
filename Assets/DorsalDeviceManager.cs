using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorsalDeviceManager : MonoBehaviour
{
    public DorsalDevice rightHandDorsalDevice;
    public DorsalDevice leftHandDorsalDevice;
    public DorsalDevice hmdDorsalDevice;
    public bool devicesAreReady = false;
    private Quaternion controllerRelativeRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rightHandDorsalDevice = new DorsalDevice(DorsalDevice.DeviceType.RightHand);
        leftHandDorsalDevice = new DorsalDevice(DorsalDevice.DeviceType.LeftHand);
        hmdDorsalDevice = new DorsalDevice(DorsalDevice.DeviceType.HMD);

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

