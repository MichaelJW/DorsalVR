using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Dorsal.External.Dolphin {
    [LuaTag(description = "This manages Dolphin.")]
    [MoonSharpUserData]
    class DolphinManagerLuaProxy {
        private DolphinManager target;

        [MoonSharpHidden]
        public DolphinManagerLuaProxy(DolphinManager p) {
            target = p;
        } 

        [LuaTag(description = "Launches a new instance of Dolphin.")]
        public void Launch(string exePath, string configDir) {
            UnityEngine.Debug.Log("Proxy Launch() called");
            target.Launch(exePath, configDir);
        }
    }
}
