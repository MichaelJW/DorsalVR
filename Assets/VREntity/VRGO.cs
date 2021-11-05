using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

namespace Dorsal.VREntity {
    // Virtual Reality Game Object
    // (Technically not actually a GameObject but the name stuck.)
    public class VRGO : MonoBehaviour {
        public GameObject container;
        public GameObject mount;
        public GameObject vrEntity;

        public VRGO() {

        }

        public void SetVREntity(string primitive = "Cube") {
            if (vrEntity != null) {
                Destroy(vrEntity);
            }
            switch (primitive.ToLower()) {
                case "sphere":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
                case "capsule":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    break;
                case "cylinder":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    break;
                case "cube":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case "plane":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    break;
                case "quad":
                    vrEntity = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    break;
                default:
                    break;
            }
            if (vrEntity != null) {
                vrEntity.transform.parent = container.transform;
                vrEntity.transform.localScale = Vector3.one;
            }
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

        public void SetPositionBinding(string path = "", string interactions = "", string processors = "") {
            TrackedPoseDriver tpd = mount.GetComponent<TrackedPoseDriver>();
            tpd.positionAction = new InputAction();
            tpd.positionAction.AddBinding(path, interactions, processors);
        }

        public void ResetPositionBinding() {
            TrackedPoseDriver tpd = mount.GetComponent<TrackedPoseDriver>();
            tpd.positionAction.Disable();
            tpd.positionAction.Dispose();
            tpd.positionAction = null;
        }

        public void SetRotationBinding(string path = "", string interactions = "", string processors = "") {
            TrackedPoseDriver tpd = mount.GetComponent<TrackedPoseDriver>();
            tpd.rotationAction = new InputAction();
            tpd.rotationAction.AddBinding(path, interactions, processors);
        }

        public void ResetRotationBinding() {
            TrackedPoseDriver tpd = mount.GetComponent<TrackedPoseDriver>();
            tpd.rotationAction.Disable();
            tpd.rotationAction.Dispose();
            tpd.rotationAction = null;
        }
    }
}
