using System.Diagnostics;

namespace Dorsal.Processes {
    public interface IDorsalProcess {
        public Process WindowsProcess { get; set; }
        public void Close();
    }
}