using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Dorsal.External.Dolphin {
    [MoonSharpUserData]
    class DolphinManagerProxy {
        private DolphinManager target;

        [MoonSharpHidden]
        public DolphinManagerProxy(DolphinManager p) {
            target = p;
        } 

        public void Launch(string exePath, string configDir) {
            target.Launch(exePath, configDir);
        }
    }
}
