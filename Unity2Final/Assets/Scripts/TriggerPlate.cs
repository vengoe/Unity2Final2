using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public RayCastPlayer raycastScript;
    [SerializeField]
    string objTag;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "Battery")
            {
                raycastScript.Battery = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "Battery")
            {
                raycastScript.Battery = false;
            }
        }
    }
}

