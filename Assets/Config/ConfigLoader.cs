using System;
using System.Collections.Generic;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using System.IO;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Dorsal.Config {
    class ConfigLoader {
        public static string yamlDirectory = Path.Combine(Application.persistentDataPath, @"Config\");

        public static void TryPopulateExampleYamls() {
            if (!Directory.Exists(yamlDirectory)) {
                Directory.CreateDirectory(yamlDirectory);
            }
            if (!Directory.Exists(Path.Combine(yamlDirectory, "examples/"))) {
                Directory.CreateDirectory(Path.Combine(yamlDirectory, "examples/"));
            }

            string examplesPath = Path.Combine(Application.streamingAssetsPath, @"DorsalConfigs/");
            foreach (string yamlPath in Directory.GetFiles(examplesPath, "*.yaml")) {
                if (Path.GetFileName(yamlPath) == "default.yaml") {
                    // Create default if it doesn't exist; otherwise leave it alone in case user has changed it:
                    if (!File.Exists(Path.Combine(yamlDirectory, "default.yaml"))) {
                        File.Copy(yamlPath, Path.Combine(yamlDirectory, "default.yaml"));
                    }
                } else {
                    // OTOH, we want the examples to stay under the app's control:
                    File.Copy(yamlPath, Path.Combine(yamlDirectory, "examples/", Path.GetFileName(yamlPath)), overwrite: true);
                    //File.SetAttributes(Path.Combine(yamlDirectory, "/examples/", Path.GetFileName(yamlPath)), FileAttributes.ReadOnly);
                }
            }

            // While we're at it, copy any hyperlinks, too.
            foreach (string urlPath in Directory.GetFiles(examplesPath, "*.url")) {
                File.Copy(urlPath, Path.Combine(yamlDirectory, Path.GetFileName(urlPath)), overwrite: true);
            }
        }

        private static string GetYamlStringFromYamlFile(string givenYamlPath) {
            string yamlPath = givenYamlPath;

            if (Path.GetFullPath(yamlPath) != yamlPath) {
                // Assume then that yamlPath is relative
                yamlPath = Path.Combine(yamlDirectory, yamlPath);
            }

            string yamlString;
            try {
                yamlString = File.ReadAllText(yamlPath);
            } catch (Exception e) {
                Debug.LogError(e.Message);
                return null;
            }

            return yamlString;
        }

        public static Dictionary<string, Config> ParseYamlFile(string yamlPath) {
            string yamlString = GetYamlStringFromYamlFile(yamlPath);
            Debug.Log(yamlString);
            if (yamlString == null || yamlString == "") return null;
            return ParseYamlString(yamlString);
        }

        public static void ParseYamlFile(string yamlPath, Dictionary<string, Config> modeConfig) {
            string yamlString = GetYamlStringFromYamlFile(yamlPath);
            if (yamlString != null) ParseYamlString(yamlString, modeConfig);
        }

        // If no modeConfig is passed then we create one
        public static Dictionary<string, Config> ParseYamlString(string yamlString) {
            Dictionary<string, Config> modeConfig = new Dictionary<string, Config>();
            modeConfig["(common)"] = new Config();

            ParseYamlString(yamlString, modeConfig);
            return modeConfig;
        }

        // If a modeConfig is passed then we add to it
        public static void ParseYamlString(string yamlString, Dictionary<string, Config> modeConfig) {
            var ds = new DeserializerBuilder()
                .Build();

            var input = new StringReader(yamlString);
            var yaml = new YamlStream();
            yaml.Load(input);

            string currentMode;

            // We want to parse all the docs with the "common" mode first, then clone it for other modes, and modify the clones.
            // This way the other modes cascade from the common mode.
            foreach (bool doingCommonMode in new bool[] { true, false }) {
                foreach (YamlDocument doc in yaml.Documents) {
                    currentMode = "(common)";  // default if no mode is specified
                    YamlMappingNode docRoot = (YamlMappingNode)(doc.RootNode);

                    /// Imports
                    if (docRoot.Children.ContainsKey("imports")) {
                        foreach (YamlNode importNode in (YamlSequenceNode)docRoot.Children["imports"]) {
                            ParseYamlFile(importNode.ToString(), modeConfig);
                        }
                    }

                    /// Mode
                    if (docRoot.Children.ContainsKey("mode")) {
                        currentMode = docRoot.Children["mode"].ToString();
                    }
                    // Skip document if it's not (common) and we're currently only doing (common), or vice-versa
                    if ((currentMode == "(common)") != doingCommonMode) continue;

                    ParseSingleDocRoot(docRoot, currentMode, modeConfig);
                }

            }
        }

        public static void ParseSingleDocRoot(YamlMappingNode docRoot, string currentMode, Dictionary<string, Config> modeConfig) {
            if (!modeConfig.ContainsKey(currentMode)) {
                modeConfig[currentMode] = modeConfig["(common)"].Clone();
            }

            /// Dolphin
            if (docRoot.Children.ContainsKey("dolphin")) {
                YamlNode dolphinYaml = docRoot.Children["dolphin"];

                if (modeConfig[currentMode].dolphinConfig == null) {
                    modeConfig[currentMode].dolphinConfig = new DolphinConfig();
                }
                DolphinConfig dolphinConfig = modeConfig[currentMode].dolphinConfig;

                dolphinConfig.exePath = GetYamlString(dolphinYaml, "exePath") ?? dolphinConfig.exePath;
                dolphinConfig.exec = GetYamlString(dolphinYaml, "exec") ?? dolphinConfig.exec;
                dolphinConfig.videoBackend = GetYamlString(dolphinYaml, "videoBackend") ?? dolphinConfig.videoBackend;
                dolphinConfig.audioEmulation = GetYamlString(dolphinYaml, "audioEmulation") ?? dolphinConfig.audioEmulation;
                dolphinConfig.movie = GetYamlString(dolphinYaml, "movie") ?? dolphinConfig.movie;
                dolphinConfig.user = GetYamlString(dolphinYaml, "user") ?? dolphinConfig.user;
                dolphinConfig.extension = GetYamlString(dolphinYaml, "extension") ?? dolphinConfig.extension;
                dolphinConfig.configDir = GetYamlString(dolphinYaml, "configDir") ?? dolphinConfig.configDir;

                if (dolphinYaml is YamlMappingNode mDolphinYaml) {
                    if (mDolphinYaml.Children.ContainsKey("outputGameTo")) {
                        YamlNode outputNode = mDolphinYaml.Children["outputGameTo"];
                        if (outputNode is YamlScalarNode vOutputNode) {
                            if (vOutputNode.Value == "unset") {
                                dolphinConfig.outputGameTo.Clear();
                            } else {
                                if (!dolphinConfig.outputGameTo.Contains((string)vOutputNode)) dolphinConfig.outputGameTo.Add((string)vOutputNode);
                            }
                        } else if (outputNode is YamlSequenceNode sOutputNode) {
                            foreach (YamlNode valueNode in sOutputNode.Children) {
                                if ((string)valueNode == "unset") {
                                    dolphinConfig.outputGameTo.Clear();
                                } else {
                                    if (!dolphinConfig.outputGameTo.Contains((string)valueNode)) dolphinConfig.outputGameTo.Add((string)valueNode);
                                }
                            }
                        }
                    }

                    if (mDolphinYaml.Children.ContainsKey("config")) {
                        YamlNode configNode = mDolphinYaml.Children["config"];
                        if (configNode is YamlMappingNode mConfigNode) {
                            foreach (YamlNode keyNode in mConfigNode.Children.Keys) {
                                if (!dolphinConfig.config.ContainsKey((string)keyNode)) dolphinConfig.config.Add((string)keyNode, (string)mConfigNode.Children[keyNode]);
                            }
                        }
                    }
                }
            }

            /// Devices
            if (docRoot.Children.ContainsKey("devices")) {
                foreach (YamlNode deviceNode in (YamlSequenceNode)docRoot.Children["devices"]) {
                    if (GetYamlString(deviceNode, "id") == null) {
                        // We need an ID; if there isn't one, skip it
                        continue;
                    }
                    string deviceId = GetYamlString(deviceNode, "id");
                    if (modeConfig[currentMode].devices == null) {
                        modeConfig[currentMode].devices = new List<DeviceConfig>();
                    }

                    if (modeConfig[currentMode].devices.Count(d => d.id == deviceId) == 0) { 
                        modeConfig[currentMode].devices.Add(new DeviceConfig() { id = deviceId });
                    }
                    DeviceConfig deviceConfig = modeConfig[currentMode].devices.First<DeviceConfig>(d => d.id == deviceId);

                    deviceConfig.type = GetYamlString(deviceNode, "type") ?? deviceConfig.type;
                    deviceConfig.active = GetYamlBool(deviceNode, "active", deviceConfig.active);
                    deviceConfig.mountTo = GetYamlString(deviceNode, "mountTo") ?? deviceConfig.mountTo;
                    deviceConfig.stereoscopic= GetYamlString(deviceNode, "stereoscopic") ?? deviceConfig.stereoscopic;

                    if (deviceNode is YamlMappingNode mapDeviceNode) {
                        if (mapDeviceNode.Children.ContainsKey("offset")) {
                            deviceConfig.offset.Set(
                                GetYamlFloat(mapDeviceNode["offset"], "x", deviceConfig.offset.x),
                                GetYamlFloat(mapDeviceNode["offset"], "y", deviceConfig.offset.y),
                                GetYamlFloat(mapDeviceNode["offset"], "z", deviceConfig.offset.z)
                            );
                        }

                        if (mapDeviceNode.Children.ContainsKey("scale")) {
                            deviceConfig.scale.Set(
                                GetYamlFloat(mapDeviceNode["scale"], "x", deviceConfig.scale.x),
                                GetYamlFloat(mapDeviceNode["scale"], "y", deviceConfig.scale.y),
                                GetYamlFloat(mapDeviceNode["scale"], "z", deviceConfig.scale.z)
                            );
                        }

                        if (mapDeviceNode.Children.ContainsKey("rotation")) {
                            deviceConfig.rotation.Set(
                                GetYamlFloat(mapDeviceNode["rotation"], "x", deviceConfig.rotation.x),
                                GetYamlFloat(mapDeviceNode["rotation"], "y", deviceConfig.rotation.y),
                                GetYamlFloat(mapDeviceNode["rotation"], "z", deviceConfig.rotation.z)
                            );
                        }

                        if (mapDeviceNode.Children.ContainsKey("bindings")) {
                            YamlNode bindingsNode = mapDeviceNode.Children["bindings"];
                            if (bindingsNode is YamlMappingNode mBindingsNode) {
                                foreach (YamlNode keyNode in mBindingsNode.Children.Keys) {
                                    if (!deviceConfig.bindings.ContainsKey((string)keyNode)) deviceConfig.bindings.Add((string)keyNode, (string)mBindingsNode[keyNode]);
                                }
                            }
                        }
                    }
                }
            }

            /// ControlMapping
            if (docRoot.Children.ContainsKey("controls")) {
                YamlMappingNode controlsRoot = (YamlMappingNode)docRoot.Children["controls"];
                if (modeConfig[currentMode].controlsConfig == null) {
                    modeConfig[currentMode].controlsConfig = new ControlsConfig();
                }
                ControlsConfig controlsConfig = modeConfig[currentMode].controlsConfig;

                foreach (YamlNode actionMapKey in controlsRoot.Children.Keys) {
                    YamlNode actionMapNode = controlsRoot.Children[actionMapKey];
                    if (actionMapNode is YamlMappingNode mActionMapNode) {
                        foreach (YamlNode actionKey in mActionMapNode.Children.Keys) {
                            YamlNode actionNode = mActionMapNode.Children[actionKey];

                            if (actionNode is YamlScalarNode vActionNode) {
                                // Single value - so either "unset" or a path
                                if (vActionNode.Value == "unset") {
                                    controlsConfig.UnsetBindings((string)actionMapKey, (string)actionKey);
                                } else {
                                    controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, vActionNode.Value);
                                }
                            } else if (actionNode is YamlMappingNode mActionNode) {
                                if (GetYamlString(mActionNode, "path") != null) {
                                    ControlBinding binding = new ControlBinding {
                                        path = GetYamlString(mActionNode, "path"),
                                        interactions = GetYamlString(mActionNode, "interactions", ""),
                                        processors = GetYamlString(mActionNode, "processors", "")
                                    };
                                    controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, binding);
                                }
                            } else if (actionNode is YamlSequenceNode sActionNode) {
                                // List of scalars or objects
                                foreach (YamlNode valueNode in sActionNode.Children) {
                                    if (valueNode is YamlScalarNode vValueNode) {
                                        // Single value - so either "unset" or a path
                                        if (vValueNode.Value == "unset") {
                                            controlsConfig.UnsetBindings((string)actionMapKey, (string)actionKey);
                                        } else {
                                            controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, vValueNode.Value);
                                        }
                                    } else if (valueNode is YamlMappingNode mValueNode) {
                                        if (GetYamlString(mValueNode, "path") != null) {
                                            ControlBinding binding = new ControlBinding {
                                                path = GetYamlString(mValueNode, "path"),
                                                interactions = GetYamlString(mValueNode, "interactions", ""),
                                                processors = GetYamlString(mValueNode, "processors", "")
                                            };
                                            controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, binding);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string GetYamlString(YamlNode node, string key) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return (string)node[key];
            }
            return null;
        }

        public static string GetYamlString(YamlNode node, string key, string previousValue) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return (string)node[key];
            }
            return previousValue;
        }

        public static bool GetYamlBool(YamlNode node, string key) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return Convert.ToBoolean(node[key]);
            }
            return false;
        }

        public static bool GetYamlBool(YamlNode node, string key, bool previousValue) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return Convert.ToBoolean(node[key]);
            }
            return previousValue;
        }

        public static float GetYamlFloat(YamlNode node, string key) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return Convert.ToSingle(node[key].ToString());
            }
            return 0f;
        }

        public static float GetYamlFloat(YamlNode node, string key, float previousValue) {
            if (node is YamlMappingNode mNode && mNode.Children.ContainsKey(key)) {
                return Convert.ToSingle(node[key].ToString());
            }
            return previousValue;
        }
    }
}