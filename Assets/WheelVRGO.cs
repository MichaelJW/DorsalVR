using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelVRGO : MonoBehaviour
{
    DolphinControls controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controls == null) {
            controls = new DolphinControls();
            controls.DolphinGCPad.Enable();
        } else {
            //transform.rotation = Quaternion.AngleAxis((float)controls.DolphinGCPad.MainStickX.ReadValueAsObject() * -90f, Vector3.forward);
            //Debug.Log((float)controls.GameCube.LeftStickX.ReadValueAsObject());
        }
    }
}
