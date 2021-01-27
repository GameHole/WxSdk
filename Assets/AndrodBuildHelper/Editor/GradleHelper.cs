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
            if (idx > 0)
            {
                file = file.Insert(idx, inst);
                File.WriteAllText(gradlePath, file);
            }
        }
    }
    public static void CombineProguard(string txtPath,string mark)
    {
        string floader = "Assets/Plugins/Android/";
        if (!Directory.Exists(floader))
            Directory.CreateDirectory(floader);
        string prgFile = $"{floader}/proguard-user.txt";
        if (!File.Exists(prgFile))
            File.Create(prgFile).Close();
        string f = File.ReadAllText(prgFile);
        string startMark = $"# COMBINE_MARK_{mark}_START\n";
        string endMark = $"# COMBINE_MARK_{mark}_END\n";
        string txtStr = $"{startMark}{File.ReadAllText(txtPath)}{endMark}";
        string combined = null;
        int sidx = f.IndexOf(startMark);
        if (sidx >= 0)
        {
            int eid = f.IndexOf(endMark);
            string removed = f.Remove(sidx, eid + endMark.Length - sidx);
            combined = removed.Insert(sidx, txtStr);
        }
        else
        {
            combined = f + "\n" + txtStr;
        }
        File.WriteAllText(prgFile, combined);
    }
}
