using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dorsal.VREntity {
    // Virtual Reality Game Object
    // (Technically not actually a GameObject but the name stuck.)
    public class VRGO : MonoBehaviour {
        public GameObject container;
        public GameObject mount;
        public GameObject vrEntity;

        public VRGO() {

        }

        public void SetPositionOffset(float x = 0.0f, float y = 0.0f, float z = 0.0f) {
            container.transform.position = new Vector3(x, y, z);
        }

        public void ResetPositionOffset() {
            container.transform.position = Vector3.zero;
        }

        public void SetScale(float x = 1.0f, float y = 1.0f, float z = 1.0f) {
            container.transform.localScale = new Vector3(x, y, z);
        }

        public void ResetScale() {
            container.transform.localScale = Vector3.one;
        }

        public void SetRotationOffset(float x = 0.0f, float y = 0.0f, float z = 0.0f) {
            container.transform.rotation = Quaternion.Euler(x, y, z);
        }

        public void ResetRotationOffset() {
            container.transform.rotation = Quaternion.identity;
        }
    }
}
