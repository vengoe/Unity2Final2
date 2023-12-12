using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPCharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    public float gravity = -9.8f;
    public float gravityMultiplier = 3.0f;
    public float jumpStrength = -10.0f;
    float velocity = 1;


    CharacterController charControl;

   

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveX,0,moveZ);

        movement = Vector3.ClampMagnitude(movement, speed);

        if(IsGrounded() && velocity < 0)
        {
            velocity = -1;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        movement.y = velocity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charControl.Move(movement);

    }

    bool IsGrounded()
    {
        return charControl.isGrounded;
    }

    void Jump()
    {
        if (!IsGrounded()) 
        {
            return;
        }

        velocity *= jumpStrength;

    } 
}
