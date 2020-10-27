using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;
public static class GradleHelper 
{
    //[MenuItem("Test/AA")]
    //static void AA()
    //{
    //    SetImplementation("aa");
    //    AssetDatabase.Refresh();
    //}
    public static void SetImplementation(string packet)
    {
        string tmpFile = EditorApplication.applicationContentsPath + "/PlaybackEngines/AndroidPlayer/Tools/GradleTemplates/mainTemplate.gradle";
        string dir = "Assets/Plugins/Android";
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string[] paths = Directory.GetFiles(dir, "*.gradle", SearchOption.TopDirectoryOnly);
        string gradlePath = "Assets/Plugins/Android/mainTemplate.gradle";
        if (paths.Length == 0)
        {
            File.Copy(tmpFile, gradlePath);
        }
        else
        {
            gradlePath = paths[0];
        }
       
        string inst = $"implementation '{packet}'\n";
        string file = File.ReadAllText(gradlePath);
        if (!file.Contains(inst))
        {
            int idx = file.LastIndexOf("**DEPS**}");
            file = file.Insert(idx, inst);
            File.WriteAllText(gradlePath, file);
        }
    }
}
