using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystemController : MonoBehaviour
{
    public RightMatchObject _currentRight = null; //current selected right
    public LeftMatchObject _currentLeft = null; //current selected left
    public bool leftfull = false; //If left is clicked then you can't click another left object
    public bool rightfull = false; //If right is clicked then you can't click another right object
    // Start is called before the first frame update
    //correctMatches = goal, attemptedMatches needs to = to correct, totalMatches cout how many matches has been done
    public int correctMatches = 4;
    public int attemptedMatches = 0;
    public int totalMatches = 0;
    //all right matching object
    public RightMatchObject _Right1;
    public RightMatchObject _Right2;
    public RightMatchObject _Right3;
    public RightMatchObject _Right4;
    //all left matching object
    public LeftMatchObject _Left1;
    public LeftMatchObject _Left2;
    public LeftMatchObject _Left3;
    public LeftMatchObject _Left4;
    //Lightbulb to show success
    public Transform lightBulb;
    public CorrectLightBulb _light;

    public AudioSource fail;
    public AudioSource success;

    void CheckLeftAndRight()
    {
        //check left and right number if it's the same then attempted matches get ++ otherwise --. also increase total matches
        if (_currentRight.numberForMatching == _currentLeft.numberForMatching)
        {
            attemptedMatches++;
            totalMatches++;
            CheckAndReset();
            //Debug.Log(attemptedMatches);
        }
        else
        {
            attemptedMatches--;
            totalMatches++;
            CheckAndReset();
            //Debug.Log(attemptedMatches);
        }
    }
    void CheckAndReset()
    {
        ResetValues();
        CheckMatchCount();
    }

    void CheckMatchCount()
    {
        if(attemptedMatches == correctMatches)
        {
            //turn on light here as well as sound
            var cubeRenderer = lightBulb.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);

            //Set the light on to true for win condition
            _light.turnOn();
            success.Play();
            //Debug.Log("You Won!");
        }
        else if (totalMatches == correctMatches)
        {
            ResetValues();
            ResetAllMatchObj();
            attemptedMatches = 0;
            totalMatches = 0;
            //Debug.Log("You Lost!");
            fail.Play();
        }
    }

    void ResetAllMatchObj()
    {
        //Reset Right Obj
        _Right1.finishedMatching = false;
        _Right1.ResetColour();
        _Right2.finishedMatching = false;
        _Right2.ResetColour();
        _Right3.finishedMatching = false;
        _Right3.ResetColour();
        _Right4.finishedMatching = false;
        _Right4.ResetColour();
        //reset Left Obj
        _Left1.finishedMatching = false;
        _Left1.ResetColour();
        _Left2.finishedMatching = false;
        _Left2.ResetColour();
        _Left3.finishedMatching = false;
        _Left3.ResetColour();
        _Left4.finishedMatching = false;
        _Left4.ResetColour();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentLeft != null && _currentRight != null)
        {
            CheckLeftAndRight();
        }
        
    }
    public void ResetValues()
    {
        _currentLeft = null;
        _currentRight = null;
        leftfull = false;
        rightfull = false;
    }

    private void Start()
    {
        Debug.Log(rightfull);
    }
}
