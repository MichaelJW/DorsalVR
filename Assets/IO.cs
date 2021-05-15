using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using OldDSU;
using System;

public class IO : MonoBehaviour
{
    private uint serverId;
    private int serverPort;

    private bool serverIsRunning = false;
    private Socket socket;
    private byte[] buffer = new byte[1024];
    private IPEndPoint[] slotEndPoints;
    private DateTime lastDataRequestedAt;
    private bool dataHasBeenRequested = false;

    [SerializeField]
    DSUDeviceManager dsuDeviceManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartServer(int _serverPort) {
        EndServer();

        serverPort = _serverPort;
        var r = new System.Random();
        serverId = (uint)r.Next();
        dsuDeviceManager.SetServerId(serverId);
        dsuDeviceManager.SetIO(this);

        slotEndPoints = new IPEndPoint[4];
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(new IPEndPoint(IPAddress.Loopback, serverPort));
        serverIsRunning = true;
        lastDataRequestedAt = System.DateTime.Now;
        Debug.Log("Server is running.");
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
        if (System.Text.Encoding.UTF8.GetString(message, 0, 4) != "DSUC") return;
        int port;

        uint messageType = BitConverter.ToUInt32(message, 16);
        if (messageType == (uint)MessageType.ControllerMetaInfo) {
            int numPortsRequested = BitConverter.ToInt32(message, 20);
            Debug.Log(string.Format("INFO requested:\t{0} port(s)", numPortsRequested));

            for (int i = 0; i < numPortsRequested; i++) {
                port = (int)message[24 + i];
                if (port >= dsuDeviceManager.GetNumDevices() | port < 0) {
                    Debug.Log(string.Format("Port {0} out of range.", port));
                } else {
                    Debug.Log(string.Format("Sending info for controller in port {0}", port));
                    SendMessage(dsuDeviceManager.GetInfoBytes(port), clientEP);
                }
            }
        } else if (messageType == (uint)MessageType.ActualControllerData) {
            Debug.Log(
                string.Format("DATA requested: {0}\tSlot requested: {1}\tMAC requested: {2}\tPort: {3}",
                message[20], message[21], BitConverter.ToString(message, 22, 6), clientEP.Port)
            );
            lastDataRequestedAt = System.DateTime.Now;
            dataHasBeenRequested = true;
            if (message[20] == 1 || message[20] == 0) {  // wants controllers by slot
                slotEndPoints[(int)message[21]] = clientEP;
            }
        } else {
            Debug.Log(string.Format("Did not recognise request: {0}", BitConverter.ToString(message)));
        }
    }

    private void SendMessage(byte[] message, IPEndPoint clientEP) {
        socket.SendTo(message, clientEP);
    }

    public void DataIsUpdated(int slot) {
        if (slotEndPoints[slot] is IPEndPoint) {
            SendMessage(dsuDeviceManager.GetDataBytes(slot), slotEndPoints[slot]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dataHasBeenRequested & System.DateTime.Now - lastDataRequestedAt > TimeSpan.FromSeconds(2)) {
            Debug.Log("Time has passed since last data request. Restarting server...");
            StartServer(serverPort);
        }
    }

    private void EndServer() {
        serverIsRunning = false;

        if (socket != null) {
            socket.Close();
            socket = null;
        }

        Debug.Log("Server has stopped.");
    }

    // OnDestroy is called after all frame updates for the last frame of the object’s existence
    private void OnDestroy() {
        EndServer();
    }
}
