using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

    public Transform playerController;
    bool insideLadder;
    public float ladderSpeed = 3.5f;
    public FPMovement playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            playerInput.enabled = false;
            insideLadder = !insideLadder;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            playerInput.enabled = true;
            insideLadder = !insideLadder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (insideLadder && Input.GetKey("w"))
        {
            playerController.transform.position += Vector3.up / ladderSpeed;
        }
    }
}
