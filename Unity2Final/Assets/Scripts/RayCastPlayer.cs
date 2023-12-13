using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastPlayer : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    bool holdingItem = false;
    GameObject heldObj;

    public bool Battery = false;

    public bool Gas = false;

    public Animator Door;

    public bool doorUnlocked = false;
    public bool Escape = false;
    MeshRenderer hitObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
        if (Battery)
        {
            doorUnlocked = true;
        }
        else
        {
            doorUnlocked = false;
        }
        if (Gas)
        {
            Escape = true;
        } else
        {
            Escape = false;

        }
        RaycastHit hit; ;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.collider.tag == "PickupItem" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();

            }

        }
        else if (hitObj != null)
        {
            hitObj = null;

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
        if (doorUnlocked)
        {
            Door.SetTrigger("OpenDoor");
        }
    }
}
