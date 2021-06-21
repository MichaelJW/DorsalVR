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
    Dorsal.Devices.DeviceManager deviceManager;

    // Start is called before the first frame update
    void Start()
    {
        deviceManager = GameObject.FindObjectOfType<Dorsal.Devices.DeviceManager>();

        string yamlFile = "";

        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg.StartsWith("--yaml=")) yamlFile = arg.Substring(7);
        }

        #if (UNITY_EDITOR)
        yamlFile = "C:\\Emu\\DorsalVR\\config\\tester.yaml";
        #endif

        // Later we will allow choosing this via UI, but for now, just quit
        if (!File.Exists(yamlFile)) {
            Application.Quit();
        }

        Dictionary<string, Config> modeConfig = ConfigLoader.ParseYamlFile(yamlFile);

        foreach (DeviceConfig device in modeConfig["(common)"].devices) {
            GameObject container = new GameObject();
            container.name = device.type + " Container | " + device.id;
            Dorsal.Devices.DeviceTransformer transformer = container.AddComponent<Dorsal.Devices.DeviceTransformer>();
            transformer.TransformFromConfig(device);

            switch (device.mountTo.ToLower().Replace(" ", "")) {
                case "head":
                    container.transform.parent = GameObject.Find("Head Mount").transform;
                    break;
                case "lefthand":
                    container.transform.parent = GameObject.Find("Left Hand Mount").transform;
                    break;
                case "righthand":
                    container.transform.parent = GameObject.Find("Right Hand Mount").transform;
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

            GameObject dolphinOutput = new GameObject();
            dolphinOutput.name = "Dolphin Output";
            dolphinOutput.AddComponent<DolphinOutput>();
        }

        //GameObject.Find("IO").GetComponent<IO>().StartServer(serverPort);
    }
}
