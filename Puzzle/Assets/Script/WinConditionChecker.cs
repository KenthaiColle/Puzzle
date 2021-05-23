using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionChecker : MonoBehaviour
{
    public CorrectLightBulb _LetterPuzzle;
    public CorrectLightBulb _Simon;
    public CorrectLightBulb _Code;
    public CorrectLightBulb _Match;
    public CorrectLightBulb _OnOff;

    // Update is called once per frame
    void Update()
    {
        if(_LetterPuzzle.on == true && _Simon.on == true && _Code.on == true && _Match.on == true && _OnOff.on == true)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
