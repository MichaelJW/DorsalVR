using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Dorsal.Devices {
    [MoonSharpUserData]
    public class IMUProxy {
        IMU target;

        [MoonSharpHidden]
        public IMUProxy(IMU p) {
            this.target = p;
        }

        public string GetID() {
            return target.ID;
        }
    }
}
