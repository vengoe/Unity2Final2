using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadTrigger : MonoBehaviour
{
    public GameObject keypadUI;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            keypadUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            keypadUI.SetActive(false);
        }
    }
}
