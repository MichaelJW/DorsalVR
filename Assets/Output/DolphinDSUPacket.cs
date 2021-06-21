using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DolphinDSUPacket
{
    public class Hotkeys {
        public bool togglePause = false;
        public bool takeScreenshot = false;
        public bool exitDolphin = false;
        public bool decreaseSpeed = false;
        public bool increaseSpeed = false;
        public bool disableSpeedLimit = false;
        public bool toggleCrop = false;
        public bool toggleAspectRatio = false;
        public bool toggleFog = false;
        public bool toggleCustomTextures = false;

        public bool increaseInternalResolution = false;
        public bool decreaseInternalResolution = false;
        public bool toggleSBS3D = false;
        public bool decrease3DDepth = false;
        public bool increase3DDepth = false;
        public bool decrease3DConvergence = false;
        public bool increase3DConvergence = false;

        public bool loadStateSlot1 = false;
        public bool loadStateSlot2 = false;
        public bool loadStateSlot3 = false;
        public bool loadStateSlot4 = false;
        public bool loadStateSlot5 = false;
        public bool loadStateSlot6 = false;
        public bool loadStateSlot7 = false;
        public bool loadStateSlot8 = false;
        public bool loadStateSlot9 = false;
        public bool loadStateSlot10 = false;
        public bool loadFromSelectedSlot = false;

        public bool saveStateSlot1 = false;
        public bool saveStateSlot2 = false;
        public bool saveStateSlot3 = false;
        public bool saveStateSlot4 = false;
        public bool saveStateSlot5 = false;
        public bool saveStateSlot6 = false;
        public bool saveStateSlot7 = false;
        public bool saveStateSlot8 = false;
        public bool saveStateSlot9 = false;
        public bool saveStateSlot10 = false;
        public bool saveToSelectedSlot = false;

        public bool selectStateSlot1 = false;
        public bool selectStateSlot2 = false;
        public bool selectStateSlot3 = false;
        public bool selectStateSlot4 = false;
        public bool selectStateSlot5 = false;
        public bool selectStateSlot6 = false;
        public bool selectStateSlot7 = false;
        public bool selectStateSlot8 = false;
        public bool selectStateSlot9 = false;
        public bool selectStateSlot10 = false;

        public bool loadStateLast1 = false;
        public bool loadStateLast2 = false;
        public bool loadStateLast3 = false;
        public bool loadStateLast4 = false;
        public bool loadStateLast5 = false;
        public bool loadStateLast6 = false;
        public bool loadStateLast7 = false;
        public bool loadStateLast8 = false;
        public bool loadStateLast9 = false;
        public bool loadStateLast10 = false;

        public bool saveOldestState = false;
        public bool undoLoadState = false;
        public bool undoSaveState = false;
        public bool saveState = false;
        public bool loadState = false;
    }

    public class GCPad {
        public byte aButton = 0;
        public byte bButton = 0;
        public byte xButton = 0;
        public byte yButton = 0;
        public byte zButton = 0;
        public byte startButton = 0;

        // For sticks, 128 is neutral, positive dir is right/down
        public byte mainStickX = 128;
        public byte mainStickY = 128;
        public byte cStickX = 128;
        public byte cStickY = 128;

        // D-Pad is reported as four separate analog buttons
        public byte dPadLeft = 0;
        public byte dPadDown = 0;
        public byte dPadRight = 0;
        public byte dPadUp = 0;

        // The Dolphin profile uses the same input for triggers-as-analog
        // and triggers-as-buttons
        public byte leftTrigger = 0;
        public byte rightTrigger = 0;
    }

    public class Wiimote {
        public byte aButton = 0;
        public byte bButton = 0;
        public byte oneButton = 0;
        public byte twoButton = 0;
        public bool minusButton = false;
        public bool plusButton = false;
        public byte homeButton = 0;

        public byte dPadLeft = 0;
        public byte dPadDown = 0;
        public byte dPadRight = 0;
        public byte dPadUp = 0;

        public byte xShake = 0;
        public byte yShake = 0;
        public byte zShake = 0;

        public float irX = 0;
        public float irY = 0;

        public float accelX = 0;
        public float accelY = 0;
        public float accelZ = 0;
        public float gyroPitch = 0;
        public float gyroRoll = 0;
        public float gyroYaw = 0;

        public bool imuirEnabled = true;
        public bool imuirRecenter = false;

        public byte extension = 0;

        public byte nunchukC = 0;
        public byte nunchukZ = 0;
        public byte nunchukStickX = 0;
        public byte nunchuckStickY = 0;
        public float nunchuckAccelX = 0;
        public float nunchuckAccelY = 0;
        public float nunchuckAccelZ = 0;

        public byte classicY = 0;
        public byte classicB = 0;
        public byte classicA = 0;
        public byte classicX = 0;
        public byte classicZL = 0;
        public byte classicZR = 0;
        public bool classicMinus = false;
        public bool classicPlus = false;
        public byte classicHome = 0;
        public byte classicLeftStickX = 0;
        public byte classicLeftStickY = 0;
        public byte classicRightStickX = 0;
        public byte classicRightStickY = 0;
        public byte classicLeftTrigger = 0;
        public byte classicRightTrigger = 0;
        public byte classicDPadUp = 0;
        public byte classicDPadDown = 0;
        public byte classicDPadLeft = 0;
        public byte classicDPadRight = 0;

        // 128 is neutral
        public byte speakerPan = 128;
    }

    public class Packet {
        public Hotkeys hotkeys;
        public GCPad gcPad;
        public Wiimote wiimote;

        private uint[] _packetNumber = new uint[4];

        public Packet() {
            hotkeys = new Hotkeys();
            gcPad = new GCPad();
            wiimote = new Wiimote();

            _packetNumber[0] = 0;
            _packetNumber[1] = 0;
            _packetNumber[2] = 0;
            _packetNumber[3] = 0;
        }

        public byte[] GetMessageBytes(int slot) {
            byte[] output = new byte[69];   // nice

            // Used for all slots
            _packetNumber[slot]++;
            output[0] = (byte)1;  // connected
            Array.Copy(BitConverter.GetBytes(_packetNumber[slot]), 0, output, 1, 4);

            switch (slot) {
                case 2:  // GCPad
                    int firstButtonData = 0;  // bitmask
                    firstButtonData += (gcPad.dPadLeft == 255 ? 128 : 0);
                    firstButtonData += (gcPad.dPadDown == 255 ? 64 : 0);
                    firstButtonData += (gcPad.dPadRight == 255 ? 32 : 0);
                    firstButtonData += (gcPad.dPadUp == 255 ? 16 : 0);
                    firstButtonData += 0;  // maps to Options button, unused
                    firstButtonData += 0;  // maps to R3, unusued
                    firstButtonData += 0;  // maps to L3, unused
                    firstButtonData += 0;  // maps to Share button, unused
                    output[5] = (byte)firstButtonData;

                    int secondButtonData = 0;  // bitmask
                    secondButtonData += (gcPad.yButton == 255 ? 128 : 0);
                    secondButtonData += (gcPad.bButton == 255 ? 64 : 0);
                    secondButtonData += (gcPad.aButton == 255 ? 32 : 0);
                    secondButtonData += (gcPad.xButton == 255 ? 16 : 0);
                    secondButtonData += (gcPad.zButton == 255 ? 8 : 0);
                    secondButtonData += 0;  // maps to L1, unused
                    secondButtonData += (gcPad.rightTrigger == 255 ? 2 : 0);
                    secondButtonData += (gcPad.leftTrigger == 255 ? 1 : 0);
                    output[6] = (byte)secondButtonData;

                    output[7] = gcPad.startButton;
                    output[8] = 0;  // maps to Touch button, unused
                    output[9] = gcPad.mainStickX;
                    output[10] = gcPad.mainStickY;
                    output[11] = gcPad.cStickX;
                    output[12] = gcPad.cStickY;
                    output[13] = gcPad.dPadLeft;
                    output[14] = gcPad.dPadDown;
                    output[15] = gcPad.dPadRight;
                    output[16] = gcPad.dPadUp;
                    output[17] = gcPad.yButton;
                    output[18] = gcPad.bButton;
                    output[19] = gcPad.aButton;
                    output[20] = gcPad.xButton;
                    output[21] = gcPad.zButton;
                    output[22] = 0;  // maps to L1, unused
                    output[23] = gcPad.leftTrigger;
                    output[24] = gcPad.rightTrigger;
                    
                    // 25 - 36 inclusive are for touch input, unused
                    // 36 - 69 inclusive are for motion input, unused
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
