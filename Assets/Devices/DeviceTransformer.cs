using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorsal.Devices {
    public class DeviceTransformer : MonoBehaviour {
        public void TransformFromConfig(Config.DeviceConfig config) {
            gameObject.transform.position = config.offset;
            gameObject.transform.localScale = config.scale;
            gameObject.transform.localEulerAngles = config.rotation;
        }
    }
}