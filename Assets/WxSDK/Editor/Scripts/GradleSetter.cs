using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class GradleSetter 
{
    public static void SetGradle()
    {
        GradleHelper.SetImplementation("com.tencent.mm.opensdk:wechat-sdk-android-without-mta:+");
        //string dir = "Assets/Plugins/Android";
        //if (!Directory.Exists(dir))
        //    Directory.CreateDirectory(dir);
        //string[] paths = Directory.GetFiles(dir, "*.gradle", SearchOption.TopDirectoryOnly);
        //if (paths.Length == 0)
        //{
        //    string tmpFile = AssetDatabase.GUIDToAssetPath("0e5f4adfd825e9049bf286bdb9a785c7");
        //    string strs = File.ReadAllText(tmpFile);
        //    File.WriteAllText($"{dir}/{Path.GetFileNameWithoutExtension(tmpFile)}.gradle",strs);
        //}
        //else
        //{
        //    string inst = "implementation 'com.tencent.mm.opensdk:wechat-sdk-android-without-mta:+'\n";
        //    string file = File.ReadAllText(paths[0]);
        //    if (!file.Contains("com.tencent.mm.opensdk:wechat-sdk-android-without-mta:+"))
        //    {
        //        int idx = file.LastIndexOf("**DEPS**}");
        //        file = file.Insert(idx, inst);
        //        File.WriteAllText(paths[0], file);
        //    }
        //}
    }
}
