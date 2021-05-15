using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SimonController : MonoBehaviour
{
    [SerializeField]
    Simon simonPlayer;//ref to simon
    [SerializeField]
    Player player; //ref to player
    [SerializeField]
    List<SimonButton> button = new List<SimonButton>();

    bool turnTaken = false; //If simon has taken turn or not

    int turn = 0; //If it's 0 its simon turn, if it's 1 its the player turn.

    public int numberOfPresses = 2;

    // Start is called before the first frame update
    void Start()
    {
        foreach(SimonButton b in button)
        {
            b.buttonPressed += HandleButtonPressed;
        }

        simonPlayer.TakeTurn(numberOfPresses); //Call simon to take the turn
        turnTaken = true;
    }


    int playerButtonPress = 0;
    private void HandleButtonPressed(SimonButton obj)
    {
        Debug.Log("SimonGame here, a button was pressed: " + obj.name);

        if (turn == 0)
        {
            simonsTurn.Add(obj.name); //Add button to simon list
        }

        if (turn == 1)
        {
            if(playerButtonPress == numberOfPresses - 1)
            {
                Debug.Log("Great job, you successfully repeated simon's pattern");
                numberOfPresses++;
                Invoke("SwitchTurnToSimon", 2f); //Call a new method afer a certain amount of time
                return;
            }

            if (simonsTurn[playerButtonPress].Equals(obj.name)) //checks if the player press the same button as simon button press in order
            {
                Debug.Log("you hit the right button");
                
            }
            else //If player incorrectly click the button
            {
                Debug.Log("You hit the wrong button, game over!");
                numberOfPresses = 2;
                player.isOurTurn = false; // to prevent the player from being able to click right away
                Invoke("SwitchTurnToSimon", 1f);

                return;
            }
            playerButtonPress++;
        }

    }

    void SwitchTurnToSimon() // Set back most value to default and clear simon's memory/list
    {
        
        turn = 0;
        player.isOurTurn = false;
        turnTaken = false;
        playerButtonPress = 0;
        simonsTurn.Clear();
    }
    void SwitchTurnToPlayer() // Set back most value to default and clear simon's memory/list
    {
        turn = 1;
        player.isOurTurn = true;
    }

    List<string> simonsTurn = new List<string>();
    

    // Update is called once per frame
    void Update()
    {
        //Simon's turn if turn is not taken and turn == 0
        if (turn == 0 && !turnTaken)
        {
            simonPlayer.TakeTurn(numberOfPresses);
            turnTaken = true;
            
        }
        //if turn is 0 but turn is taken the log shows what simon picks as well as make turn = 1
        else if (turn == 0 && turnTaken)
        {
            if (simonsTurn.Count == numberOfPresses)
            {
                Debug.Log("Simon has finished his turn: " + simonsSelection() + " Now it's your turn to play!");
                Invoke("SwitchTurnToPlayer", 1f);
            }

        }
        //player's turn
        if (turn == 1)
        {

        }

    }

    private string simonsSelection()
    {
        string simonsSelectionString = "";
        foreach(string s in simonsTurn)
        {
            simonsSelectionString += s + ", ";
        }
        return simonsSelectionString;
    }
}
