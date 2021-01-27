using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MiniGameSDK;
public class DynamicPermissionEditor : IParamSettng
{
    public void SetParam()
    {
        GradleHelper.SetImplementation("com.lovedise:permissiongen:0.0.6");
    }
}
