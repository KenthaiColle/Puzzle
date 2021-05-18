using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePair : MonoBehaviour
{
    private Camera _mainCamera;
    private float _cameraZDistance;
    private Vector3 _initialPosition;
    bool _connected;

    private const string _portTag = "Port"; //Hard coded tag
    private const float _dragResponseThreshold = 2; //Hardcode drag distance


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _cameraZDistance = _mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }

    private void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraZDistance); //z axis added to screen point

        Vector3 NewWorldPosition = _mainCamera.ScreenToWorldPoint(ScreenPosition);

        //If it's not connected (As in in range of auto insert) it will reset the position
        if (!_connected)
        {
            transform.position = NewWorldPosition;
        }
        //If the Distance is bigger than the DragResponse (drag the connceted pair away from the port) it will reset the position
        else if (Vector3.Distance(transform.position, NewWorldPosition) > _dragResponseThreshold)
        {
            _connected = false;
        }
    }

    //If mouse release is detected
    private void OnMouseUp()
    {
        //If it's not connected after letting go of the mouse it reset position.
        if (!_connected)
        {
            ResetPosition();
        }
    }

    //Get position of game object
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    //Set the initial position
    public void SetInitialPosition(Vector3 NewPosition)
    {
        _initialPosition = NewPosition;
        transform.position = _initialPosition;
    }

    //reset position to original position
    private void ResetPosition()
    {
        transform.position = _initialPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if other object has the port tag
        if (other.gameObject.CompareTag(_portTag))
        {
            //if it does connected become true and set the object to the position of the port.
            _connected = true;
            transform.position = other.transform.position;
        }
    }
}
