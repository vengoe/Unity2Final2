using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class KeyPadScipt : MonoBehaviour
{
    public string password;
    public string enterPWD;
    public TMP_Text keyPadDisplay;
    public int passDigits;
    public GameObject escapePod;
    public GameObject enterPodStand;
    public Camera cutsceneCamera;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        passDigits = password.Length;
        keyPadDisplay.text = "Enter Code";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)    
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (enterPWD.Length == passDigits)
        {
            if (enterPWD == password)
            {
                keyPadDisplay.text = "Correct PassCode";
                //make cutcene happen
                playerCamera.enabled = false;
                cutsceneCamera.enabled = true;
                Destroy(enterPodStand);
                escapePod.GetComponent<BoxCollider>().enabled = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                keyPadDisplay.text = "Incorrect Passcode";
                enterPWD = "";
                
            }
        }
    }

    public void ButtonNumber(string btnNum)
    {
        EnterCode(btnNum);
    }

    public void EnterCode(string keyEntered)
    {
        enterPWD += keyEntered;
        keyPadDisplay.text = enterPWD; 
    }
}
