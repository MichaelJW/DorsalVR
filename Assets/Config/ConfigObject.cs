using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorsal.Config {
    public class Config {
        // id, DeviceConfig
        public Dictionary<string, DeviceConfig> devices;
        public DolphinConfig dolphinConfig;
        public ControlsConfig controlsConfig;

        public Config Clone() {
            Config clone = new Config();

            if (dolphinConfig != null) clone.dolphinConfig = dolphinConfig.Clone();
            if (devices != null) {
                clone.devices = new Dictionary<string, DeviceConfig>();
                foreach (string id in devices.Keys) {
                    clone.devices[id] = devices[id].Clone();
                }
            }
            if (controlsConfig != null) clone.controlsConfig = controlsConfig.Clone();

            return clone;
        }
    }

    public class DeviceConfig {
        public string id;
        public string type;
        public bool active;

        public DeviceConfig Clone() {
            DeviceConfig clone = new DeviceConfig();

            clone.id = id;
            clone.type = type;
            clone.active = active;

            return clone;
        }
    }

    public class DolphinConfig {
        public string exePath;
        public string userPath;
        public string isoPath;
        public string outputGameTo;

        public DolphinConfig Clone() {
            DolphinConfig clone = new DolphinConfig();

            clone.exePath = exePath;
            clone.userPath = userPath;
            clone.isoPath = isoPath;
            clone.outputGameTo = outputGameTo;

            return clone;
        }
    }

    public class ControlsConfig {
        // Action map, mapping
        public Dictionary<string, ControlMapping> controls = new Dictionary<string, ControlMapping>();

        public void AddBinding(string actionMap, string action, string binding) {
            if (controls.ContainsKey(actionMap)) {
                controls[actionMap].AddBinding(action, binding);
            } else {
                ControlMapping controlMapping = new ControlMapping();
                controlMapping.AddBinding(action, binding);
                controls.Add(actionMap, controlMapping);
            }
        }

        public void UnsetBindings(string actionMap, string action) {
            if (controls.ContainsKey(actionMap)) {
                controls[actionMap].UnsetBindings(action);
            }
        }

        public void UnsetBindings(string actionMap) {
            if (controls.ContainsKey(actionMap)) {
                controls.Remove(actionMap);
            }
        }

        public ControlsConfig Clone() {
            ControlsConfig clone = new ControlsConfig();

            foreach (string key in controls.Keys) {
                clone.controls.Add(key, controls[key].Clone());
            }

            return clone;
        }
    }

    public class ControlMapping {
        // Action, binding(s)
        public Dictionary<string, List<string>> mapping = new Dictionary<string, List<string>>();

        public void AddBinding(string action, string binding) {
            if (mapping.ContainsKey(action)) {
                List<string> bindings = mapping[action];
                if (!bindings.Contains(binding)) {
                    bindings.Add(binding);
                }
            } else {
                List<string> bindings = new List<string>();
                bindings.Add(binding);
                mapping.Add(action, bindings);
            }
        }

        public void UnsetBindings(string action) {
            if (mapping.ContainsKey(action)) {
                mapping[action].Clear();
            }
        }

        public ControlMapping Clone() {
            ControlMapping clone = new ControlMapping();

            foreach (string key in mapping.Keys) {
                List<string> bindings = new List<string>();
                for (int i = 0; i < mapping[key].Count; i++) {
                    bindings.Add(mapping[key][i]);
                }
                clone.mapping.Add(key, bindings);
            }

            return clone;
        }
    }
}