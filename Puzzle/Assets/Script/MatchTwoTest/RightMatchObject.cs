using System.Collections;
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

    public Material originalMaterial;

    public void OnMouseDown()
    {
        Debug.Log("Hello " + _matchSystemController.rightfull);
        if (_matchSystemController.rightfull == false && finishedMatching == false)
        {
            //Change colour to black to indicate matched
            var selfRenderer = selfTransform.GetComponent<Renderer>();
            selfRenderer.material.SetColor("_Color", Color.black);
            Debug.Log("Changed to Black");

            _matchSystemController._currentRight = selfMatchObj;
            _matchSystemController.rightfull = true;
            finishedMatching = true;
            //Give the controller reference to this obj
            
        }
           
    }

    public void ResetColour()
    {
        var selfRenderer = selfTransform.GetComponent<Renderer>();
        selfRenderer.material = originalMaterial;
    }

}
