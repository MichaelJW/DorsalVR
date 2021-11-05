using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.InputSystem.XR;

namespace Dorsal.Devices {
    public class DeviceManager : MonoBehaviour {
        public List<IDevice> devices = new List<IDevice>();

        public void OnDisable() {
            foreach (Dorsal.Devices.IMU imu in devices.OfType<Dorsal.Devices.IMU>()) {
                InputSystem.RemoveDevice(imu);
            }
        }

        public Screen CreateScreen() {
            GameObject container = new GameObject();
            container.AddComponent<Dorsal.Devices.DeviceTransformer>();
            GameObject mount = new GameObject();
            TrackedPoseDriver tpd = mount.AddComponent<TrackedPoseDriver>();
            container.transform.parent = mount.transform;
            mount.transform.parent = GameObject.Find("Mounts").transform;

            mount.name = "Mount for Screen";
            container.name = "Screen Container";
            Screen screen = container.AddComponent<Screen>();

            screen.container = container;
            screen.mount = mount;
            
            devices.Add(screen);
            screen.Instantiate();
            return screen;
        }
    }
}