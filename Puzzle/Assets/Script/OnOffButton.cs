using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    public GameObject button;
    private bool on = false;


 

    // Update is called once per frame
    void Update()
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
                    cubeRenderer.material.SetColor("_Color", Color.green);
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
                cubeRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                //Debug.Log("This isn't a Button");
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(on == false)
        {
            var cubeRenderer = button.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
        else if (on == true)
        {
            var cubeRenderer = button.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
    }
}
