using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxis { 
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
     
    }
   
    public RotationAxis axis = RotationAxis.MouseXAndY;

    public float sensitivityX = 10.0f;
    public float sensitivityY = 10.0f;

    public float minVerticalRotation = -45.0f;
    public float maxVerticalRotation = 45.0f;

    float verticalRotation = 0;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * sensitivityY;
            verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation,maxVerticalRotation);

            float horizontalRotation = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * sensitivityY;
            verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

            float deltaRotation = Input.GetAxis("Mouse X") * sensitivityX;
            float horizontalRotation = transform.localEulerAngles.y + deltaRotation;

            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
        
        
    }

    
}
