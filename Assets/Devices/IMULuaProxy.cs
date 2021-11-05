using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorsal.Devices {
    [MoonSharpUserData]
    public class IMULuaProxy {
        internal IMU target;
        public IMULuaProxy(IMU p) {
            target = p;
        }

        public void SetPositionBinding(string path = "", string interactions = "", string processors = "") {
            target.SetPositionBinding(path, interactions, processors);
        }

        public void SetRotationBinding(string path = "", string interactions = "", string processors = "") {
            target.SetRotationBinding(path, interactions, processors);
        }
    }
}
