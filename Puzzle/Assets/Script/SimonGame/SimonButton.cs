using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton : MonoBehaviour
{

    public event Action<SimonButton> buttonPressed; //An event so that other script can link to it  

    [SerializeField] //make it visible in the editor
    Color buttonColor;

    [SerializeField]
    float buttonSpeed = 0.1f;

    Material material;
    AudioSource audio;

    public float OriginalZScale;
    public float ZScale;
    // Start is called before the first frame update

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        material = GetComponent<Renderer>().material; //get material component
        material.color = buttonColor; // set buttonColor to the obj current material color
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine; //create coroutine variable
    internal void Activate()
    {
        //if the object is still animating, so it prevents more animation from being called
        if (isAnimating) 
        {
            return; 
        }

        //Debug.Log(gameObject.name + " has been pressed");

        // stop coroutine if there's already one running to prevent lots running at the same time
        if (coroutine != null) 
        {
            StopCoroutine(coroutine);
        }

        audio.Play();
        Invoke("StopPlayingAudio", 0.2f);

        coroutine = StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material)); //set corotine to ChangeObjColor

        //if buttonPress is not null it gets called
        if (buttonPressed != null) 
        {
            buttonPressed(this);
        }
    }

    void StopPlayingAudio()
    {
        audio.Stop();
    }


    bool isAnimating = false;

    private IEnumerator ChangeObjColor(Material material) //Change colour material to black after 1 sec.
    {
        //set isAnimating to true
        isAnimating = true;

        // change the scale of object over buttonSpeeds (seconds)
        LeanTween.scaleZ(gameObject, ZScale, buttonSpeed);

        //Set material colour to black
        material.color = Color.black; 

        //wait for 0.1f
        yield return new WaitForSeconds(0.1f);

        //change colour back to original colour
        material.color = buttonColor;

        // change the scale of object over buttonSpeeds (seconds)
        LeanTween.scaleZ(gameObject, OriginalZScale, buttonSpeed);

        //set isAnimating to flase
        isAnimating = false; 
    }
}
