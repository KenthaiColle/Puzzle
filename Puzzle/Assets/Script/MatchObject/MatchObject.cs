using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public OnOffButton _button1;
    public Transform lightBulb;
    public CorrectLightBulb _light;

    public void CheckAllButtons()
    {
        if (_button1.on == true)
        {
            var cubeRenderer = lightBulb.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);

            //Set the light on to true for win condition
            _light.turnOn();
        }
    }
}
