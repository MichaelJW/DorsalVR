using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDSUDevice {

    public class ControllerTouchData {
        public bool isTouchActive = false;
        public byte touchID = 0;
        public ushort xPos = 0;
        public ushort yPos = 0;
    };

    public byte controllerConnected = 1; // connected
    public uint packetNumber = 0;
    // DSU protocol states that the following buttons should be collapsed into two bitmasks.
    // For ease, we will set them as bools and let code do the work of bitmasking them.
    public bool dpadLeft = false;  // true = pressed
    public bool dpadDown = false;
    public bool dpadRight = false;
    public bool dpadUp = false;
    public bool optionsButton = false;
    public bool r3Button = false;
    public bool l3Button = false;
    public bool shareButton = false;
    public bool yButton = false;
    public bool bButton = false;
    public bool aButton = false;
    public bool xButton = false;
    public bool r1Button = false;
    public bool l1Button = false;
    public bool r2Button = false;
    public bool l2Button = false;
    // Above comment applies up to here.
    public byte psButton = 0;  // unused
    public byte touchButton = 0;  // unused
    public byte leftStickX = 128;  // protocol states that range is 0-255 with 128 being neutral
    public byte leftStickY = 128;
    public byte rightStickX = 128;
    public byte rightStickY = 128;
    public byte analogDpadLeft = 0;  // protocol states that range is 0-255 with 0 being released
    public byte analogDpadDown = 0;
    public byte analogDpadRight = 0;
    public byte analogDpadUp = 0;
    public byte analogYButton = 0;
    public byte analogBButton = 0;
    public byte analogAButton = 0;
    public byte analogXButton = 0;
    public byte analogR1Button = 0;
    public byte analogL1Button = 0;
    public byte analogR2Button = 0;
    public byte analogL2Button = 0;
    public ControllerTouchData firstTouch = new ControllerTouchData();
    public ControllerTouchData secondTouch = new ControllerTouchData();
    public Int64 motionTimestamp;
    public float accelerometerX = 0f;
    public float accelerometerY = 0f;
    public float accelerometerZ = 0f;
    public float gyroPitchRate = 0f;
    public float gyroYawRate = 0f;
    public float gyroRollRate = 0f;


    public SingleDSUDevice(byte slot, uint serverId = (uint)0) {
        
    }
}
