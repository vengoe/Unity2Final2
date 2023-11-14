using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    ItemCollector collector;
    // Start is called before the first frame update
    void Start()
    {
        collector = GameObject.Find("CoinHUD").GetComponent<ItemCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collector.ItemCollect();
            Destroy(gameObject);
        }
    }
}
