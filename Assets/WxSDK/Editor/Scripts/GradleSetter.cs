using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class GradleSetter 
{
    public static void SetGradle()
    {
        string dir = "Assets/Plugins/Android";
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string[] paths = Directory.GetFiles(dir, "*.gradle", SearchOption.TopDirectoryOnly);
        if (paths.Length == 0)
        {
            string tmpFile = AssetDatabase.GUIDToAssetPath("a6eacb6c9baa442459d03659241ce5df");
            File.Copy(tmpFile, Path.Combine(dir, Path.GetFileName(tmpFile)));
        }
        else
        {
            string inst = "implementation 'com.tencent.mm.opensdk:wechat-sdk-android-without-mta:+'\n";
            string file = File.ReadAllText(paths[0]);
            if (!file.Contains("com.tencent.mm.opensdk:wechat-sdk-android-without-mta:+"))
            {
                int idx = file.LastIndexOf("**DEPS**}");
                file = file.Insert(idx, inst);
                File.WriteAllText(paths[0], file);
            }
        }
    }
}
