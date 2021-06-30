using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace Dorsal.Devices {
    public class DeviceManager : MonoBehaviour {
        public List<IDevice> devices = new List<IDevice>();

        public void OnDisable() {
            foreach (Dorsal.Devices.IMU imu in devices.OfType<Dorsal.Devices.IMU>()) {
                InputSystem.RemoveDevice(imu);
            }
        }
    }
}