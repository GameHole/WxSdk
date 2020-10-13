using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo_Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //string appid = "wx7e44f6f0cb921e85";
        //WX.RegisteApp(appid);
        WX.onGetUserInfo += (a, b) =>
        {
            Debug.Log("LoginOver");
        };
        GetComponent<Button>().onClick.AddListener(()=>
        {
            WX.Login("dddddd");
        });
    }
}
