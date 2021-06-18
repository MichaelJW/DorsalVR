using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

namespace Dorsal.Processes {
    public class ProcessManager : MonoBehaviour {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc enumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("USER32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr window, out int process);
        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);


        private List<IDorsalProcess> _processes = new List<IDorsalProcess>();

        public DolphinProcess StartDolphinProcess(string filePath, string arguments = "") {
            try {
                DolphinProcess dp = new DolphinProcess();
                Process p = new Process();
                p.StartInfo.FileName = filePath;
                p.StartInfo.Arguments = arguments;
                p.Start();
                dp.WindowsProcess = p;
                _processes.Add(dp);

                return dp;
            } catch (Exception e) {
                UnityEngine.Debug.Log(e.Message);
            }
            return null;
        }

        public void Update() {
            DolphinProcess dp = _processes.OfType<DolphinProcess>().FirstOrDefault<DolphinProcess>();

            if (dp != null) {
                UnityEngine.Debug.Log(string.Format("Game hWnd: {0}", dp.GetGameHWnd()));
            }
        }

        public void OnDestroy() {
            foreach (IDorsalProcess p in _processes) {
                p.Close();
            }
        }
    }


}