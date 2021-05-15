using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DolphinDSUPacket;

public class DolphinOutput : MonoBehaviour, DolphinControls.IGameCubeActions {
    DolphinControls controls;
    DSUServer dsuServer;
    Packet packet;

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
        dsuServer = new DSUServer();
        dsuServer.StartServer(26659);
        packet = new Packet();
    }

    private void OnDestroy() {
        if (dsuServer != null) {
            dsuServer.EndServer();
        }
    }

    // Update is called once per frame
    void Update()
    {

        packet.gcPad.aButton = (byte)(controls.GameCube.A.ReadValue<float>() * 255);
        packet.gcPad.bButton = (byte)(controls.GameCube.B.ReadValue<float>() * 255);
        packet.gcPad.mainStickX = (byte)((controls.GameCube.LeftStickX.ReadValue<float>() - 0.5) * 255);

        Debug.Log(System.BitConverter.ToString(packet.GetMessageBytes(2)));

        dsuServer.SendDataBytes(2, packet.GetMessageBytes(2));

        /*
         * 
         * Create more DolphinControls sections (like we have GameCube)
         * - so one for Wiimote and one for Hotkeys; Hotkeys could be subdivided I guess
         * - make sure we use appropriate types of input
         * - this way we can remap things via Unity Input System import, rather than via Dolphin INI or by changing code
         * In this class, DolphinOutput, create/update a DolphinDSUPacket based on DolphinControls
         * - could be as simple as, in Update(), doing "if GameCube.A then packet.gamecube.a = 255" or whatever
         * - will need to expand DolphinDSUPacket so that it has instances of Hotkeys, GCPad, and Wiimote that are accessible
         * - I guess DolphinOutput creates this packet and updates it, so it "owns" it
         * Add some kind of ToDataBytes() message to DolphinDSUPacket
         * - this would return the properly formatted packet ready for the server to send
         * - may wish to cache the previous bytes and return those via this new function until UpdateDataBytes([timestamp]) is called
         * Pass the bytes/packet to the DSU server
         * - using MVC I think it makes sense for DolphinOutput to be the C and to update the M (the packet) and also pass it to
         *   the server (essentially the V), or at least alert the server that it's ready
         * - we could allow the server to grab the bytes every X ms but this seems silly since DolphinOutput *knows* when the packet
         *   will be ready
         * 
         */

        //Debug.Log(string.Format("RVAO: {0}", controls.GameCube.A.ReadValueAsObject()));
        //Debug.Log(string.Format("RVAO: {0}", controls.GameCube.LeftStickX.ReadValueAsObject()));
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
