using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;
    public bool doorOpen = false;
   
    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
            //float newPosition = Mathf.SmoothDamp(transform.localRotation.x, target.localRotation.x, ref yVelocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
            //transform.rotation = Quaternion.Euler(newPosition, transform.rotation.y,transform.rotation.z);
        }
    }
}
