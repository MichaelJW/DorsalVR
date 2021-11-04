using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dorsal.External.Dolphin {
    class DolphinManager : MonoBehaviour {
        public void Launch(Config.DolphinConfig dolphinConfig) {
            string exePath = dolphinConfig.exePath;
            string configDir = dolphinConfig.configDir;
            if (exePath != null && configDir != null) {
                UnityEngine.Debug.Log($"Dolphin exePath: {exePath}");
                UnityEngine.Debug.Log($"Dolphin configDir: {configDir}");

                DolphinConfigManager dolphinConfigManager = new DolphinConfigManager();
                dolphinConfigManager.dolphinConfigDirectory = configDir;
                dolphinConfigManager.SetControlINIs();
                dolphinConfigManager.SetDSUClientINI();
                dolphinConfigManager.ModifyKeyOptions();

                Dorsal.Processes.ProcessManager processManager = GameObject.Find("ProcessManager").GetComponent<Dorsal.Processes.ProcessManager>();
                Dorsal.Processes.DolphinProcess dp = processManager.StartDolphinProcess(
                    dolphinConfig
                );
            }
        }

        public Config.DolphinConfig CreateDolphinConfig() {
            return new Config.DolphinConfig();
        }
    }
}
