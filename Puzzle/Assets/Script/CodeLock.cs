using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    //for placing green/red light object.
    public Transform lightBulb;

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            greenLight();
        }
        else
        {
            Debug.Log("wrong code");
        }
    }

    //make the light green
    void greenLight()
    {
        var cubeRenderer = lightBulb.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);

        var lightOn = lightBulb.GetComponent<CorrectLightBulb>();
        lightOn.turnOn();
    }

    public void SetValue(string value)
    {
        placeInCode++;

        //value added to attempted code when button is hit if it's less than code length
        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        //check if the length of code match the code length, if it does it checks code then reset the attpempted code (the one player put in)
        if (placeInCode == codeLength)
        {
            CheckCode();

            //reset the attempted codce and place incode back to default so player can try again.
            attemptedCode = "";
            placeInCode = 0;

            //put if in here for success and fail sound
        }
    }
}
