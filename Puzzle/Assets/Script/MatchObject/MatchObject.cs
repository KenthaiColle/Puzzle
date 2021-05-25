using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    //ref to button
    public OnOffButton _button1;
    public OnOffButton _button2;
    public OnOffButton _button3;
    public OnOffButton _button4;
    public OnOffButton _button5;
    public OnOffButton _button6;
    public OnOffButton _button7;
    public OnOffButton _button8;

    //ref to light
    public Transform lightBulb;
    public CorrectLightBulb _light;

    public AudioSource success;
    public AudioSource fail;
    public void CheckAllButtons()
    {
        if (_button1.on == _button1.mustBeOn && _button2.on == _button2.mustBeOn && _button3.on == _button3.mustBeOn && _button4.on == _button4.mustBeOn && _button5.on == _button5.mustBeOn && _button6.on == _button6.mustBeOn && _button7.on == _button7.mustBeOn && _button8.on == _button8.mustBeOn)
        {
            var cubeRenderer = lightBulb.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
            Debug.Log("Win");
            //Set the light on to true for win condition
            _light.turnOn();
            success.Play();
        }
        else
        {
            fail.Play();
        }
    }
}
