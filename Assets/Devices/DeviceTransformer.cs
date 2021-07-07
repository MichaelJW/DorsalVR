using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorsal.Devices {
    public class DeviceTransformer : MonoBehaviour {
        public void TransformFromConfig(Config.DeviceConfig config) {
            gameObject.transform.position = config.vrEntityConfig.positionOffset;
            gameObject.transform.localScale = config.vrEntityConfig.scale;
            gameObject.transform.rotation = config.vrEntityConfig.rotationOffset;
        }
    }
}