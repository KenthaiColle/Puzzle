using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Port : MonoBehaviour
{
    public MatchEntity _ownMatchEntity;

    private void OnTriggerEnter(Collider other)
    {
        //Upgrade to 2020
        if (other.gameObject.TryGetComponent())
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
