using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class DSUServer
{
    private uint serverId;
    private int serverPort;

    private bool serverIsRunning = false;
    private Socket socket;
    private byte[] buffer = new byte[1024];
    private IPEndPoint[] slotEndPoints;

    private NullFX.Security.Crc32 crc32 = new NullFX.Security.Crc32();

    private byte[] baseInfoMessage;
    private byte[] baseDataMessage;

    private enum MessageType {
        VersionInfo = 0x100000,
        ControllerMetaInfo = 0x100001,
        ActualControllerData = 0x100002
    };

    public void StartServer(int _serverPort) {
        EndServer();

        serverPort = _serverPort;
        var r = new System.Random();
        serverId = (uint)r.Next();

        slotEndPoints = new IPEndPoint[4];
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(new IPEndPoint(IPAddress.Loopback, serverPort));
        serverIsRunning = true;

        Debug.Log(string.Format("Server running on port: {0}", serverPort));

        StartListening();
    }

    private void StartListening() {
        try {
            if (serverIsRunning) {
                EndPoint clientEP = new IPEndPoint(IPAddress.Loopback, 0);
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref clientEP, ReceiveMessage, socket);
            }
        } catch (SocketException) {
            Debug.Log("Caught SocketException");
        }
    }

    private void ReceiveMessage(IAsyncResult ar) {
        EndPoint clientEP = new IPEndPoint(IPAddress.Loopback, 0);

        Socket receiveSocket = (Socket)ar.AsyncState;
        int length = receiveSocket.EndReceiveFrom(ar, ref clientEP);
        byte[] message = new byte[length];
        Array.Copy(buffer, message, length);

        // Listening will have stopped, so we start again now that we've copied the message from the buffer
        StartListening();

        ProcessMessage(message, (IPEndPoint)clientEP);
    }

    private void ProcessMessage(byte[] message, IPEndPoint clientEP) {
        int numPortsSupported = 4;

        if (System.Text.Encoding.UTF8.GetString(message, 0, 4) != "DSUC") return;
        int port;

        uint messageType = BitConverter.ToUInt32(message, 16);
        if (messageType == (uint)MessageType.ControllerMetaInfo) {
            int numPortsRequested = BitConverter.ToInt32(message, 20);
            Debug.Log(string.Format("INFO requested:\t{0} port(s)", numPortsRequested));

            for (int i = 0; i < numPortsRequested; i++) {
                port = (int)message[24 + i];
                if (port >= numPortsSupported | port < 0) {
                    Debug.Log(string.Format("Port {0} out of range.", port));
                } else {
                    Debug.Log(string.Format("Sending info for controller in port {0}", port));
                    SendMessage(GetInfoBytes(port), clientEP);
                }
            }
        } else if (messageType == (uint)MessageType.ActualControllerData) {
            Debug.Log(
                string.Format("DATA requested: {0}\tSlot requested: {1}\tMAC requested: {2}\tPort: {3}",
                message[20], message[21], BitConverter.ToString(message, 22, 6), clientEP.Port)
            );
            if (message[20] == 1) {  // wants controllers by slot
                slotEndPoints[(int)message[21]] = clientEP;
            } else if (message[20] == 0) {  // wants all controllers
                for (int i = 0; i < numPortsSupported; i++) {
                    slotEndPoints[i] = clientEP;
                }
            }
        } else {
            Debug.Log(string.Format("Did not recognise request: {0}", BitConverter.ToString(message)));
        }
    }

    private void SendMessage(byte[] message, IPEndPoint clientEP) {
        //Debug.Log(string.Format("Sending message to {2}:{1}: {0}", System.BitConverter.ToString(message), clientEP.Port, clientEP.Address));
        socket.SendTo(message, clientEP);
    }

    public void EndServer() {
        serverIsRunning = false;

        if (socket != null) {
            socket.Close();
            socket = null;
        }
    }

    private byte[] GetInfoBytes(int slot) {
        if (baseInfoMessage == null) {
            baseInfoMessage = new byte[32];

            // Header

            baseInfoMessage[0] = (byte)'D';
            baseInfoMessage[1] = (byte)'S';
            baseInfoMessage[2] = (byte)'U';
            baseInfoMessage[3] = (byte)'S';
            int index = 4;

            Array.Copy(BitConverter.GetBytes((ushort)1001), 0, baseInfoMessage, index, 2);
            index += 2;
            Array.Copy(BitConverter.GetBytes((ushort)16), 0, baseInfoMessage, index, 2);
            index += 2;
            Array.Clear(baseInfoMessage, index, 4);  // CRC will go here
            index += 4;
            Array.Copy(BitConverter.GetBytes(serverId), 0, baseInfoMessage, index, 4);
            index += 4;
            Array.Copy(BitConverter.GetBytes((uint)MessageType.ControllerMetaInfo), 0, baseInfoMessage, index, 4);
            index += 4;

            // Controller Info

            baseInfoMessage[index++] = (byte)0;  // slot / port - blank for now
            baseInfoMessage[index++] = (byte)2;  // slot state = connected
            baseInfoMessage[index++] = (byte)2;  // device model = full gyro
            baseInfoMessage[index++] = (byte)0;  // connection type = not applicable
            Array.Copy(new byte[6], 0, baseInfoMessage, index, 6);  // mac address; leave blank
            index += 6;
            baseInfoMessage[index++] = (byte)0;  // battery status = not applicable
            baseInfoMessage[index++] = (byte)'\0';  // required by protocol
        }

        byte[] output = new byte[32];
        Array.Copy(baseInfoMessage, output, 32);
        output[20] = (byte)slot;
        Array.Copy(crc32.ComputeChecksumBytes(output), 0, output, 8, 4);

        return output;
    }

    public void SendDataBytes(int slot, byte[] data) {
        if (slotEndPoints[slot] != null) {
            if (baseDataMessage == null) {
                baseDataMessage = new byte[31];

                // Header

                baseDataMessage[0] = (byte)'D';
                baseDataMessage[1] = (byte)'S';
                baseDataMessage[2] = (byte)'U';
                baseDataMessage[3] = (byte)'S';
                int index = 4;

                Array.Copy(BitConverter.GetBytes((ushort)1001), 0, baseDataMessage, index, 2);
                index += 2;
                Array.Copy(BitConverter.GetBytes((ushort)84), 0, baseDataMessage, index, 2);
                index += 2;
                Array.Clear(baseDataMessage, index, 4);  // CRC will go here
                index += 4;
                Array.Copy(BitConverter.GetBytes(serverId), 0, baseDataMessage, index, 4);
                index += 4;
                Array.Copy(BitConverter.GetBytes((uint)MessageType.ActualControllerData), 0, baseDataMessage, index, 4);
                index += 4;

                // Controller Info

                baseDataMessage[index++] = (byte)0;  // slot / port - blank for now
                baseDataMessage[index++] = (byte)2;  // slot state = connected
                baseDataMessage[index++] = (byte)2;  // device model = full gyro
                baseDataMessage[index++] = (byte)0;  // connection type = not applicable
                Array.Copy(new byte[6], 0, baseDataMessage, index, 6);  // mac address; leave blank
                index += 6;
                baseDataMessage[index++] = (byte)0;  // battery status = not applicable
                // No need for a zero byte here
            }

            // Add header and info to output; add actual controller data; set the slot; apply CRC32
            byte[] output = new byte[100];
            Array.Copy(baseDataMessage, output, 31);
            output[20] = (byte)slot;
            Array.Copy(data, 0, output, 31, 69);
            Array.Copy(crc32.ComputeChecksumBytes(output), 0, output, 8, 4);

            // Send the whole packet
            SendMessage(output, slotEndPoints[slot]);
        }
    }
}
