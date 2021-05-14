using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    
    [SerializeField]
    bool debugMode = false; //for activating LogChoices

    List<int> choices = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    int numberOfChoices = 2;

    // Update is called once per frame
    void Update()
    {
        TakeTurn(numberOfChoices++); //every turn it increases the amount it picks
    }

    public int[] TakeTurn(int numberOfChoices)
    {
        //create array for number of choices
        int[] choices = new int[numberOfChoices];

        //for loop to pick random number
        for (int i = 0; i < numberOfChoices; i++)
        {
            choices[i] = UnityEngine.Random.Range(0, 4); //RNG between 0 and 3
        }

        if(debugMode)//if debug is true
        {
            LogChoices(choices, numberOfChoices);//activate log for simon choices
        }
        

        return choices;
    }

    private void LogChoices(int[] choices, int noc)
    {
        //for testing number of choices
        string outPutString = choices[0].ToString();
        for (int i = 1; i < noc; i++)
        {
            Debug.Log("Simon Chose the following numbers: " + choices[i]);
            outPutString += ", " + choices[i].ToString();
        }

        Debug.Log(outPutString);
    }
}
