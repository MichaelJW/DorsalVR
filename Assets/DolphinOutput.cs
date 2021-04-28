using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DolphinOutput : MonoBehaviour, DolphinControls.IGameCubeActions {
    DolphinControls controls;

    public void OnEnable() { 
        if (controls == null) {
            controls = new DolphinControls();
            controls.GameCube.SetCallbacks(this);
        }
        controls.GameCube.Enable();
    }

    public void OnDisable() {
        controls.GameCube.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(string.Format("RVAO: {0}", controls.GameCube.A.ReadValueAsObject()));
        Debug.Log(string.Format("RVAO: {0}", controls.GameCube.LeftStickX.ReadValueAsObject()));
    }

    void DolphinControls.IGameCubeActions.OnA(InputAction.CallbackContext context) {
        Debug.Log("A was pressed.");
    }

    void DolphinControls.IGameCubeActions.OnB(InputAction.CallbackContext context) {
        Debug.Log("B was pressed.");
    }
    void DolphinControls.IGameCubeActions.OnLeftStickX(InputAction.CallbackContext context) {
        Debug.Log(string.Format("Left Stick X: {0}", context.ReadValueAsObject()));
    }
}
