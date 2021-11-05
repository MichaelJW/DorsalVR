using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.InputSystem.XR;
using Dorsal.VREntity;

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

        public IMU CreateIMU(string id) {
            IMU imu = devices.OfType<IMU>().FirstOrDefault(d => d.ID == id);
            if (imu == null) {
                imu = InputSystem.AddDevice<IMU>(id);
                imu.ID = id;
                devices.Add(imu);
                InputSystem.EnableDevice(imu);
            }
            return imu;
        }

        public Decoration CreateDecoration() {
            GameObject container = new GameObject();
            container.AddComponent<Dorsal.Devices.DeviceTransformer>();
            GameObject mount = new GameObject();
            TrackedPoseDriver tpd = mount.AddComponent<TrackedPoseDriver>();
            container.transform.parent = mount.transform;
            mount.transform.parent = GameObject.Find("Mounts").transform;

            mount.name = "Mount for Decoration";
            container.name = "Decoration Container";
            Decoration decoration = container.AddComponent<Decoration>();

            decoration.container = container;
            decoration.mount = mount;

            return decoration;
        }
    }
}