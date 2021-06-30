using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorsal.Devices {
    public class DeviceManager : MonoBehaviour {
        public List<IDevice> devices = new List<IDevice>();

        void OnEnable() {

        }
    }
}