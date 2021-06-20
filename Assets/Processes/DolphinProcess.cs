using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Dorsal.Processes {
    public class DolphinProcess : IDorsalProcess {
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


        private Process _windowsProcess;
        public Process WindowsProcess {
            get => _windowsProcess;
            set => _windowsProcess = value;
        }

        /// <summary>
        /// Get hWnd of the game itself (i.e. not the UI or any settings forms, etc).
        /// We do it in a circuitous way because MainWindowHandle always seems to return 0.
        /// (That's possibly a Unity problem. But MainWindowHandle probably isn't the game window anyway.)
        /// </summary>
        /// <returns></returns>
        public IntPtr GetGameHWnd() {
            IntPtr gameHWnd = (IntPtr)0;
            if (_windowsProcess == null) return gameHWnd;
            _windowsProcess.Refresh();  // need to do this to get the latest info about the process

            EnumWindows(  // iterate through all windows
                delegate (IntPtr hWnd, int lParam) {
                    GetWindowThreadProcessId(hWnd, out int processId);  // get processId of current window
                    if (processId == _windowsProcess.Id) {  // if it matches our process (i.e. if spawned by Dolphin)...
                        // ... get the title:
                        int windowTextLength = GetWindowTextLength(hWnd);
                        StringBuilder builder = new StringBuilder(windowTextLength);
                        GetWindowText(hWnd, builder, windowTextLength + 1);
                        // We know the game window title contains pipes
                        if (builder.ToString().Contains("|")) {
                            gameHWnd = hWnd;
                            return true;  // EnumWindowsProc spec wants this
                        }
                    }
                    return true;  // EnumWindowsProc spec wants this
                },
                0
            );

            return gameHWnd;
        }

        public void Close() {
            if (_windowsProcess != null && !_windowsProcess.HasExited) _windowsProcess.CloseMainWindow();
        }
    }
}