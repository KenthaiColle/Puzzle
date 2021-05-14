using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam; //ref to main camera
    Ray ray; //ref to our fire button
    CodeLock codeLock;

    //int reachRange = 100; put after out hit if needed range

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }
    }
    void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Use main Cam

        if (Physics.Raycast(ray, out hit)) //Shot out ray to to check if it touches an object and return hit.
        {
            codeLock = hit.transform.gameObject.GetComponent<CodeLock>(); //Check if the object has CodeLock Script
            SimonButton simonButton = hit.transform.gameObject.GetComponent<SimonButton>(); // checks obj name and store it in objName

            if (codeLock != null) //for Codelock puzzle, if script CodeLock return not null 
            {
                Debug.Log("we hit an object! " + hit.transform.gameObject.name);
                string value = hit.transform.name;
                codeLock.SetValue(value);
            }

            if(hit.transform.tag.Equals("SimonButton")) //For Simon button puzzle
            {
                Debug.Log("we hit an object! " + hit.transform.gameObject.name);
                simonButton.Activate(); //use activate function in simon Button script
                

            }
        }
    }

    
}
