using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorsal.VREntity {
    [MoonSharpUserData]
    public class VRGOLuaProxy {
        internal VRGO target;

        public VRGOLuaProxy() {
        }

        public void SetPositionOffset(float x = 0, float y = 0, float z = 0) {
            target.SetPositionOffset(x, y, z);
        }

        public void ResetPositionOffset() {
            target.ResetPositionOffset();
        }

        public void SetScale(float x = 1.0f, float y = 1.0f, float z = 1.0f) {
            target.SetScale(x, y, z);
        }

        public void ResetScale() {
            target.ResetScale();
        }

        public void SetRotationOffset(float x = 0.0f, float y = 0.0f, float z = 0.0f) {
            target.SetRotationOffset(x, y, z);
        }

        public void ResetRotationOffset() {
            target.ResetRotationOffset();
        }
    }

}
