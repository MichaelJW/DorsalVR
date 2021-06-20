using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Ruccho.GraphicsCapture;
using UnityEngine.InputSystem;
using YamlDotNet.Serialization;
using System.IO;
using YamlDotNet.RepresentationModel;
using Dorsal.Config;
using System.Diagnostics;

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

        foreach (DeviceConfig device in modeConfig["(common)"].devices) {
            GameObject container = new GameObject();
            container.name = device.type + " Container | " + device.id;
            Dorsal.Devices.DeviceTransformer transformer = container.AddComponent<Dorsal.Devices.DeviceTransformer>();
            transformer.TransformFromConfig(device);

            switch (device.mountTo) {
                case "head":
                    // It may be smarter here to have one GameObject per "mountable"
                    // i.e. one for "head", one for "left hand", one for "middle hand", etc.
                    // and then add this GO to that GO.
                    // This would be more efficient than making multiple GOs for each mountable,
                    // with each one having to do its own Update(), FixedUpdate(), BeforeRender().
                    GameObject mount = new GameObject();
                    mount.name = device.type + " Container Mount | " + device.id;
                    mount.AddComponent<Dorsal.Devices.DeviceMounter>();
                    container.transform.parent = mount.transform;
                    break;
                default:
                    break;
            }
            
            if (device.type == "Screen") {
                Dorsal.Devices.Screen screen = container.AddComponent<Dorsal.Devices.Screen>();
                screen.ID = device.id;
                deviceManager.devices.Add(screen);
                
                screen.Instantiate();
                screen.SetSBS3D(device.stereoscopic == "sbs");
            }   
        }

        if (modeConfig["(common)"].dolphinConfig.exePath != null) {
            Dorsal.Processes.ProcessManager processManager = GameObject.Find("ProcessManager").GetComponent<Dorsal.Processes.ProcessManager>();
            Dorsal.Processes.DolphinProcess dp = processManager.StartDolphinProcess(
                modeConfig["(common)"].dolphinConfig
            );
            if (modeConfig["(common)"].dolphinConfig.outputGameTo.Count > 0) {
                foreach (string output in modeConfig["(common)"].dolphinConfig.outputGameTo) {

                    Dorsal.Devices.Screen dolphinGameScreen = deviceManager.devices.OfType<Dorsal.Devices.Screen>()
                                                                .Where<Dorsal.Devices.Screen>(
                                                                    t => t.ID == output
                                                                ).FirstOrDefault();
                    if (dolphinGameScreen != null) {
                        dolphinGameScreen.SetHwndViaDelegate(dp.GetGameHWnd);
                    }
                }
            }
            //UnityEngine.Debug.Log(string.Format("Process info: {0} {1} {2} {3} {4}", p.Id, p.Handle, p.MainWindowHandle, p.HandleCount, p.Container));
        }

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
