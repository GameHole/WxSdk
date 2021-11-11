using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MiniGameSDK;
using UnityEditor.Android;
#if USE_COSTOM_PERM
public class DynamicPermissionEditor : IPostGenerateGradleAndroidProject
{
    public int callbackOrder => 0;

    public void OnPostGenerateGradleAndroidProject(string path)
    {
        var gd = GradleHelper.Open($"{path}/build.gradle");
        gd.SetImplementation("com.lovedise.permissiongen:0.0.6");
        gd.Save();
    }
}
#endif
