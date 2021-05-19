using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchEntityManager : MonoBehaviour
{
    public List<Material> _colorMaterials; //The colour that the entity will have
    public List<MatchEntity> _matchEntities; //The entity that needs matching
    private int _targetMatchCount; //Target amount of matches e.g. 4 cubes need matching this would be 4
    private int _currentMatchCount = 0; //Counts how many correct matches there are currently


    //ADD ANOTHER FUNCTION LIKE START FOR RESET



    void Start()
    {
        //_matchEntities = transform.GetComponentInChildren<MatchEntity>().ToList();//Get component from the child object.
        _targetMatchCount = _matchEntities.Count;
        SetEntityColors();
        RandomizeMovablePairPlacement();
    }

    //Set each enity colours
    void SetEntityColors()
    {
        Shuffle(_colorMaterials); //Shuffle the orders of colour each time the game is played.

        for(int i = 0; 1 < _matchEntities.Count; i++)
        {
            _matchEntities[i].SetMaterialToPairs(_colorMaterials[i]);
        }
    }

    private void RandomizeMovablePairPlacement()
    {
        List<Vector3> movablePairPositions = new List<Vector3>();

        //Set the position of each peair
        for(int i = 0; i < _matchEntities.Count; i++)
        {
            movablePairPositions.Add(item: _matchEntities[i].GetMovablePairPosition());
        }

        Shuffle(movablePairPositions); //shuffle the position

        //Inform the matchEntities of the new position
        for(int i = 0; i < _matchEntities.Count; i++)
        {
            _matchEntities[i].SetMovablePairPosition(movablePairPositions[i]);
        }
    }

    public void NewMatchRecord(bool MatchConnected)
    {
        //if correct match ++ the current match
        if (MatchConnected)
        {
            _currentMatchCount++;
        }
        //if incorrect -- the current match
        else
        {
            _currentMatchCount--;
        }
        Debug.Log("Currently, there are " + _currentMatchCount + " matches.");

        //If the match and target match the things inside if activate
        if(_currentMatchCount == _targetMatchCount)
        {
            Debug.Log("Well Done! all paired");
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
