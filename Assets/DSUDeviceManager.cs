using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OldDSU;
using System;

public class DSUDeviceManager : MonoBehaviour
{
    private IO io;

    public DSUDevice zero;
    public DSUDevice one;
    public DSUDevice two;

    private uint serverId = 0;
    private bool devicesAreReady = false;

    [SerializeField]
    OldDorsalDeviceManager dorsalDeviceManager;

    // Start is called before the first frame update
    void Start()
    {
        zero = new DSUDevice(0, serverId);
        zero.manager = this;
        one = new DSUDevice(1, serverId);
        one.manager = this;
        two = new DSUDevice(2, serverId);
        two.manager = this;
    }

    void Update() { 
        if (!devicesAreReady & dorsalDeviceManager.devicesAreReady) {
            zero.motionDevice = dorsalDeviceManager.hmdDorsalDevice;
            zero.pointerDevice = dorsalDeviceManager.rightHandDorsalDevice;

            one.motionDevice = dorsalDeviceManager.leftHandDorsalDevice;
            one.buttonDevice = dorsalDeviceManager.leftHandDorsalDevice;

            two.motionDevice = dorsalDeviceManager.rightHandDorsalDevice;
            two.buttonDevice = dorsalDeviceManager.rightHandDorsalDevice;

            devicesAreReady = true;
        }
    }

    public void SetServerId(uint _serverId) {
        serverId = _serverId;
        if (devicesAreReady) {
            zero.SetServerId(serverId);
            one.SetServerId(serverId);
            two.SetServerId(serverId);
        }
    }

    public void SetIO(IO _io) {
        io = _io;
    }

    public int GetNumDevices() {
        if (devicesAreReady) {
            return 3;
        }
        return 0;
    }

    public byte[] GetInfoBytes(int _slot) {
        if (!devicesAreReady || _slot < 0 || _slot > 2) {
            return null;
        } else {
            return _slot switch {
                0 => zero.GetInfoBytes(),
                1 => one.GetInfoBytes(),
                2 => two.GetInfoBytes(),
                _ => null,
            };
        }
    }

    public byte[] GetDataBytes(int _slot) {
        if (!devicesAreReady || _slot < 0 || _slot > 2) {
            return null;
        } else {
            return _slot switch {
                0 => zero.GetDataBytes(),
                1 => one.GetDataBytes(),
                2 => two.GetDataBytes(),
                _ => null,
            };
        }
    }

    // Called whenever a device has its info completely updated
    public void DeviceUpdated(DSUDevice dsuDevice) {
        if (dsuDevice == zero) {
            io.DataIsUpdated(0);
        } else if (dsuDevice == one) {
            io.DataIsUpdated(1);
        } else if (dsuDevice == two) {
            io.DataIsUpdated(2);
        }
    }
}

