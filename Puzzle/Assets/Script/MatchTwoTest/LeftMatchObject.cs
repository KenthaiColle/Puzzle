using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMatchObject : MonoBehaviour
{
    public bool finishedMatching = false; //Check if this object has been matched
    public int numberForMatching; //For Matching with othe other side's object
    //For Matching with othe other side's object
    public LeftMatchObject selfMatchObj; //reference to script
    public Transform selfTransform; //referenece to self's transform
    public MatchSystemController _matchSystemController; // reference to controller

    private void OnMouseDown()
    {
        if (_matchSystemController.leftfull == false && finishedMatching == false)
        {
            var selfRenderer = selfTransform.GetComponent<Renderer>();
            selfRenderer.material.SetColor("_Color", Color.black);

            _matchSystemController.leftfull = true;
            finishedMatching = true;

            //Give the controller reference to this obj
            _matchSystemController._currentLeft = selfMatchObj;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
