using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldDSU {
    // DSU code modifed from https://github.com/iwubcode/OpenTrackDSUServer
    public enum MessageType {
        VersionInfo = 0x100000,
        ControllerMetaInfo = 0x100001,
        ActualControllerData = 0x100002
    };

    public class Header {
        public string identifier = "DSUS";
        public ushort protocolVersion = 1001;
        public ushort fullPacketSize;
        public uint crcValue;
        public uint serverId;
        public uint messageType;

        public static uint packetSize = 4;
        public static uint byteSize = 20;
    };

    public class ControllerInfo {
        public byte slot;
        public byte slotState;
        public byte deviceModel;
        public byte connectionType;
        public byte[] macAddress;
        public byte batteryStatus;
        // Don't forget we also need a zero byte per controller

        public static uint packetSize = 12;
        public static uint byteSize = 12;

        public ControllerInfo(byte _slot) {
            slot = _slot;
            // Protocol says to send zeroed out controller if slot is empty
            ZeroOut();
        }

        public void ZeroOut() {
            slotState = 0;
            deviceModel = 0;
            connectionType = 0;
            macAddress = new byte[6];
            batteryStatus = 0;
        }

        public void SetGoodDefaults() {
            slotState = 2;  // connected
            deviceModel = 2;  // full gyro
            connectionType = 0;  // not applicable
            macAddress = new byte[6];
            batteryStatus = 0;  // not applicable
        }
    };

    public class ControllerTouchData {
        public bool isTouchActive = false;
        public byte touchID = 0;
        public ushort xPos = 0;
        public ushort yPos = 0;

        public static uint packetSize = 6;
        public static uint byteSize = 6;
    };

    public class ControllerData {
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

        public static uint packetSize = 69;
        public static uint byteSize = 69;
    };

    public class DSUDevice {
        public DSUDeviceManager manager;

        private Header header;
        private ControllerInfo controllerInfo;
        private ControllerData controllerData;

        private OldDorsalDevice _motionDevice;
        public OldDorsalDevice motionDevice {
            get { return _motionDevice; }
            set { _motionDevice = value; _motionDevice.callbackDSUDevice = this; }
        }
        public OldDorsalDevice buttonDevice;
        public OldDorsalDevice pointerDevice;

        private float minTimeBetweenPackets = 0.1f; // seconds
        private uint serverId;
        private NullFX.Security.Crc32 crc32;

        public DSUDevice(byte _slot, uint _serverId = (uint)0) {
            crc32 = new NullFX.Security.Crc32();
            serverId = _serverId;

            header = new Header();
            controllerInfo = new ControllerInfo(_slot);
            controllerData = new ControllerData();

            header.serverId = _serverId;
            controllerInfo.SetGoodDefaults();
        }

        public void SetServerId(uint _serverId) {
            serverId = _serverId;
            header.serverId = serverId;
        }

        public void UpdateFromDorsalDevice() {
            Int64 timeSinceLastPacket;

            if (motionDevice != null) {
                timeSinceLastPacket = motionDevice.lastTimestamp - controllerData.motionTimestamp;
            } else {
                timeSinceLastPacket = (Int64)(Time.realtimeSinceStartup * 1000000) - controllerData.motionTimestamp;
            }
            if (timeSinceLastPacket < minTimeBetweenPackets) {
                return;
            }

            if (motionDevice != null) {
                controllerData.motionTimestamp = motionDevice.lastTimestamp;
                controllerData.accelerometerX = motionDevice.accelerometer.x;
                controllerData.accelerometerY = motionDevice.accelerometer.y;
                controllerData.accelerometerZ = motionDevice.accelerometer.z;
                controllerData.gyroPitchRate = motionDevice.gyroscopeRate.x;
                controllerData.gyroYawRate = motionDevice.gyroscopeRate.y;
                controllerData.gyroRollRate = motionDevice.gyroscopeRate.z;
            } else {
                controllerData.motionTimestamp = (Int64)(Time.realtimeSinceStartup * 1000000);
            }
            if (buttonDevice != null) {
                controllerData.aButton = buttonDevice.primaryButton;
                controllerData.analogAButton = (byte)(buttonDevice.primaryButton ? 255 : 0);
                controllerData.bButton = buttonDevice.secondaryButton;
                controllerData.analogBButton = (byte)(buttonDevice.secondaryButton ? 255 : 0);
                controllerData.l1Button = buttonDevice.gripButton;
                controllerData.analogL1Button = (byte)(buttonDevice.grip * 255);
                controllerData.l2Button = buttonDevice.triggerButton;
                controllerData.analogL2Button = (byte)(buttonDevice.trigger * 255);
                controllerData.analogBButton = (byte)(buttonDevice.secondaryButton ? 255 : 0);
                controllerData.leftStickX = (byte)((buttonDevice.primary2DAxis.x * 127.5) + 128);
                controllerData.leftStickY = (byte)((buttonDevice.primary2DAxis.y * 127.5) + 128);
                controllerData.l3Button = buttonDevice.primary2DAxisClick;
            }
            if (pointerDevice != null) {
                Vector2 screenPoint = pointerDevice.GetScreenPoint();
                float pointX = screenPoint.x * 4;
                controllerData.analogDpadLeft = (byte)Math.Max((pointX >= 1 ? 255 : pointX * 255), 0);
                controllerData.analogDpadRight = (byte)Math.Max((pointX >= 2 ? 255 : (pointX - 1) * 255), 0);
                controllerData.analogL1Button = (byte)Math.Max((pointX >= 3 ? 255 : (pointX - 2) * 255), 0);
                controllerData.analogL2Button = (byte)Math.Max((pointX >= 4 ? 255 : (pointX - 3) * 255), 0);
                
                float pointY = screenPoint.y * 4;
                controllerData.analogDpadUp = (byte)Math.Max((pointY >= 1 ? 255 : pointY * 255), 0);
                controllerData.analogDpadDown = (byte)Math.Max((pointY >= 2 ? 255 : (pointY - 1) * 255), 0);
                controllerData.analogR1Button = (byte)Math.Max((pointY >= 3 ? 255 : (pointY - 2) * 255), 0);
                controllerData.analogR2Button = (byte)Math.Max((pointY >= 4 ? 255 : (pointY - 3) * 255), 0);
            }
            controllerData.packetNumber++;
            manager.DeviceUpdated(this);
        }

        public void FixedUpdate() {
            // Better for latency if this is triggered by motion data
            // but if there's no motion device linked then we'll trigger it here
            if (motionDevice == null) {
                UpdateFromDorsalDevice();
            }
        }

        public byte[] GetInfoBytes() {
            byte[] output = new byte[Header.byteSize + ControllerInfo.byteSize];
            Header header = new Header();
            header.fullPacketSize = (ushort)(Header.packetSize + ControllerInfo.packetSize);
            header.messageType = (uint)MessageType.ControllerMetaInfo;

            int index = 0;

            // Header

            output[index++] = (byte)header.identifier[0];
            output[index++] = (byte)header.identifier[1];
            output[index++] = (byte)header.identifier[2];
            output[index++] = (byte)header.identifier[3];

            Array.Copy(BitConverter.GetBytes(header.protocolVersion), 0, output, index, 2);
            index += 2;
            Array.Copy(BitConverter.GetBytes(header.fullPacketSize), 0, output, index, 2);
            index += 2;
            Array.Clear(output, index, 4);  // CRC will go here
            index += 4;
            Array.Copy(BitConverter.GetBytes(header.serverId), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(header.messageType), 0, output, index, 4);
            index += 4;

            // Controller info

            output[index++] = controllerInfo.slot;
            output[index++] = controllerInfo.slotState;
            output[index++] = controllerInfo.deviceModel;
            output[index++] = controllerInfo.connectionType;
            Array.Copy(controllerInfo.macAddress, 0, output, index, 6);
            index += 6;
            output[index++] = controllerInfo.batteryStatus;
            output[index++] = (byte)'\0';

            // End

            byte[] checksum = crc32.ComputeChecksumBytes(output);
            Array.Copy(checksum, 0, output, 8, 4);

            return output;
        }

        public byte[] GetDataBytes() {
            byte[] output = new byte[Header.byteSize + (ControllerInfo.byteSize - 1) + ControllerData.byteSize];  // -1 because zero byte is not needed
            Header header = new Header();
            header.fullPacketSize = (ushort)(Header.packetSize + (ControllerInfo.packetSize - 1) + ControllerData.packetSize);
            header.messageType = (uint)MessageType.ActualControllerData;

            int index = 0;

            // Header

            output[index++] = (byte)header.identifier[0];
            output[index++] = (byte)header.identifier[1];
            output[index++] = (byte)header.identifier[2];
            output[index++] = (byte)header.identifier[3];

            Array.Copy(BitConverter.GetBytes(header.protocolVersion), 0, output, index, 2);
            index += 2;
            Array.Copy(BitConverter.GetBytes(header.fullPacketSize), 0, output, index, 2);
            index += 2;
            Array.Clear(output, index, 4);  // CRC will go here
            index += 4;
            Array.Copy(BitConverter.GetBytes(header.serverId), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(header.messageType), 0, output, index, 4);
            index += 4;

            // Controller info

            output[index++] = controllerInfo.slot;
            output[index++] = controllerInfo.slotState;
            output[index++] = controllerInfo.deviceModel;
            output[index++] = controllerInfo.connectionType;
            Array.Copy(controllerInfo.macAddress, 0, output, index, 6);
            index += 6;
            output[index++] = controllerInfo.batteryStatus;
            // Don't need the zero byte in this case

            // Controller data 

            output[index++] = controllerData.controllerConnected;
            Array.Copy(BitConverter.GetBytes(controllerData.packetNumber), 0, output, index, 4);
            index += 4;

            // Button / D-pad / Stick data

            int firstButtonData = 0;
            firstButtonData += (controllerData.dpadLeft ? 128 : 0);
            firstButtonData += (controllerData.dpadUp ? 64 : 0);
            firstButtonData += (controllerData.dpadRight ? 32 : 0);
            firstButtonData += (controllerData.dpadUp ? 16 : 0);
            firstButtonData += (controllerData.optionsButton ? 8 : 0);
            firstButtonData += (controllerData.r3Button ? 4 : 0);
            firstButtonData += (controllerData.l3Button ? 2 : 0);
            firstButtonData += (controllerData.shareButton ? 1 : 0);
            output[index++] = (byte)firstButtonData;

            int secondButtonData = 0;
            secondButtonData += (controllerData.yButton ? 128 : 0);
            secondButtonData += (controllerData.bButton ? 64 : 0);
            secondButtonData += (controllerData.aButton ? 32 : 0);
            secondButtonData += (controllerData.xButton ? 16 : 0);
            secondButtonData += (controllerData.r1Button ? 8 : 0);
            secondButtonData += (controllerData.l1Button ? 4 : 0);
            secondButtonData += (controllerData.r2Button ? 2 : 0);
            secondButtonData += (controllerData.l2Button ? 1 : 0);
            output[index++] = (byte)secondButtonData;

            output[index++] = controllerData.psButton;  // unused according to protocol
            output[index++] = controllerData.touchButton;  // unused according to protocol
            output[index++] = controllerData.leftStickX;
            output[index++] = controllerData.leftStickY;
            output[index++] = controllerData.rightStickX;
            output[index++] = controllerData.rightStickY;
            output[index++] = controllerData.analogDpadLeft;
            output[index++] = controllerData.analogDpadDown;
            output[index++] = controllerData.analogDpadRight;
            output[index++] = controllerData.analogDpadUp;
            output[index++] = controllerData.analogYButton;
            output[index++] = controllerData.analogBButton;
            output[index++] = controllerData.analogAButton;
            output[index++] = controllerData.analogXButton;
            output[index++] = controllerData.analogR1Button;
            output[index++] = controllerData.analogL1Button;
            output[index++] = controllerData.analogR2Button;
            output[index++] = controllerData.analogL2Button;

            // Touch data

            output[index++] = (byte)(controllerData.firstTouch.isTouchActive ? 1 : 0);
            output[index++] = controllerData.firstTouch.touchID;
            Array.Copy(BitConverter.GetBytes(controllerData.firstTouch.xPos), 0, output, index, 2);
            index += 2;
            Array.Copy(BitConverter.GetBytes(controllerData.firstTouch.yPos), 0, output, index, 2);
            index += 2;

            output[index++] = (byte)(controllerData.secondTouch.isTouchActive ? 1 : 0);
            output[index++] = controllerData.secondTouch.touchID;
            Array.Copy(BitConverter.GetBytes(controllerData.secondTouch.xPos), 0, output, index, 2);
            index += 2;
            Array.Copy(BitConverter.GetBytes(controllerData.secondTouch.yPos), 0, output, index, 2);
            index += 2;

            // Motion data

            Array.Copy(BitConverter.GetBytes(controllerData.motionTimestamp), 0, output, index, 8);
            index += 8;
            Array.Copy(BitConverter.GetBytes(controllerData.accelerometerX), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(controllerData.accelerometerY), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(controllerData.accelerometerZ), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(controllerData.gyroPitchRate), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(controllerData.gyroRollRate), 0, output, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes(controllerData.gyroYawRate), 0, output, index, 4);
            index += 4;

            // End

            byte[] checksum = crc32.ComputeChecksumBytes(output);
            Array.Copy(checksum, 0, output, 8, 4);

            return output;
        }
    }
}