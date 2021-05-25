﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    public GameObject button;
    public bool on = false; //If the button is on or off
    public bool mustBeOn = false; //Bool to check if the button is on or not whne it's supposed to

    public bool finished = false;

    public Material Green;
    public Material Red;

    // Update is called once per frame
    void Update()
    {
        if(finished == false)
        {
            if (Input.GetMouseButtonDown(0) && !on)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == button.name)
                    {
                        //Debug.Log("This is a Button");
                        on = true;
                        var cubeRenderer = button.GetComponent<Renderer>();
                        cubeRenderer.material = Green;
                        Console.WriteLine("Done");
                    }
                    else
                    {
                        //Debug.Log("This isn't a Button");
                    }
                }

            }
            else if (Input.GetMouseButtonDown(0) && on)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                }
                if (hit.transform.name == button.name)
                {
                    on = false;
                    var cubeRenderer = button.GetComponent<Renderer>();
                    cubeRenderer.material = Red;
                }
                else
                {
                    //Debug.Log("This isn't a Button");
                }

            }
        }
        else
        {
            return;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if(on == false)
        {
            var cubeRenderer = button.GetComponent<Renderer>();
            cubeRenderer.material = Red;
        }
        else if (on == true)
        {
            var cubeRenderer = button.GetComponent<Renderer>();
            cubeRenderer.material = Green;
        }
    }
}
