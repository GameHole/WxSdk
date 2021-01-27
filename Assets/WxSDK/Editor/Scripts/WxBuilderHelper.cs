using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using MiniGameSDK;
namespace Wx
{
    //[InitializeOnLoad]
    public class WxBuilderHelper :IParamSettng
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
        //[MenuItem("WX/设置SDK参数")]
        static void SetValues_1()
        {
            //string aarsPath = AssetDatabase.GUIDToAssetPath("7fac2c4dd83f56442b8430a7d4492144");
            //string mmPath = AssetDatabase.GUIDToAssetPath("034dd7365e62353469769ea304901074");
            string entryJavaTxt = AssetDatabase.GUIDToAssetPath("e2544a5d6d6c72c4ba194a7f31faf56e");
            string pluginPath = "Assets/Plugins";
            string andPath = pluginPath + "/Android";
            string iosPath = pluginPath + "/IOS";
            if (!Directory.Exists(andPath))
            {
                Directory.CreateDirectory(andPath);
            }
            string file = File.ReadAllText(entryJavaTxt);
            File.WriteAllText(Path.Combine(pluginPath + "/Android", Path.GetFileNameWithoutExtension(entryJavaTxt) + ".java"), file.Replace("#PACKAGE#", Application.identifier));
            //CopyDirectory(aarsPath, andPath);
            //CopyDirectory(mmPath, iosPath);
            XmlSetter.SetXml();
            GradleSetter.SetGradle();
            AssetDatabase.Refresh();
        }
        static void CopyDirectory(string sourceDir, string destDir)
        {
            destDir = Path.Combine(destDir, Path.GetFileName(sourceDir));
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            foreach (var item in Directory.GetFiles(sourceDir))
            {
                string fName = Path.GetFileName(item);
                if (fName.Contains(".meta")) continue;
                File.Copy(item, Path.Combine(destDir, fName), true);
            }
            foreach (var item in Directory.GetDirectories(sourceDir))
            {
                CopyDirectory(item, destDir);
            }
        }

        public void SetParam()
        {
            SetValues_1();
        }
    }

}
