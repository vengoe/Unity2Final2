using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricWater : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaterDamage());
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(WaterDamage());
    }

    IEnumerator WaterDamage()
    {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<PlayerHealth>().TakeDamage(20);
        StartCoroutine(WaterDamage());
    }
}
