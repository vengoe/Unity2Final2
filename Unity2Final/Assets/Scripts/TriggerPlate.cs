using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public RayCastPlayer raycastScript;
    [SerializeField]
    string objTag;
    public GameObject Lightswitch;
    public GameObject InRoomLight;
    public float timeDelay;

    public void Start()
    {
        Lightswitch.GetComponent<Light>().intensity = 0;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            raycastScript.Battery = true;
            StartCoroutine(TurnOnLight());

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            raycastScript.Battery = false; 
        }
    }
    IEnumerator TurnOnLight()
    {
        yield return new WaitForSeconds(2.0f);
        Lightswitch.GetComponent<Light>().intensity = 325;
        InRoomLight.GetComponent<FlickerLights>().enabled = false;
        for(int i = 0; i < 7; i++) 
        {
            InRoomLight.GetComponent<Light>().enabled = false;
            timeDelay = Random.Range(0.01f, 0.15f);
            yield return new WaitForSeconds(timeDelay);
            InRoomLight.GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.01f, 0.15f);
            yield return new WaitForSeconds(timeDelay);
        }
        InRoomLight.GetComponent<Light>().intensity = 325;
    }
}

