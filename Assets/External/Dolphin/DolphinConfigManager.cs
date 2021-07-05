using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class DolphinConfigManager {
    public string dolphinConfigDirectory = "";

    public DolphinConfigManager() {

    }

    private string BackUpINI(string relativePath) {
        string fullPath = Path.Combine(dolphinConfigDirectory, relativePath);
        if (File.Exists(fullPath)) {
            string fullDirectoryPath = Path.GetDirectoryName(fullPath);
            if (Directory.Exists(fullDirectoryPath)) {
                string fileName = Path.GetFileName(fullPath);
                string fullBackupPath = Path.Combine(fullDirectoryPath, $"DorsalVR Backup - {fileName}");
                try {
                    File.Copy(fullPath, fullBackupPath, overwrite: true);
                    return fullBackupPath;
                } catch {
                    return "";
                }
            }
        }
        return "";
    }

    private void TryRestoreBackupINI(string relativePath) {
        string fullPath = Path.Combine(dolphinConfigDirectory, relativePath);
        string fullDirectoryPath = Path.GetDirectoryName(fullPath);
        if (Directory.Exists(fullDirectoryPath)) {
            string fileName = Path.GetFileName(fullPath);
            string fullBackupPath = Path.Combine(fullDirectoryPath, $"DorsalVR Backup - {fileName}");
            if (File.Exists(fullBackupPath)) {
                File.Copy(fullBackupPath, fullPath, overwrite: true);
            }
        }
    }

    public void TryRestoreAllBackups() {
        TryRestoreBackupINI("WiimoteNew.ini");
        TryRestoreBackupINI("GCPadNew.ini");
        TryRestoreBackupINI("Hotkeys.ini");
        TryRestoreBackupINI("Dolphin.ini");
        TryRestoreBackupINI("DSUClient.ini");
    }

    public void SetControlINIs() {
        BackUpINI("WiimoteNew.ini");
        File.Copy(
            Path.Combine(Application.dataPath, "External/Dolphin/DorsalVR - Wiimote.ini"),
            Path.Combine(dolphinConfigDirectory, "WiimoteNew.ini"),
            overwrite: true
        );
        BackUpINI("GCPadNew.ini");
        File.Copy(
            Path.Combine(Application.dataPath, "External/Dolphin/DorsalVR - GCPad.ini"),
            Path.Combine(dolphinConfigDirectory, "GCPadNew.ini"),
            overwrite: true
        );
        BackUpINI("Hotkeys.ini");
        File.Copy(
            Path.Combine(Application.dataPath, "External/Dolphin/DorsalVR - Hotkeys.ini"),
            Path.Combine(dolphinConfigDirectory, "Hotkeys.ini"),
            overwrite: true
        );
    }

    public void SetDSUClientINI() {
        BackUpINI("DSUClient.ini");
        File.Copy(
            Path.Combine(Application.dataPath, "External/Dolphin/DorsalVR - DSUClient.ini"),
            Path.Combine(dolphinConfigDirectory, "DSUClient.ini"),
            overwrite: true
        );
    }

    public void ModifyKeyOptions() {
        BackUpINI("Dolphin.ini");
        string iniString = File.ReadAllText(Path.Combine(dolphinConfigDirectory, "Dolphin.ini"));
        iniString = Regex.Replace(iniString, @"(HotkeysRequireFocus\s*=\s*\S*)", @"HotkeysRequireFocus = False");
        iniString = Regex.Replace(iniString, @"(BackgroundInput\s*=\s*\S*)", @"BackgroundInput = True");
        iniString = Regex.Replace(iniString, @"(PauseOnFocusLost\s*=\s*\S*)", @"PauseOnFocusLost = False");
        File.WriteAllText(Path.Combine(dolphinConfigDirectory, "Dolphin.ini"), iniString);
    }
}
