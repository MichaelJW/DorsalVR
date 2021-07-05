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
    DolphinConfigManager dolphinConfigManager;

    void OnEnable() {
        deviceManager = GameObject.FindObjectOfType<Dorsal.Devices.DeviceManager>();

        string yamlFile = "default.yaml";

        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg.StartsWith("--yaml=")) yamlFile = arg.Substring(7);
        }

        ConfigLoader.TryPopulateExampleYamls();

        Dictionary<string, Config> modeConfig = ConfigLoader.ParseYamlFile(yamlFile);
        if (modeConfig == null) {
            // The yaml was empty - open the dir to make it easier for the user, and quit
            Process.Start(ConfigLoader.yamlDirectory);
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
            return;  // it still gets to the next line otherwise
        }

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

            switch (device.type.ToLower()) {
                case "screen":
                    Dorsal.Devices.Screen screen = container.AddComponent<Dorsal.Devices.Screen>();
                    screen.ID = device.id;
                    deviceManager.devices.Add(screen);

                    screen.Instantiate();
                    screen.SetSBS3D(device.stereoscopic == "sbs");
                    break;
                case "imu":
                    Dorsal.Devices.IMU imu = deviceManager.devices.OfType<Dorsal.Devices.IMU>().FirstOrDefault(d => d.ID == device.id);
                    if (imu == null) {
                        imu = InputSystem.AddDevice<Dorsal.Devices.IMU>(device.id);
                        imu.ID = device.id;

                        deviceManager.devices.Add(imu);
                        InputSystem.EnableDevice(imu);
                    }

                    if (device.bindings.ContainsKey("position")) {
                        InputAction positionAction = new InputAction();
                        positionAction.AddBinding(device.bindings["position"]);
                        imu.positionAction = positionAction;
                    }
                    if (device.bindings.ContainsKey("rotation")) {
                        InputAction rotationAction = new InputAction();
                        rotationAction.AddBinding(device.bindings["rotation"]);
                        imu.rotationAction = rotationAction;
                    }
                    break;
                default:
                    UnityEngine.Debug.Log($"Unrecognised Device type: {device.type}");
                    break;
            }
        }

        if (modeConfig["(common)"].dolphinConfig.exePath != null && modeConfig["(common)"].dolphinConfig.configDir != null) {
            dolphinConfigManager = new DolphinConfigManager();
            dolphinConfigManager.dolphinConfigDirectory = modeConfig["(common)"].dolphinConfig.configDir;
            dolphinConfigManager.SetControlINIs();
            dolphinConfigManager.SetDSUClientINI();
            dolphinConfigManager.ModifyKeyOptions();

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

            DolphinControls dolphinControls = new DolphinControls();
            foreach (string actionMap in modeConfig["(common)"].controlsConfig.controls.Keys) {
                foreach (string action in modeConfig["(common)"].controlsConfig.controls[actionMap].mapping.Keys) {
                    foreach (ControlBinding binding in modeConfig["(common)"].controlsConfig.controls[actionMap].mapping[action]) {
                        dolphinControls.asset.FindActionMap(actionMap).FindAction(action).AddBinding(binding.path)
                            .WithProcessors(binding.processors)
                            .WithInteractions(binding.interactions);
                    }
                }
            }

            GameObject dolphinOutput = new GameObject();
            dolphinOutput.name = "Dolphin Output";
            dolphinOutput.AddComponent<DolphinOutput>();
            dolphinOutput.GetComponent<DolphinOutput>().SetControls(dolphinControls);
            DolphinOutput.WiimoteExtension extension = DolphinOutput.WiimoteExtension.None;
            switch (modeConfig["(common)"].dolphinConfig.extension.ToLower()) {
                case "nunchuk":
                case "nunchuck":  // anticipate typos!
                    extension = DolphinOutput.WiimoteExtension.Nunchuk;
                    break;
                case "":
                case "none":
                default:
                    extension = DolphinOutput.WiimoteExtension.None;
                    break;
            }
            dolphinOutput.GetComponent<DolphinOutput>().selectedExtension = extension;
        }
    }

    void OnDisable() {
        if (dolphinConfigManager != null) {
            dolphinConfigManager.TryRestoreAllBackups();
        }
    }
}
