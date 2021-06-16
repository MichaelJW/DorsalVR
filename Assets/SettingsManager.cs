using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Ruccho.GraphicsCapture;
using UnityEngine.InputSystem;
using YamlDotNet.Serialization;
using System.IO;
using YamlDotNet.RepresentationModel;
using Dorsal.Config;

public class SettingsManager : MonoBehaviour
{
    public bool sbs = false;
    public bool mountToHead = false;
    int serverPort = 26659;
    int angleX = 0;
    int angleY = 0;
    int angleZ = 0;

    [SerializeField]
    GameObject headMount;
    [SerializeField]
    GameObject room;
    [SerializeField]
    MirrorScreenTexture screen;

    Vector3 originalScreenPos;

    Dorsal.Devices.DeviceManager deviceManager;

    // Start is called before the first frame update
    void Start()
    {
        deviceManager = GameObject.FindObjectOfType<Dorsal.Devices.DeviceManager>();

        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg == "-sbs") sbs = true;
            if (arg == "-selfie") mountToHead = true;
            if (arg.StartsWith("-port=")) serverPort = int.Parse(arg.Substring(6));
            if (arg.StartsWith("-angleX=")) angleX = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleY=")) angleY = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleZ=")) angleZ = int.Parse(arg.Substring(7));
        }

        originalScreenPos = screen.transform.localPosition;

        ApplySettings();

        //InputSystem.AddDevice<SteeringWheel.SteeringWheelDorsalDevice>();
        Dictionary<string, Config> modeConfig = ConfigLoader.ParseYamlFile("C:\\Emu\\DorsalVR\\config\\MKDD.yaml");
        Debug.Log(modeConfig["(common)"].dolphinConfig.exePath);

        Debug.Log(deviceManager.devices.Count);

        foreach (DeviceConfig device in modeConfig["(common)"].devices) {
            if (device.type == "Screen") {
                GameObject screenContainer = new GameObject();
                screenContainer.name = "Screen Container";
                Dorsal.Devices.Screen screen = screenContainer.AddComponent<Dorsal.Devices.Screen>();
                screen.ID = device.id;
                screen.transform.position = device.offset;
                deviceManager.devices.Add(screen);
                screen.Instantiate();
            }
        }

        Debug.Log(deviceManager.devices.Count);

        //LoadFromYAML("C:\\Emu\\DorsalVR\\config\\MKDD.yaml");

        //GameObject.Find("IO").GetComponent<IO>().StartServer(serverPort);
    }

    public void SetSBS3D(bool isEnabled) {
        sbs = isEnabled;
    }

    public void SetMounttoHead(bool isEnabled) {
        mountToHead = isEnabled;
    }

    public void SetScreenSource(ICaptureTarget target) {
        screen.SetTarget(target);
    }

    public void ApplySettings() {
        screen.SetSBS3D(sbs);
        if (mountToHead) {
            room.SetActive(false);
            headMount.GetComponent<DorsalDriver>().deviceType = OldDorsalDevice.DeviceType.HMD;
            headMount.GetComponent<DorsalDriver>().ConnectToChosenDevice();
            screen.transform.localPosition = new Vector3(0, 0, 1.3f);
        } else {
            room.SetActive(true);
            headMount.GetComponent<DorsalDriver>().deviceType = OldDorsalDevice.DeviceType.Undefined;
            headMount.GetComponent<DorsalDriver>().ConnectToChosenDevice();
            headMount.transform.localPosition = Vector3.zero;
            headMount.transform.localRotation = Quaternion.identity;
            screen.transform.localPosition = originalScreenPos;
        }

        Quaternion relativeRotation = Quaternion.Euler((float)angleX, (float)angleY, (float)angleZ);
        GameObject.Find("DorsalDeviceManager").GetComponent<OldDorsalDeviceManager>().SetControllerRelativeRotations(relativeRotation);
    }
}
