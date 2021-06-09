using System;
using System.Collections.Generic;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using System.IO;
using System.Reflection;

namespace Dorsal.Config {
    class ConfigLoader {
        public static Dictionary<string, Config> ParseYamlFile(string yamlPath) {
            string yamlString;
            try {
                yamlString = File.ReadAllText(yamlPath);
            } catch (Exception e) {
                return null;
            }
            return ParseYamlString(yamlString);
        }

        public static void ParseYamlFile(string yamlPath, Dictionary<string, Config> modeConfig) {
            string yamlString;
            try {
                yamlString = File.ReadAllText(yamlPath);
            } catch (Exception e) {
                yamlString = null;
            }
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
                dolphinConfig.userPath = GetYamlString(dolphinYaml, "userPath") ?? dolphinConfig.userPath;
                dolphinConfig.isoPath = GetYamlString(dolphinYaml, "isoPath") ?? dolphinConfig.isoPath;
                dolphinConfig.outputGameTo = GetYamlString(dolphinYaml, "outputGameTo") ?? dolphinConfig.outputGameTo;
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
                        modeConfig[currentMode].devices = new Dictionary<string, DeviceConfig>();
                    }
                    if (!modeConfig[currentMode].devices.ContainsKey(deviceId)) {
                        modeConfig[currentMode].devices[deviceId] = new DeviceConfig();
                    }
                    DeviceConfig deviceConfig = modeConfig[currentMode].devices[deviceId];

                    deviceConfig.id = deviceId;  // redundant, perhaps
                    deviceConfig.type = GetYamlString(deviceNode, "type") ?? deviceConfig.type;
                    deviceConfig.active = GetYamlBool(deviceNode, "active", deviceConfig.active);
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
                                if (vActionNode.Value == "unset") {
                                    controlsConfig.UnsetBindings((string)actionMapKey, (string)actionKey);
                                } else {
                                    controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, vActionNode.Value);
                                }
                            } else if (actionNode is YamlSequenceNode sActionNode) {
                                foreach (YamlNode valueNode in sActionNode.Children) {
                                    if ((string)valueNode == "unset") {
                                        controlsConfig.UnsetBindings((string)actionMapKey, (string)actionKey);
                                    } else {
                                        controlsConfig.AddBinding((string)actionMapKey, (string)actionKey, (string)valueNode);
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


    }
}