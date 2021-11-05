using Dorsal.VREntity;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorsal.Devices {
    [LuaTag(description = "Allows creation of Dorsal devices")]
    [MoonSharpUserData]
    class DeviceManagerLuaProxy {
        private DeviceManager target;

        [MoonSharpHidden]
        public DeviceManagerLuaProxy(DeviceManager p) {
            target = p;
        }

        public Screen CreateScreen() {
            return target.CreateScreen();
        }

        public IMU CreateIMU(string id) {
            return target.CreateIMU(id);
        }

        public VRGO CreateDecoration() {
            return target.CreateDecoration();
        }
    }
}
