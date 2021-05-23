using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LoginScript : MonoBehaviour
{
    public CanvasGroup StartControl;
    public CanvasGroup login;
    public InputField User;
    public InputField password;

    
    // Start is called before the first frame update
    void Start()
    {
        StartControl.alpha = 0f; //this makes everything transparent
        StartControl.blocksRaycasts = false; //this prevents the UI element to receive input events
        Debug.Log("This is working");
    }

    public void OnMouseDown()
    {
        Debug.Log("hello " + User.text);
        if (User.text == "v0xbHypu2ybV" && password.text == "xkrUL5gdQ46")
        {
            StartControl.alpha = 1f;
            StartControl.blocksRaycasts = true;

            login.alpha = 0f; //this makes everything transparent
            login.blocksRaycasts = false; //this prevents the UI element to receive input events
        }
        else
        {
            //DisplayDialog("Access Denied", "Wrong Password", "ok", "cancel");
            return;
        }
    }

    //public static bool DisplayDialog(string title, string message, string ok, string cancel = "");
}
