using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitMatchObject : MonoBehaviour
{
    public MatchObject _matchObject;

    void OnMouseDown()
    {
        Debug.Log("Work");
        _matchObject.CheckAllButtons();
    }
}
