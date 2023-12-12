using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    Vector3 targetPosition;
    [SerializeField]
    [Range(0f, 1f)]
    float moveSpeed = 0;
    int waypintIndex;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.5f * moveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) < 0.3f)
        {
            if (waypintIndex >= waypoints.Length - 1)
            {
                waypintIndex = 0;
            }
            else
            {
                waypintIndex++;
            }
            targetPosition = waypoints[waypintIndex].position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10.0f);
        }
    }
}
