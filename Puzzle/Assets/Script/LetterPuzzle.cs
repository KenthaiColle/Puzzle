using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzle : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentLetter = 0;



    // Update is called once per frame
    void Update()
    {
        if(currentLetter == 0)
        {
            //Make this A
        }
        if (currentLetter == 1)
        {
            //Make this B
        }
        if (currentLetter == 2)
        {
            //Make this C
        }
        if (currentLetter == 3)
        {
            //Make this D
        }
        if (currentLetter == 4)
        {
            //Make this E
        }
        if (currentLetter == 5)
        {
            //Make this F
        }
    }

    //call on the + - button 
    public void updateCurrentLetterUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        currentLetter++;
    }
    public void updateCurrentLetterDown()
    {
        currentLetter--;
    }
}
