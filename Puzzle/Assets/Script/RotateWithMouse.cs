using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
     [SerializeField] float rotationSpeed = 100f;
	 bool dragging = false;
	 Rigidbody rb;
 
     void Start()
     {
         rb = GetComponent<Rigidbody>();
     }
	 
	 void OnMouseDrag()
     {
		dragging = true;
		
     }
 
     void Update()
     {
		//Left mouse hold
		if (Input.GetMouseButtonUp(0))
			dragging = false;
		
     }
	 void FixedUpdate(){
		 if (dragging){
			 float x = Input.GetAxis ("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
			 float y = Input.GetAxis ("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
			 
			//Rotate on Y axis
			 rb.AddTorque (Vector3.down*x);
			//Rotate on X axis
			 rb.AddTorque (Vector3.right*y);
		 }
	 }
			 
}
