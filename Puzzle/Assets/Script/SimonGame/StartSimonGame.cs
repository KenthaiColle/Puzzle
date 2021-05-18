using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimonGame : MonoBehaviour
{
    [SerializeField]
    SimonController simon;

    private void OnMouseDown()
    {
        simon.StartGame();
    }
}
