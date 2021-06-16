using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorsal.Devices {
    public class DeviceMounter : MonoBehaviour {
        

        void Start() {
            Application.onBeforeRender += OnBeforeRender;
            FollowMount();
        }

        private void OnBeforeRender() {
            FollowMount();
        }

        private void Update() {
            FollowMount();
        }

        private void FixedUpdate() {
            FollowMount();
        }

        private void FollowMount() {

        }
    }
}