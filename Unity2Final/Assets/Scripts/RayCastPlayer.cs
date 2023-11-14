using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastPlayer : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    bool holdingItem = false;
    GameObject heldObj;

    public bool redBox = false;
    public bool blueBox = false;

    public GameObject doorButton;
    public Animator leftdoor;
    public Animator rightdoor;
    bool doorUnlocked = false;
    MeshRenderer hitObj;
    public GameObject messageBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
        if (redBox && blueBox)
        {
            doorButton.GetComponent<Renderer>().material.color = Color.green;
            doorUnlocked = true;
        }
        else
        {
            doorButton.GetComponent<Renderer>().material.color = Color.red;
            doorUnlocked = false;
        }

        RaycastHit hit; ;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.collider.tag == "PickupItem" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
            }
            if (hit.collider.tag == "DoorButton" && doorUnlocked)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
                messageBox.SetActive(true);
            }
        }
        else if (hitObj != null)
        {
            hitObj.materials[1].SetFloat("_Scale", 1.0f);
            hitObj = null;
            if (messageBox.activeSelf)
            {
                messageBox.SetActive(false);
            }
        }
    }

    public void PickupItem(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("PickupItem"))
                {
                    hit.collider.GetComponent<PickUpOBJ>().Pickup();
                    heldObj = hit.collider.gameObject;
                    holdingItem = true;
                }
            }
        }
        if (ctx.canceled)
        {
            if (holdingItem)
            {
                heldObj.GetComponent<PickUpOBJ>().Pickup();
                holdingItem = false;
                heldObj = null;
            }
        }
    }
    public void InteractableObject(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("DoorButton") && doorUnlocked)
                {
                    leftdoor.SetTrigger("OpenDoor");
                    rightdoor.SetTrigger("DoorOpened");
                }
            }
        }
    }
}
