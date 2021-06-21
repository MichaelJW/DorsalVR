using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DolphinDSUPacket;

public class DolphinOutput : MonoBehaviour {
    DolphinControls controls;
    DSUServer dsuServer;
    Packet packet;

    public void OnEnable() { 
        if (controls == null) {
            controls = new DolphinControls();
        }
        controls.DolphinGCPad.Enable();
    }

    public void OnDisable() {
        controls.DolphinGCPad.Disable();
        EndServer();
    }

    // Start is called before the first frame update
    void Start()
    {
        dsuServer = new DSUServer();
        dsuServer.StartServer(26659);
        packet = new Packet();
    }

    private void OnDestroy() {
        EndServer();
    }

    private void EndServer() {
        if (dsuServer != null) {
            dsuServer.EndServer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        packet.gcPad.aButton = (byte)(controls.DolphinGCPad.A.ReadValue<float>() * 255);
        packet.gcPad.bButton = (byte)(controls.DolphinGCPad.B.ReadValue<float>() * 255);
        packet.gcPad.xButton = (byte)(controls.DolphinGCPad.X.ReadValue<float>() * 255);
        packet.gcPad.yButton = (byte)(controls.DolphinGCPad.Y.ReadValue<float>() * 255);
        packet.gcPad.zButton = (byte)(controls.DolphinGCPad.Z.ReadValue<float>() * 255);
        packet.gcPad.startButton = (byte)(controls.DolphinGCPad.Start.ReadValue<float>() * 255);
        packet.gcPad.mainStickX = (byte)((controls.DolphinGCPad.MainStickX.ReadValue<float>() - 0.5) * 255);
        packet.gcPad.mainStickY = (byte)((controls.DolphinGCPad.MainStickY.ReadValue<float>() - 0.5) * 255);
        packet.gcPad.cStickX = (byte)((controls.DolphinGCPad.CStickX.ReadValue<float>() - 0.5) * 255);
        packet.gcPad.cStickY = (byte)((controls.DolphinGCPad.CStickY.ReadValue<float>() - 0.5) * 255);
        packet.gcPad.leftTrigger = (byte)(controls.DolphinGCPad.LTrigger.ReadValue<float>() * 255);
        packet.gcPad.rightTrigger = (byte)(controls.DolphinGCPad.RTrigger.ReadValue<float>() * 255);
        packet.gcPad.dPadUp = (byte)(controls.DolphinGCPad.DPadUp.ReadValue<float>() * 255);
        packet.gcPad.dPadDown = (byte)(controls.DolphinGCPad.DPadDown.ReadValue<float>() * 255);
        packet.gcPad.dPadLeft = (byte)(controls.DolphinGCPad.DPadLeft.ReadValue<float>() * 255);
        packet.gcPad.dPadRight = (byte)(controls.DolphinGCPad.DPadRight.ReadValue<float>() * 255);

        //Debug.Log(System.BitConverter.ToString(packet.GetMessageBytes(2)));

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
         * Well, the above works! Next up is to expand this to cover all inputs, for completeness. 
         * There are several possible routes to choose from next; will consider that at the time based on what I feel like doing.
         * To consider: 
         *  - In some cases we will want a specific, unchangeable menu option that maps to a Dolphin input (particularly for hotkeys
         *    like "save state") but will also want to offer the user the option to assign an input to this. A "MenuDevice" isn't
         *    necessarily the best way of doing this, because we don't want the user to be able to un-assign the MenuDevice input.
         *  - How do we let the user switch which DorsalDevice they're "holding"? For now, possibly just a menu; maybe a menu per
         *    hand. This way each hand can hold a separate Wiimote, and we can swap which hand is holding Wiimote #1. Some devices
         *    will be two-handed but maybe with the *option* to hold them in one hand (e.g. hold a steering wheel and a gun).
         * 
         */

        //Debug.Log(string.Format("RVAO: {0}", controls.GameCube.A.ReadValueAsObject()));
        //Debug.Log(string.Format("RVAO: {0}", controls.GameCube.LeftStickX.ReadValueAsObject()));
    }
}
