using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton_Match : MonoBehaviour
{
    public MatchSystemController _matchSys;
    void OnMouseDown()
    {
        _matchSys.ResetButton();
    }

}
