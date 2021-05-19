using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Port : MonoBehaviour
{
    public MatchEntity _ownMatchEntity;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the game object has MovablePair or not, if yes then it calls PairObjectInteraction.
        if (other.gameObject.TryGetComponent(out MovablePair CollideMovable))
        {
            _ownMatchEntity.PairObjectInteraction(true, CollideMovable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Opposite happens here
        if (other.gameObject.TryGetComponent(out MovablePair CollideMovable))
        {
            _ownMatchEntity.PairObjectInteraction(false, CollideMovable);
        }
    }


}
