using System;
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

    //Press and unpress button sound
    public AudioSource Pressed;
    public AudioSource UnPressed;

    //ButtonSpeed
    float buttonSpeed = 0.1f;

    //if the button is animating or not
    public bool isAnimating;

    //The Z value of original shape and pressed shape
    public float OriginalZScale;
    //Most pressed Value
    public float PressedZScale;
    //The more pressed value
    public float PressedZScaleStationary;

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

                        Pressed.Play();
                        StartCoroutine("PressAnimation");

                        
                        //Console.WriteLine("Done");
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
                    UnPressed.Play();
                    StartCoroutine("UnPressAnimation");
                    

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


    private IEnumerator PressAnimation()
    {
        LeanTween.scaleZ(gameObject, PressedZScale, buttonSpeed);

        yield return new WaitForSeconds(0.1f);

        LeanTween.scaleZ(gameObject, PressedZScaleStationary, buttonSpeed);
    }

    private IEnumerator UnPressAnimation()
    {
        LeanTween.scaleZ(gameObject, PressedZScale, buttonSpeed);

        yield return new WaitForSeconds(0.1f);

        LeanTween.scaleZ(gameObject, OriginalZScale, buttonSpeed);
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
