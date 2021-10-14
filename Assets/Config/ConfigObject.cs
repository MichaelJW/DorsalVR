using MoonSharp.Interpreter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Dorsal.Config {

    [MoonSharpUserData]
    public class Config {
        // id, DeviceConfig
        public List<DeviceConfig> devices;
        public DolphinConfig dolphinConfig;
        public ControlsConfig controlsConfig;
        public DebugConfig debugConfig;

        public Config Clone() {
            Config clone = new Config();

            if (dolphinConfig != null) clone.dolphinConfig = dolphinConfig.Clone();
            if (devices != null) {
                clone.devices = new List<DeviceConfig>();
                foreach (DeviceConfig device in devices) {
                    clone.devices.Add(device.Clone());
                }
            }
            if (controlsConfig != null) clone.controlsConfig = controlsConfig.Clone();
            if (debugConfig != null) clone.debugConfig = debugConfig.Clone();

            return clone;
        }
    }

    [MoonSharpUserData]
    public class DeviceConfig {
        public string id;
        public string type;
        public bool active = true;
        public DeviceVREntityConfig vrEntityConfig = new DeviceVREntityConfig();
        public DeviceIMUConfig imuConfig = new DeviceIMUConfig();
        public DeviceScreenConfig screenConfig = new DeviceScreenConfig();

        public DeviceConfig Clone() {
            DeviceConfig clone = new DeviceConfig();
            clone.id = id;
            clone.type = type;
            clone.active = active;
            clone.vrEntityConfig = vrEntityConfig.Clone();
            clone.imuConfig = imuConfig.Clone();
            clone.screenConfig = screenConfig.Clone();

            return clone;
        }
    }

    [MoonSharpUserData]
    public class DeviceVREntityConfig {
        public Vector3 positionOffset = Vector3.zero;
        public Vector3 scale = Vector3.one;
        public Quaternion rotationOffset = Quaternion.identity;
        public string model;
        public ControlBinding positionBinding = new ControlBinding();
        public ControlBinding rotationBinding = new ControlBinding();

        public DeviceVREntityConfig Clone() {
            DeviceVREntityConfig clone = new DeviceVREntityConfig();
            clone.positionOffset = positionOffset;
            clone.scale = scale;
            clone.rotationOffset = rotationOffset;
            clone.model = model;
            clone.positionBinding = positionBinding.Clone();
            clone.rotationBinding = rotationBinding.Clone();

            return clone;
        }
    }

    [MoonSharpUserData]
    public class DeviceScreenConfig {
        public string stereoscopic;

        public DeviceScreenConfig Clone() {
            DeviceScreenConfig clone = new DeviceScreenConfig();
            clone.stereoscopic = stereoscopic;
            
            return clone;
        }
    }

    [MoonSharpUserData]
    public class DeviceIMUConfig {
        public ControlBinding positionBinding;
        public ControlBinding rotationBinding;
        public Vector3 positionOffset = Vector3.zero;
        public Quaternion rotationOffset = Quaternion.identity;

        public DeviceIMUConfig Clone() {
            DeviceIMUConfig clone = new DeviceIMUConfig();
            clone.positionBinding = positionBinding;
            clone.rotationBinding = rotationBinding;
            clone.positionOffset = positionOffset;
            clone.rotationOffset = rotationOffset;

            return clone;
        }
    }

    [MoonSharpUserData]
    public class DolphinConfig {
        public string exePath;
        public string configDir;
        public List<string> outputGameTo = new List<string>();

        public string exec = "";
        public string videoBackend = "";
        public string audioEmulation = "";
        public string movie = "";
        public string user = "";
        public string nandTitle = "";
        public string saveState = "";
        public string extension = "none";
        public Dictionary<string, string> config = new Dictionary<string, string>();

        public DolphinConfig Clone() {
            DolphinConfig clone = new DolphinConfig();

            clone.exePath = exePath;
            clone.outputGameTo = new List<string>();
            foreach (string output in outputGameTo) {
                clone.outputGameTo.Add(output);
            }

            clone.exec = exec;
            clone.videoBackend = videoBackend;
            clone.audioEmulation = audioEmulation;
            clone.movie = movie;
            clone.user = user;
            clone.nandTitle = nandTitle;
            clone.saveState = saveState;
            clone.extension = extension;
            clone.configDir = "";
            clone.config = new Dictionary<string, string>();
            foreach (string key in config.Keys) {
                clone.config.Add(key, config[key]);
            }

            return clone;
        }

        public override string ToString() {
            string toReturn = $"exec: {exec}\nvideoBackend: {videoBackend}\naudioEmulation: {audioEmulation}\nmovie: {movie}\nuser: {user}\nnandTitle: {nandTitle}\nsaveState: {saveState}\nextension: {extension}";
            foreach (string key in config.Keys) {
                toReturn += $"\n{key}: {config[key]}";
            }
            return toReturn;
        }
    }

    [MoonSharpUserData]
    public class ControlsConfig {
        // Action map, mapping
        public Dictionary<string, ControlMapping> controls = new Dictionary<string, ControlMapping>();

        public void AddBinding(string actionMap, string action, string bindingPath) {
            ControlBinding binding = new ControlBinding { path = bindingPath };
            if (controls.ContainsKey(actionMap)) {
                controls[actionMap].AddBinding(action, binding);
            } else {
                ControlMapping controlMapping = new ControlMapping();
                controlMapping.AddBinding(action, binding);
                controls.Add(actionMap, controlMapping);
            }
        }

        public void AddBinding(string actionMap, string action, ControlBinding binding) {
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

    [MoonSharpUserData]
    public class ControlMapping {
        // Action, binding(s)
        public Dictionary<string, List<ControlBinding>> mapping = new Dictionary<string, List<ControlBinding>>();

        internal void AddBinding(string action, ControlBinding binding) {
            if (mapping.ContainsKey(action)) {
                List<ControlBinding> bindings = mapping[action];
                // We look for *exact* duplicates, based on path, interactions, *and* processors
                if (bindings.Count(b => b.path == binding.path && b.interactions == binding.interactions && b.processors == binding.processors) == 0) { 
                    bindings.Add(binding);
                }
            } else {
                List<ControlBinding> bindings = new List<ControlBinding>();
                bindings.Add(binding);
                mapping.Add(action, bindings);
            }
        }

        internal void UnsetBindings(string action) {
            if (mapping.ContainsKey(action)) {
                mapping[action].Clear();
            }
        }

        public ControlMapping Clone() {
            ControlMapping clone = new ControlMapping();

            foreach (string key in mapping.Keys) {
                List<ControlBinding> bindings = new List<ControlBinding>();
                for (int i = 0; i < mapping[key].Count; i++) {
                    bindings.Add(mapping[key][i]);
                }
                clone.mapping.Add(key, bindings);
            }

            return clone;
        }
    }

    [MoonSharpUserData]
    public class ControlBinding {
        public string path = "";
        public string interactions = "";
        public string processors = "";

        public ControlBinding(string _path = "", string _interactions = "", string _processors = "") {
            path = _path;
            interactions = _interactions;
            processors = _processors;
        }

        public ControlBinding Clone() {
            ControlBinding clone = new ControlBinding();
            clone.path = path;
            clone.interactions = interactions;
            clone.processors = processors;

            return clone;
        }
    }

    [MoonSharpUserData]
    public class DebugConfig {
        public List<ControlBinding> bindings = new List<ControlBinding>();

        public DebugConfig Clone() {
            DebugConfig clone = new DebugConfig();

            clone.bindings = new List<ControlBinding>();
            for (int i = 0; i < bindings.Count; i++) {
                clone.bindings.Add(bindings[i].Clone());
            }

            return clone;
        }
    }
}