using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEditor;
using System.IO;
public static class XmlSetter 
{
    //[MenuItem("Wx/TExt")]
    public static void SetXml()
    {
        //XmlDocument document = new XmlDocument();
        //string plgpath = "Assets/Plugins/Android";
        //string plugpath = $"{plgpath}/AndroidManifest.xml";
        //if (!File.Exists(plugpath))
        //{
        //    string con = File.ReadAllText(AssetDatabase.GUIDToAssetPath("8522b410d95a7cd4397ecdbe10efe186"));
        //    if (!Directory.Exists(plgpath))
        //        Directory.CreateDirectory(plgpath);
        //    File.WriteAllText(plugpath, con);
        //}
        //document.Load(plugpath);
        var document = XmlHelper.GetAndroidManifest();
        var settedNode = document.FindNode("/manifest/application/activity", "android:name", $"{Application.identifier}.wxapi.WXEntryActivity");
        if (settedNode != null) return;
        //var node = document.FindNode("/manifest/application/activity", "android:name", "package.wxapi.WXEntryActivity");
        //if (node != null)
        //{
        //    node.Attributes["android:name"].Value = $"{Application.identifier}.wxapi.WXEntryActivity";
        //    node.Attributes["android:taskAffinity"].Value = Application.identifier;
        //}
        //else
        {
            var appNode = document.SelectSingleNode("/manifest/application");
            var em = document.CreateElement("activity");
            em.Attributes.Append(em.CreateAttribute("name", $"{Application.identifier}.wxapi.WXEntryActivity"));
            em.Attributes.Append(em.CreateAttribute("taskAffinity", Application.identifier));
            em.Attributes.Append(em.CreateAttribute("label",  "@string/app_name"));
            em.Attributes.Append(em.CreateAttribute("theme",  "@android:style/Theme.Translucent.NoTitleBar"));
            em.Attributes.Append(em.CreateAttribute("exported",  "true"));
            em.Attributes.Append(em.CreateAttribute("launchMode",  "singleTask"));
            appNode.AppendChild(em);
            document.SetPermission("android.permission.INTERNET");
            document.SetPermission("android.permission.ACCESS_WIFI_STATE");
            document.SetPermission("android.permission.ACCESS_NETWORK_STATE");
        }
        document.Save();
        //AssetDatabase.Refresh();
    }
    //static void SetPermission(XmlDocument xdoc,string value)
    //{
    //    var node = FindNode(xdoc, "/manifest/uses-permission", "android:name", value);
    //    if (node == null)
    //    {
    //        var manifestNode = xdoc.SelectSingleNode("/manifest");
    //        var ele = xdoc.CreateElement("uses-permission");
    //        ele.Attributes.Append(ele.CreateAttribute("name", value));
    //        manifestNode.AppendChild(ele);
    //    }
    //}
    //public static XmlAttribute CreateAttribute(this XmlNode node, string attributeName, string value)
    //{
    //    try
    //    {
    //        XmlDocument doc = node.OwnerDocument;
    //        XmlAttribute attr = null;
            
    //        attr = doc.CreateAttribute(attributeName, "http://schemas.android.com/apk/res/android");
    //        attr.Value = value;
    //        node.Attributes.SetNamedItem(attr);
    //        return attr;
    //    }
    //    catch (System.Exception err)
    //    {
    //        string desc = err.Message;
    //        return null;
    //    }
    //}
    //static XmlNode FindNode(XmlDocument xmlDoc, string xpath, string attributeName, string attributeValue)
    //{
    //    XmlNodeList nodes = xmlDoc.SelectNodes(xpath);
    //    //Debug.Log(nodes.Count);
    //    for (int i = 0; i < nodes.Count; i++)
    //    {
    //        XmlNode node = nodes.Item(i);
    //        var att = node.Attributes[attributeName];
    //        if (att != null)
    //        {
    //            if (att.Value == attributeValue)
    //            {
    //                return node;
    //            }
    //        }
    //    }
    //    return null;
    //}
}
