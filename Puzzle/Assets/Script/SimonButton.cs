using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton : MonoBehaviour
{
    [SerializeField] //make it visible in the editor
    Color buttonColor;

    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material; //get material component
        material.color = buttonColor; // set buttonColor to the obj current material color
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine; //create coroutine variable
    internal void Activate()
    {
        if (coroutine != null) // stop coroutine if there's already one running to prevent lots running at the same time
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material)); //set corotine to ChangeObjColor
    }
    private IEnumerator ChangeObjColor(Material material) //Change colour material to black after 1 sec.
    {
        material.color = Color.black;
        yield return new WaitForSeconds(1f);
        material.color = buttonColor;
    }
}
