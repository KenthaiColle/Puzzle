﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMatchObject : MonoBehaviour
{
    public bool finishedMatching = false; //Check if this object has been matched
    public int numberForMatching;
    //For Matching with othe other side's object
    public RightMatchObject selfMatchObj; //Reference to self
    public Transform selfTransform;//referenece to self's transform
    public MatchSystemController _matchSystemController; // reference to controller


    private void OnMouseDown()
    {
        if (_matchSystemController.rightfull == false && finishedMatching == false)
        {
            //Change colour to black to indicate matched
            var selfRenderer = selfTransform.GetComponent<Renderer>();
            selfRenderer.material.SetColor("_Color", Color.black);

            _matchSystemController.rightfull = true;
            finishedMatching = true;
            //Give the controller reference to this obj
            _matchSystemController._currentRight = selfMatchObj;
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
