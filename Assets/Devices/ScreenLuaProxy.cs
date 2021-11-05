using Dorsal.VREntity;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorsal.Devices {
    [MoonSharpUserData]
    public class ScreenLuaProxy : VRGOLuaProxy {
        internal new Screen target {
            get { return (Screen)base.target; }
            set { base.target = value; }
        }

        [MoonSharpHidden]
        public ScreenLuaProxy(Screen p) {
            target = p;
        }

        public void EnableSBS3D() {
            target.SetSBS3D(true);
        }

        public void DisableSBS3D() {
            target.SetSBS3D(false);
        }
    }
}
