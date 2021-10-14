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
using UnityEngine.InputSystem.XR;
using MoonSharp.Interpreter;
using Dorsal.External.Dolphin;

public class SettingsManager : MonoBehaviour
{
    Dorsal.Devices.DeviceManager deviceManager;
    DolphinConfigManager dolphinConfigManager;

    private void OnEnable() {
        DolphinManager dolphinManager = this.GetComponent<DolphinManager>();

        string luaScript = "dolphinManager:launch(\"C:\\\\Emu\\\\Dolphin\\\\Dolphin.exe\", \"C:\\\\Users\\\\micha\\\\Documents\\\\Dolphin Emulator\\\\Config\\\\\");";
        UserData.RegisterAssembly();  // Registers everything with a [MoonSharpUserData] attrib
        UserData.RegisterProxyType<DolphinManagerProxy, DolphinManager>(r => new DolphinManagerProxy(dolphinManager));
        Script script = new Script();
        script.Globals["dolphinManager"] = dolphinManager;
        UnityEngine.Debug.Log(luaScript);
        DynValue res = script.DoString(luaScript);
    }

    void old_yaml_based_OnEnable() {
        #if !(DEVELOPMENT_BUILD || UNITY_EDITOR)
        UnityEngine.Debug.unityLogger.filterLogType = LogType.Exception;
        #endif

        deviceManager = GameObject.FindObjectOfType<Dorsal.Devices.DeviceManager>();

        string yamlFile = "default.yaml";

        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg.StartsWith("--yaml=")) yamlFile = arg.Substring(7);
        }

        UnityEngine.Debug.Log("Starting up...");
        UnityEngine.Debug.Log($"DorsalVR version is: {Application.version}");
        UnityEngine.Debug.Log($"Operating System is: {SystemInfo.operatingSystem}");
        UnityEngine.Debug.Log($"YAML path is: {yamlFile}");

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


        UnityEngine.Debug.Log($"Native C#: {modeConfig["(common)"].dolphinConfig.exePath}");
        string scriptCode = @"
            return obj.exePath;
        ";
        UserData.RegisterAssembly();  // Registers everything with a [MoonSharpUserData] attrib
        Script script = new Script();
        DynValue obj = UserData.Create(modeConfig["(common)"].dolphinConfig);
        script.Globals.Set("obj", obj);
        DynValue res = script.DoString(scriptCode);
        UnityEngine.Debug.Log($"MoonSharp Test: {res.String}");

        string scriptCode2 = @"
            obj.exePath = 'C:\\Windows\\Notepad.exe';
        ";
        script.DoString(scriptCode2);
        UnityEngine.Debug.Log($"Attempted to change exePath via MoonSharp...");
        UnityEngine.Debug.Log($"Native C#: {modeConfig["(common)"].dolphinConfig.exePath}");

        // Above works! That's promising...

        string scriptCode3 = @"
            return obj.config['Graphics.Stereoscopy.StereoMode'];
        ";
        res = script.DoString(scriptCode3);
        UnityEngine.Debug.Log($"MoonSharp Test for StereoMode: {res.String}");
        // Can access elements of a Dictionary by a string key too then



        foreach (DeviceConfig device in modeConfig["(common)"].devices) {
            UnityEngine.Debug.Log($"Attempting to load {modeConfig["(common)"].devices.Count} Devices...");
            GameObject container = new GameObject();
            container.name = device.type + " Container | " + device.id;
            Dorsal.Devices.DeviceTransformer transformer = container.AddComponent<Dorsal.Devices.DeviceTransformer>();
            transformer.TransformFromConfig(device);

            GameObject mount = new GameObject();
            mount.name = device.type + " Mount | " + device.id;
            TrackedPoseDriver tpd = mount.AddComponent<TrackedPoseDriver>();
            
            if (device.vrEntityConfig.positionBinding != null) {
                tpd.positionAction = new InputAction();
                tpd.positionAction.AddBinding(
                    device.vrEntityConfig.positionBinding.path,
                    device.vrEntityConfig.positionBinding.interactions,
                    device.vrEntityConfig.positionBinding.processors
                );
                UnityEngine.Debug.Log(tpd.positionAction.bindings.Count);
            }
            if (device.vrEntityConfig.rotationBinding != null) {
                tpd.rotationAction = new InputAction();
                tpd.rotationAction.AddBinding(
                    device.vrEntityConfig.rotationBinding.path,
                    device.vrEntityConfig.rotationBinding.interactions,
                    device.vrEntityConfig.rotationBinding.processors
                );
            }
            container.transform.parent = mount.transform;
            mount.transform.parent = GameObject.Find("Mounts").transform;

            GameObject vrEntity = new GameObject();
            if (device.vrEntityConfig.model != null) {
                switch (device.vrEntityConfig.model.ToLower()) {
                    case "sphere":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        break;
                    case "capsule":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        break;
                    case "cylinder":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        break;
                    case "cube":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        break;
                    case "plane":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Plane);
                        break;
                    case "quad":
                        vrEntity = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        break;
                    default:
                        break;
                }
            }
            vrEntity.transform.parent = container.transform;
            vrEntity.transform.localScale = Vector3.one;

            switch (device.type.ToLower()) {
                case "screen":
                    Dorsal.Devices.Screen screen = container.AddComponent<Dorsal.Devices.Screen>();
                    screen.ID = device.id;
                    deviceManager.devices.Add(screen);

                    screen.Instantiate();
                    screen.SetSBS3D(device.screenConfig.stereoscopic == "sbs");
                    break;
                case "imu":
                    Dorsal.Devices.IMU imu = deviceManager.devices.OfType<Dorsal.Devices.IMU>().FirstOrDefault(d => d.ID == device.id);
                    if (imu == null) {
                        imu = InputSystem.AddDevice<Dorsal.Devices.IMU>(device.id);
                        imu.ID = device.id;

                        deviceManager.devices.Add(imu);
                        InputSystem.EnableDevice(imu);
                    }

                    if (device.imuConfig.positionBinding != null) {
                        InputAction positionAction = new InputAction();
                        positionAction.AddBinding(
                            device.imuConfig.positionBinding.path,
                            device.imuConfig.positionBinding.interactions,
                            device.imuConfig.positionBinding.processors
                        );
                        imu.positionAction = positionAction;
                    }
                    if (device.imuConfig.rotationBinding != null) {
                        InputAction rotationAction = new InputAction();
                        rotationAction.AddBinding(
                            device.imuConfig.rotationBinding.path,
                            device.imuConfig.rotationBinding.interactions,
                            device.imuConfig.rotationBinding.processors
                        );
                        imu.rotationAction = rotationAction;
                        imu.rotationOffset = device.imuConfig.rotationOffset;
                    }
                    break;
                default:
                    UnityEngine.Debug.Log($"Unrecognised Device type: {device.type}");
                    break;
            }
        }

        UnityEngine.Debug.Log($"Attempting to load Dolphin...");
        if (modeConfig["(common)"].dolphinConfig.exePath != null && modeConfig["(common)"].dolphinConfig.configDir != null) {
            UnityEngine.Debug.Log($"Dolphin exePath: {modeConfig["(common)"].dolphinConfig.exePath}");
            UnityEngine.Debug.Log($"Dolphin configDir: {modeConfig["(common)"].dolphinConfig.configDir}");

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
            } else {
                UnityEngine.Debug.Log($"No Dolphin output set!");
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

        if (modeConfig["(common)"].debugConfig != null && modeConfig["(common)"].debugConfig.bindings.Count > 0) {
            UnityEngine.UI.VerticalLayoutGroup debugLayout = GameObject.Find("Debug Layout").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();

            foreach (ControlBinding debugBinding in modeConfig["(common)"].debugConfig.bindings) {
                GameObject debugOutput = new GameObject();
                UnityEngine.UI.Text debugText = debugOutput.AddComponent<UnityEngine.UI.Text>();
                debugText.name = $"{debugBinding.path} debug output";
                debugText.color = new Color(0, 0, 0);
                debugText.font = Font.CreateDynamicFontFromOSFont("Arial", 18);

                debugText.rectTransform.SetParent(debugLayout.transform, false);
                debugText.text = debugBinding.path;

                InputAction debugAction = new InputAction();
                debugAction.AddBinding(debugBinding.path);
                debugAction.performed += DebugInputAction_Callback;
                debugAction.canceled += DebugInputAction_Callback;
                debugAction.started += DebugInputAction_Callback;
                debugAction.Enable();
            }
        } else {
            GameObject.Find("Debug Related").SetActive(false);
        }
    }

    private void DebugInputAction_Callback(InputAction.CallbackContext obj) {
        UnityEngine.Debug.Log($"DebugAction {obj.phase} {obj.action.bindings[0].path} {obj.ReadValueAsObject().ToString()}");
        UnityEngine.UI.Text debugText = GameObject.Find($"{obj.action.bindings[0].path} debug output").GetComponent<UnityEngine.UI.Text>();
        debugText.text = $"{obj.action.bindings[0].path}:\t{obj.ReadValueAsObject().ToString()}";
    }

    void OnDisable() {
        if (dolphinConfigManager != null) {
            dolphinConfigManager.TryRestoreAllBackups();
        }
    }
}
