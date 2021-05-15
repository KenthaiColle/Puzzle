using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Simon : MonoBehaviour
{
    
    [SerializeField]
    bool debugMode = false; //for activating LogChoices

    [SerializeField]
    List<SimonButton> buttons = new List<SimonButton>();

    [SerializeField]
    float waitBetweenPress = 0.5f;//time for waiting betweeen presses


    List<int> choices = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> TakeTurn(int numberOfChoices)
    {
        //create array for number of choices
        choices = new List<int>();

        //for loop to pick random number
        for (int i = 0; i < numberOfChoices; i++)
        {
            choices.Add(UnityEngine.Random.Range(0, 4)); //RNG between 0 and 3
            
        }

        if(debugMode)//if debug is true
        {
            LogChoices(choices, numberOfChoices);//activate log for simon choices
        }

        StartCoroutine(PressButtons()); //startCoroutine Press button
        return choices;
    }

    IEnumerator PressButtons()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            buttons[choices[i]].Activate(); //Make simon play the buttons
            yield return new WaitForSeconds(waitBetweenPress);//wait between the presses
        }
    }

    private void LogChoices(List<int> choices, int noc)
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
