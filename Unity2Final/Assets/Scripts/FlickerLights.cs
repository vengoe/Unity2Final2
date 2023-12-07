using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(LightFlicker());
        }
    }
    IEnumerator LightFlicker()
    {
        isFlickering=true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.4f, 0.9f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.4f, 0.9f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
