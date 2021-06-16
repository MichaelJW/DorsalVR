using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruccho.GraphicsCapture;
using System.Linq;
using System;

namespace Dorsal.Devices {
    class Screen : MonoBehaviour, IDevice {
        GameObject _middleEyeScreen;
        GameObject _leftEyeScreen;
        GameObject _rightEyeScreen;

        private CaptureClient client = new CaptureClient();

        private string _id;
        public string ID {
            get => _id;
            set => _id = value;
        }
        public void Instantiate() {
            _middleEyeScreen = AddScreenGO("Middle Eye");
            _leftEyeScreen = AddScreenGO("Left Eye");
            _leftEyeScreen.layer = 6;
            _rightEyeScreen = AddScreenGO("Right Eye");
            _rightEyeScreen.layer = 7;

            IEnumerable<ICaptureTarget> monitors = Utils.GetMonitors();
            client.SetTarget(monitors.First());
            Application.onBeforeRender += OnBeforeRender;
        }

        private GameObject AddScreenGO(string type) {
            GameObject screenGO = GameObject.CreatePrimitive(PrimitiveType.Quad);
            screenGO.name = string.Format("Screen | {0} | {1}", ID, type);
            screenGO.transform.parent = this.gameObject.transform;
            screenGO.transform.localPosition = Vector3.zero;

            return screenGO;
        }

        // Update is called once per frame
        void Update() {
            UpdateFromSource();
        }

        private void UpdateFromSource() {
            Texture2D captureTex = client.GetTexture();
            if (captureTex != null) {
                captureTex.filterMode = FilterMode.Point;
            }

            if (_middleEyeScreen.GetComponent<Renderer>().material.mainTexture != captureTex) {
                _middleEyeScreen.GetComponent<Renderer>().material.mainTexture = captureTex;
                _middleEyeScreen.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1f, -1f);
            }

            if (_leftEyeScreen.GetComponent<Renderer>().material.mainTexture != captureTex) {
                _leftEyeScreen.GetComponent<Renderer>().material.mainTexture = captureTex;
                _leftEyeScreen.GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.5f, -1f);
            }

            if (_rightEyeScreen.GetComponent<Renderer>().material.mainTexture != captureTex) {
                _rightEyeScreen.GetComponent<Renderer>().material.mainTexture = captureTex;
                _rightEyeScreen.GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.5f, -1f);
                _rightEyeScreen.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.5f, 0f);
            }
        }

        public void SetTarget(ICaptureTarget target) {
            try {
                client.SetTarget(target);
            } catch (CreateCaptureException e) {
                Debug.LogWarning("Could not capture target. Error was: " + e.Message);
            }
        }

        public void OnBeforeRender() {
            UpdateFromSource();
        }

        private void OnDestroy() {
            client?.Dispose();
        }

        public void SetSBS3D(bool isEnabled) {
            _leftEyeScreen.SetActive(isEnabled);
            _rightEyeScreen.SetActive(isEnabled);
            _middleEyeScreen.SetActive(!isEnabled);
        }
    }
}