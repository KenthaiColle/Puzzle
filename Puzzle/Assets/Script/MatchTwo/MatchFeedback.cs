using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFeedback : MonoBehaviour
{
    public Material _matchMaterial;
    public Material _misMatchMaterial;

    private Renderer _renderer;
    
    void Start()
    {
        _renderer = transform.GetComponent<Renderer>();
    }

    public void ChangeMaterialWithMatch(bool IsCorrectMatch)
    {
        //set material with the material for match otherwise set the material for a mismatch
        if (IsCorrectMatch)
        {
            _renderer.material = _matchMaterial;
        }
        else
        {
            _renderer.material = _misMatchMaterial;
        }
    }


}
