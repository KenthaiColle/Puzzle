using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton_Archived : MonoBehaviour
{
    Camera cam; //ref to main camera
    Ray ray; //ref to our fire button
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // unity gives the current camera
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Someone pressed the fire button");
            ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //out just allow raycast to return data imidiately instead of having return in an other class
            {
                Debug.Log("we hit an object! " + hit.transform.gameObject.name);
                StartCoroutine(ChangeObjColor(hit.transform.GetComponent<Renderer>().material));
            }
        }
    }

    private IEnumerator ChangeObjColor(Material material)
    {
        Color originalColor = material.color;

        material.color = Color.black;
        yield return new WaitForSeconds(1f);

        material.color = originalColor;
    }
}
