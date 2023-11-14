using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float speed = 1.0f;
    public float distance = 3.0f;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distMoved = Mathf.PingPong(Time.time - startTime, distance/speed);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, distMoved / distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
