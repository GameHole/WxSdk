using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
[InitializeOnLoad]
public class WxBuilderHelper
{
    //[MenuItem("WX/设置SDK参数")]
    //static void SetValues()
    //{
    //    string entryJavaTxt = AssetDatabase.GUIDToAssetPath("8d0d0ee489b31744fbc356d241c89f78");
    //    string andPath = AssetDatabase.GUIDToAssetPath("7fac2c4dd83f56442b8430a7d4492144");
    //    if (!Directory.Exists(andPath))
    //    {
    //        Directory.CreateDirectory(andPath);
    //    }
    //    string file = File.ReadAllText(entryJavaTxt);
    //    File.WriteAllText(Path.Combine(andPath, Path.GetFileName(entryJavaTxt)), file.Replace("#PACKAGE#", Application.identifier));
    //    XmlSetter.SetXml();
    //    GradleSetter.SetGradle();
    //    AssetDatabase.Refresh();
    //}
    [MenuItem("WX/设置SDK参数")]
    static void SetValues_1()
    {
        string aarsPath = AssetDatabase.GUIDToAssetPath("7fac2c4dd83f56442b8430a7d4492144");
        string mmPath = AssetDatabase.GUIDToAssetPath("034dd7365e62353469769ea304901074");
        string entryJavaTxt = AssetDatabase.GUIDToAssetPath("8d0d0ee489b31744fbc356d241c89f78");
        string pluginPath = "Assets/Plugins";
        string andPath = Path.Combine(pluginPath+ "/Android", Path.GetFileName(aarsPath));
        string iosPath = Path.Combine(pluginPath + "/IOS", Path.GetFileName(mmPath));
        if (!Directory.Exists(andPath))
        {
            Directory.CreateDirectory(andPath);
        }
        string file = File.ReadAllText(entryJavaTxt);
        File.WriteAllText(Path.Combine(pluginPath + "/Android", Path.GetFileName(entryJavaTxt)), file.Replace("#PACKAGE#", Application.identifier));
        CopyDirectory(aarsPath, andPath);
        CopyDirectory(mmPath, iosPath);
        XmlSetter.SetXml();
        GradleSetter.SetGradle();
        AssetDatabase.Refresh();
    }
    static void CopyDirectory(string sourceDir, string destDir)
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        try
        {
            string[] fileList = Directory.GetFiles(sourceDir, "*");
            foreach (string f in fileList)
            {
                // Remove path from the file name.
                string fName = f.Substring(sourceDir.Length + 1);
                if (fName.Contains(".meta")) continue;
                // Use the Path.Combine method to safely append the file name to the path.
                // Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(destDir, fName), true);
            }
        }

        catch (DirectoryNotFoundException dirNotFound)
        {
            throw new DirectoryNotFoundException(dirNotFound.Message);
        }
    }
}
