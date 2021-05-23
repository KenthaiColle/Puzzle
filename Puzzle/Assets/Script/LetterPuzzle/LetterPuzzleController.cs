using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzleController : MonoBehaviour
{
    //Reference to all the letters
    [SerializeField]
    private LetterPuzzle _letter1;
    [SerializeField]
    private LetterPuzzle _letter2;
    [SerializeField]
    private LetterPuzzle _letter3;
    [SerializeField]
    private LetterPuzzle _letter4;
    [SerializeField]
    private LetterPuzzle _letter5;
    [SerializeField]
    private LetterPuzzle _letter6;
    //ref to light
    [SerializeField]
    private CorrectLightBulb _lightBulb;

    public Transform lightBulb;

    public AudioSource fail;
    public AudioSource success;
    // Update is called once per frame
    public void CheckAnswer()
    {
        // && _letter2.currentLetter == 1 && _letter3.currentLetter == 2 && _letter4.currentLetter == 3 && _letter5.currentLetter == 4 && _letter6.currentLetter == 5
        if (_letter1.currentLetter == 0)
        {
            var cubeRenderer = lightBulb.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);

            _lightBulb.turnOn();
            success.Play();
        }
        else
        {
            fail.Play();
        }
    }
}
