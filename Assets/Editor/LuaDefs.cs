using UnityEditor;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System;

public class LuaDefs {
    [MenuItem("Meta Tools/Generate Lua Defs")]
    public static void GenerateLuaDefs() {
        List<Type> result = new List<Type>();

        Assembly a = typeof(Dorsal.Devices.IMUProxy).Assembly;

        foreach (Type t in a.GetTypes()) {
            if (t.GetCustomAttributes(typeof(MoonSharp.Interpreter.MoonSharpUserDataAttribute), false).Length > 0) {
                result.Add(t);
            }
        }

        foreach (Type t in result) {
            Debug.Log($"t.Name: {t.Name}");
            foreach (MethodInfo m in t.GetMethods()) {
                Debug.Log($"m.DeclaringType: {m.DeclaringType}");
                Debug.Log($"m.IsGenericMethod: {m.IsGenericMethod}");
                
                if (!m.IsPrivate && m.DeclaringType == t) {
                    Debug.Log($"m.Name: {m.Name}");
                    Debug.Log($"m.ReturnType: {m.ReturnType}");
                }
            }
        }
    }
}
