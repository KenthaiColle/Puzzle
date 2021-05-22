using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzle : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentLetter = 0;
    public Material _A;
    public Material _B;
    public Material _C;
    public Material _D;
    public Material _E;
    public Material _F;

    public Renderer self;

    // Update is called once per frame
    void Update()
    {
        if(currentLetter == 0)
        {
            //Make this A
            self.material = _A;
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 1)
        {
            //Make this B
            self.material = _B;
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 2)
        {
            //Make this C
            //Debug.Log(currentLetter);
        }
        if (currentLetter == 3)
        {
            //Make this D
           // Debug.Log(currentLetter);
        }
        if (currentLetter == 4)
        {
            //Make this E
           // Debug.Log(currentLetter);
        }
        if (currentLetter == 5)
        {
            //Make this F
           // Debug.Log(currentLetter);
        }
    }

    //call on the + - button 
    public void updateCurrentLetterUp()
    {
        //if we do up to F, put a limit of 6 and reset it back to 0
        
        if(currentLetter < 6)
        {
            currentLetter++;
        }
        else
        {
            currentLetter = 0;
        }
    }
    public void updateCurrentLetterDown()
    {
        if (currentLetter < 0)
        {
            currentLetter--;
        }
        else
        {
            currentLetter = 0;
        }
        
    }
}
