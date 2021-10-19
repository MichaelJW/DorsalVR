using UnityEditor;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

public class LuaDefs {
    [UnityEditor.Callbacks.DidReloadScripts]
    [MenuItem("Meta Tools/Generate Lua Defs")]
    public static void GenerateLuaDefs() {
        List<Type> result = new List<Type>();

        Assembly a = typeof(SettingsManager).Assembly;

        foreach (Type t in a.GetTypes()) {
            if (t.GetCustomAttributes(typeof(MoonSharp.Interpreter.MoonSharpUserDataAttribute), false).Length > 0) {
                result.Add(t);
            }
        }

        Debug.Log("Writing Lua defs to file...");
        String defsPath = Path.Combine(Application.streamingAssetsPath, @"DorsalConfigs/defs.lua");
        StreamWriter defs = new StreamWriter(defsPath);
        foreach (Type t in result) {
            string className = t.Name.Replace("LuaProxy", "");
            defs.WriteLine($"--- @class {className}");
            if (t.GetCustomAttributes(typeof(LuaTag), false).Length > 0) {
                string description = t.GetCustomAttribute<LuaTag>().description;
                if (description != "") {
                    foreach (string descriptionLine in description.Split('\n')) {
                        defs.WriteLine($"--- {descriptionLine}");
                    }
                }
            }
            defs.WriteLine($"{className}={{}};");
            foreach (MethodInfo m in t.GetMethods()) {
                if (!m.IsPrivate && m.DeclaringType == t) {  // is relevant method
                    string mParams = "";
                    foreach (ParameterInfo mParam in m.GetParameters()) {
                        mParams += mParam.Name + ", ";  // TODO: Use LINQ or something
                        defs.WriteLine($"--- @param {mParam.Name} {CSharpTypeToLuaType(mParam.ParameterType)}");
                    }
                    mParams = mParams.Substring(0, Math.Max(0, mParams.Length - 2));  // remove trailing comma
                    Debug.Log(m.ReturnType.Name);
                    if (m.ReturnType.Name != "Void") {
                        defs.WriteLine($"--- @return {CSharpTypeToLuaType(m.ReturnType)}");
                    }
                    if (m.GetCustomAttributes(typeof(LuaTag), false).Length > 0) {
                        string description = m.GetCustomAttribute<LuaTag>().description;
                        if (description != "") {
                            foreach (string descriptionLine in description.Split('\n')) {
                                defs.WriteLine($"--- {descriptionLine}");
                            }
                        }
                    }
                    defs.WriteLine($"function {className}:{m.Name}({mParams}) end");
                }
            }
        }
        defs.Close();
        Debug.Log("Wrote Lua defs to file.");
    }

    private static string CSharpTypeToLuaType(string cSharpType) {
        switch (cSharpType) {
            case "Void":
                return "nil";
            case "String":
                return "string";
            case "UInt16":
            case "UInt32":
            case "UInt64":
            case "Int16":
            case "Int32":
            case "Int64":
            case "Decimal":
            case "Double":
            case "Single":
                return "number";
            default:
                return cSharpType.Replace("LuaProxy", "");
        }
    }

    private static string CSharpTypeToLuaType(Type cSharpType) {
        return CSharpTypeToLuaType(cSharpType.Name);
    }

    private static void ClearConsole() {
        Assembly assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        Type type = assembly.GetType("UnityEditor.LogEntries");
        MethodInfo method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
