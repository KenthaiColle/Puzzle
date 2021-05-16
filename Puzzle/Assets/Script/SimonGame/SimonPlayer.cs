using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonPlayer : MonoBehaviour
{
    Camera cam; //ref to main camera
    Ray ray; //ref to our fire button

    public bool isOurTurn = false;

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
            SimonButton simonButton = hit.transform.gameObject.GetComponent<SimonButton>(); // get SimonButton script

            if (!isOurTurn) //if it's not our turn can't trigger anything
            {
                return;
            }
            else if (isOurTurn) //if it is our turn the player can trigger simon button
            {
                if (hit.transform.tag.Equals("SimonButton")) //For Simon button puzzle
                {
                    //Debug.Log("we hit an object! " + hit.transform.gameObject.name);
                    simonButton.Activate(); //use activate function in simon Button script


                }
            }
            
        }
    }

    
}

