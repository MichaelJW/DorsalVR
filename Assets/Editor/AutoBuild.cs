using UnityEditor;
using System.Diagnostics;
using System.IO.Compression;
using UnityEngine;

public class AutoBuild {
    [MenuItem("Meta Tools/Build")]
    public static void BuildDorsalVR() {
        string currentVersion = PlayerSettings.bundleVersion;
        bool versionIsSet = EditorUtility.DisplayDialog(
            title: "Version Number", message: $"Current version number is {currentVersion}; is that correct?", ok: "Yes", cancel: "No"
        );
        if (!versionIsSet) return;
                
        string path = EditorUtility.SaveFolderPanel(
            "Choose Parent Location:", Application.dataPath.Replace("/Assets", "/Builds"), $""
        );
        if (path.Length == 0) return;

        
        BuildPlayerOptions options = new BuildPlayerOptions();
        // Scene will be the currently open scene as not specified here
        options.targetGroup = BuildTargetGroup.Standalone;
        options.target = BuildTarget.StandaloneWindows64;

        // Build the Release version
        options.locationPathName = path + $"/DorsalVR_v{currentVersion}/DorsalVR.exe";
        BuildPipeline.BuildPlayer(options);
        
        // Build the Debug version
        options.locationPathName = path + $"/DorsalVR_v{currentVersion}_DebugBuild/DorsalVR.exe";
        options.options = BuildOptions.Development;
        BuildPipeline.BuildPlayer(options);

        Process proc = new Process();
        proc.StartInfo.FileName = path;
        proc.Start();
    }
}
