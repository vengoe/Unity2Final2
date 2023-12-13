using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GasPlate : MonoBehaviour
{
    public RayCastPlayer raycastScript;
    [SerializeField]
    string objTag;
    public GameObject InRoomLight;
    public GameObject InRoomLight2;
    public float timeDelay;

    public void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            raycastScript.Gas = true;
            StartCoroutine(SwitchLight());

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            raycastScript.Gas = false; 
        }
    }
    IEnumerator SwitchLight()
    {
        yield return new WaitForSeconds(2.0f);
        InRoomLight.GetComponent<Light>().color = Color.green;
        InRoomLight2.GetComponent<Light>().color = Color.green;
        yield return new WaitForSeconds(5.0f);
        
    }
}

