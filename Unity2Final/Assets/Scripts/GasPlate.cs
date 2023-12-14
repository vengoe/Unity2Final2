using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GasPlate : MonoBehaviour
{
    public RayCastPlayer raycastScript;
    [SerializeField]
    string objTag;
    public GameObject InRoomLight;
    public GameObject InRoomLight2;
    public float timeDelay;

    public GameObject EscapePod;

    public Camera cutsceneCamera;
    public Camera playerCamera;

    public GameObject Fire;

    int Counter = 0;
     

    public void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            raycastScript.Gas = true;
            Fire.SetActive(true);
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
        InRoomLight.GetComponent<Light>().color = Color.green;
        InRoomLight2.GetComponent<Light>().color = Color.green;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Cutscene());


    }
    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(0.00000001f);
        Counter++;
        if(Counter == 1000)
        {
            SceneManager.LoadScene(5);
        }
        playerCamera.enabled = false;
        cutsceneCamera.enabled = true;
        EscapePod.GetComponent<Transform>().position += new Vector3(0, 0.75f, 0);
        StartCoroutine(Cutscene());
    }

}


