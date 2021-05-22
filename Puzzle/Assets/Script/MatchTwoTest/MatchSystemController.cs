using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystemController : MonoBehaviour
{
    public RightMatchObject _currentRight; //current selected right
    public LeftMatchObject _currentLeft; //current selected left
    public bool leftfull = false; //If left is clicked then you can't click another left object
    public bool rightfull = true; //If right is clicked then you can't click another right object
    // Start is called before the first frame update

    public int correctMatches = 4;
    public int attemptedMatches = 0;

    public RightMatchObject _Right1;
    public RightMatchObject _Right2;
    public RightMatchObject _Right3;
    public RightMatchObject _Right4;

    public LeftMatchObject _Left1;
    public LeftMatchObject _Left2;
    public LeftMatchObject _Left3;
    public LeftMatchObject _Left4;

    void CheckLeftAndRight()
    {
        if (_currentRight.numberForMatching == _currentLeft.numberForMatching)
        {
            attemptedMatches++;
            Reset();
            CheckMatchCount();
            Debug.Log(attemptedMatches);
        }
        else
        {
            attemptedMatches--;
            Reset();
            CheckMatchCount();
            Debug.Log(attemptedMatches);
        }
    }

    void CheckMatchCount()
    {
        if(attemptedMatches == correctMatches)
        {
            //turn on light here as well as sound
            Debug.Log("You Won!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentLeft != null && _currentRight != null)
        {
            CheckLeftAndRight();
        }
        
    }
    public void Reset()
    {
        _currentLeft = null;
        _currentRight = null;
    }
}
