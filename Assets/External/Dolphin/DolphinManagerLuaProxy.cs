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

        public void Launch(string exePath, string configDir) {
            target.Launch(exePath, configDir);
        }

        [LuaTag(description = "Does something.")]
        public string DoSomething(int integer) {
            return "something";
        }

        [LuaTag(description = "Tests the auto-reload.\nInclude multi-line comment.")]
        public string CheckAutoReload(string test) {
            return "test";
        }
    }
}
