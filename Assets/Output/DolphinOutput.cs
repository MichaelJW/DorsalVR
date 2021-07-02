using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DolphinDSUPacket;

public class DolphinOutput : MonoBehaviour {
    DolphinControls controls;
    DSUServer dsuServer;
    Packet packet;
    
    public WiimoteExtension selectedExtension = WiimoteExtension.None;

    // Taken from Dolphin WiimoteEmu/ExtensionPort.h
    public enum WiimoteExtension {
        None,
        Nunchuk,
        Classic,
        Guitar,
        Drums,
        Turntable,
        UDrawTablet,
        DrawsomeTablet,
        Tatacon
    }

    public void OnEnable() {
        SetUp();
    }

    public void OnDisable() {
        Finish();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    public void SetControls(DolphinControls dolphinControls) {
        if (controls != null) {
            controls.Disable();
        }
        controls = dolphinControls;
        controls.Enable();
    }

    private void SetUp() {
        if (dsuServer == null) {
            dsuServer = new DSUServer();
            dsuServer.StartServer(26659);
        }
        packet = new Packet();
    }

    private void OnDestroy() {
        Finish();
    }

    private void Finish() {
        if (controls != null) {
            controls.Disable();
        }
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
        if (controls != null) {
            packet.gcPad.aButton = (byte)(controls.DolphinGCPad.A.ReadValue<float>() * 255);
            packet.gcPad.bButton = (byte)(controls.DolphinGCPad.B.ReadValue<float>() * 255);
            packet.gcPad.xButton = (byte)(controls.DolphinGCPad.X.ReadValue<float>() * 255);
            packet.gcPad.yButton = (byte)(controls.DolphinGCPad.Y.ReadValue<float>() * 255);
            packet.gcPad.zButton = (byte)(controls.DolphinGCPad.Z.ReadValue<float>() * 255);
            packet.gcPad.startButton = (byte)(controls.DolphinGCPad.Start.ReadValue<float>() * 255);
            packet.gcPad.mainStickX = (byte)((controls.DolphinGCPad.MainStickX.ReadValue<float>() + 1.0) * 127);
            packet.gcPad.mainStickY = (byte)((controls.DolphinGCPad.MainStickY.ReadValue<float>() + 1.0) * 127);
            packet.gcPad.cStickX = (byte)((controls.DolphinGCPad.CStickX.ReadValue<float>() + 1.0) * 127);
            packet.gcPad.cStickY = (byte)((controls.DolphinGCPad.CStickY.ReadValue<float>() + 1.0) * 127);
            packet.gcPad.leftTrigger = (byte)(controls.DolphinGCPad.LTrigger.ReadValue<float>() * 255);
            packet.gcPad.rightTrigger = (byte)(controls.DolphinGCPad.RTrigger.ReadValue<float>() * 255);
            packet.gcPad.dPadUp = (byte)(controls.DolphinGCPad.DPadUp.ReadValue<float>() * 255);
            packet.gcPad.dPadDown = (byte)(controls.DolphinGCPad.DPadDown.ReadValue<float>() * 255);
            packet.gcPad.dPadLeft = (byte)(controls.DolphinGCPad.DPadLeft.ReadValue<float>() * 255);
            packet.gcPad.dPadRight = (byte)(controls.DolphinGCPad.DPadRight.ReadValue<float>() * 255);

            packet.wiimote.aButton = (byte)(controls.DolphinWiimote.A.ReadValue<float>() * 255);
            packet.wiimote.bButton = (byte)(controls.DolphinWiimote.B.ReadValue<float>() * 255);
            packet.wiimote.oneButton = (byte)(controls.DolphinWiimote.One.ReadValue<float>() * 255);
            packet.wiimote.twoButton = (byte)(controls.DolphinWiimote.Two.ReadValue<float>() * 255);
            packet.wiimote.minusButton = (controls.DolphinWiimote.Minus.ReadValue<float>() >= 0.5);
            packet.wiimote.plusButton = (controls.DolphinWiimote.Plus.ReadValue<float>() >= 0.5);
            packet.wiimote.homeButton = (byte)(controls.DolphinWiimote.Home.ReadValue<float>() * 255);
            packet.wiimote.accelX = (controls.DolphinWiimote.AccelerometerX.ReadValue<float>());
            packet.wiimote.accelY = (controls.DolphinWiimote.AccelerometerY.ReadValue<float>());
            packet.wiimote.accelZ = (controls.DolphinWiimote.AccelerometerZ.ReadValue<float>());
            packet.wiimote.gyroPitch = (controls.DolphinWiimote.GyroPitch.ReadValue<float>());
            packet.wiimote.gyroYaw = (controls.DolphinWiimote.GyroYaw.ReadValue<float>());
            packet.wiimote.gyroRoll = (controls.DolphinWiimote.GyroRoll.ReadValue<float>());
            packet.wiimote.dPadUp = (byte)(controls.DolphinWiimote.DPadUp.ReadValue<float>() * 255);
            packet.wiimote.dPadDown = (byte)(controls.DolphinWiimote.DPadDown.ReadValue<float>() * 255);
            packet.wiimote.dPadLeft = (byte)(controls.DolphinWiimote.DPadLeft.ReadValue<float>() * 255);
            packet.wiimote.dPadRight = (byte)(controls.DolphinWiimote.DPadRight.ReadValue<float>() * 255);
            packet.wiimote.imuirRecenter = (controls.DolphinWiimote.Recenter.ReadValue<float>() >= 0.5);
            packet.wiimote.xShake = (byte)(controls.DolphinWiimote.ShakeX.ReadValue<float>() * 255);
            packet.wiimote.yShake = (byte)(controls.DolphinWiimote.ShakeY.ReadValue<float>() * 255);
            packet.wiimote.zShake = (byte)(controls.DolphinWiimote.ShakeZ.ReadValue<float>() * 255);

            packet.wiimote.extension = (byte)selectedExtension;

            packet.wiimote.nunchukC = (byte)(controls.DolphinNunchuk.C.ReadValue<float>() * 255);
            packet.wiimote.nunchukZ = (byte)(controls.DolphinNunchuk.Z.ReadValue<float>() * 255);
            packet.wiimote.nunchukStickX = (byte)((controls.DolphinNunchuk.StickX.ReadValue<float>() + 1.0) * 127);
            packet.wiimote.nunchukStickY = (byte)((controls.DolphinNunchuk.StickY.ReadValue<float>() + 1.0) * 127);
            packet.wiimote.nunchukAccelX = (controls.DolphinNunchuk.AccelerometerX.ReadValue<float>());
            packet.wiimote.nunchukAccelY = (controls.DolphinNunchuk.AccelerometerY.ReadValue<float>());
            packet.wiimote.nunchukAccelZ = (controls.DolphinNunchuk.AccelerometerZ.ReadValue<float>());

            packet.hotkeys.togglePause = controls.DolphinHotkeys.TogglePause.ReadValue<float>() >= 0.5;
            packet.hotkeys.takeScreenshot = controls.DolphinHotkeys.TakeScreenshot.ReadValue<float>() >= 0.5;
            packet.hotkeys.saveState = controls.DolphinHotkeys.SaveState.ReadValue<float>() >= 0.5;
            packet.hotkeys.loadState = controls.DolphinHotkeys.LoadState.ReadValue<float>() >= 0.5;
            packet.hotkeys.increase3DDepth = controls.DolphinHotkeys.IncreaseDepth.ReadValue<float>() >= 0.5;
            packet.hotkeys.decrease3DDepth = controls.DolphinHotkeys.DecreaseDepth.ReadValue<float>() >= 0.5;
            packet.hotkeys.increase3DConvergence = controls.DolphinHotkeys.IncreaseConvergence.ReadValue<float>() >= 0.5;
            packet.hotkeys.decrease3DConvergence = controls.DolphinHotkeys.DecreaseConvergence.ReadValue<float>() >= 0.5;
        }

        dsuServer.SendDataBytes(0, packet.GetMessageBytes(0));
        dsuServer.SendDataBytes(1, packet.GetMessageBytes(1));
        dsuServer.SendDataBytes(2, packet.GetMessageBytes(2));
        dsuServer.SendDataBytes(3, packet.GetMessageBytes(3));
    }
}
