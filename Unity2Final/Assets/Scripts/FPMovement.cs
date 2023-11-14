using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Automatically adds character controller component to GAME OBJECT
[RequireComponent(typeof(CharacterController))]
public class FPMovement : MonoBehaviour
{
    public float speed = 10;
    float h, v;
    public float gravity = -9.8f;
    public float jumpStrength = 10.0f;
    float velocity;
    float gravityMultiplier = 3.0f;


    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = h * speed;
        float moveZ = v * speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);

        movement = Vector3.ClampMagnitude(movement, speed);

        if (IsGrounded() && velocity < 0)
        {
            velocity = -1;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        movement.y = velocity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }


    public void MoveInput(InputAction.CallbackContext ctx)
    {
        h = ctx.ReadValue<Vector2>().x;
        v = ctx.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!IsGrounded())
        {
            return;
        }

        if (ctx.performed)
        {
            velocity *= jumpStrength;
        }
    }

    bool IsGrounded()
    {
        return controller.isGrounded;
    }
}
