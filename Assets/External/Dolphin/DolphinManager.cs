using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dorsal.External.Dolphin {
    class DolphinManager : MonoBehaviour {
        public void Launch(Config.DolphinConfig dolphinConfig) {
            string exePath = dolphinConfig.exePath;
            string userDir = dolphinConfig.user;

            if (userDir == "" || userDir == null) {
                // Use the default
                // https://wiki.dolphin-emu.org/index.php?title=Controlling_the_Global_User_Directory
                userDir = Path.Combine(System.Environment.GetEnvironmentVariable("USERPROFILE"), "Documents\\Dolphin Emulator");
            }
            
            // We need the /Config/ path so we can overwrite some of the Dolphin config files with ideal options
            string configDir = Path.Combine(userDir, "Config");
            if (Directory.Exists(configDir) && File.Exists(exePath)) { 
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

                if (dolphinConfig.gameScreen != null) {
                    dolphinConfig.gameScreen.SetHwndViaDelegate(dp.GetGameHWnd);                    
                }
            }
        }

        public Config.DolphinConfig CreateDolphinConfig() {
            return new Config.DolphinConfig();
        }
    }
}
