using Dorsal.VREntity;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorsal.Devices {
    [MoonSharpUserData]
    public class DecorationLuaProxy : VRGOLuaProxy {
        internal new Decoration target {
            get { return (Decoration)base.target; }
            set { base.target = value; }
        }

        [MoonSharpHidden]
        public DecorationLuaProxy(Decoration p) {
            target = p;
        }

    }
}
