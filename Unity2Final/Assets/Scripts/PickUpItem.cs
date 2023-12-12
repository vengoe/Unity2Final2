using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject particleOBJ;
    public MessageBox msg;

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("MessageBox").GetComponent<MessageBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        transform.Rotate(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(particleOBJ, transform.position, Quaternion.identity);
            msg.CollectFood(gameObject.name);
            Destroy(gameObject);
        }
    }
}
