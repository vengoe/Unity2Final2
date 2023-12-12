using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class RBCharacterController : MonoBehaviour
{
    Vector2 moveDir;
    public float speed = 10;
    Rigidbody rb;
    float h, v;
    Vector3 inputVector;
    public float jumpHeight = 1.5f;
    public LayerMask rbGroundMask;
    public Animator anim;
    TMP_Text messageBox;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        messageBox = GameObject.Find("MessageBox").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        h = DampenValue(h, moveDir.x);
        v = DampenValue(v, moveDir.y);

        inputVector = new Vector3(h * speed, rb.velocity.y, v * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        rb.velocity = inputVector;
        float dist = 2;
        anim.SetFloat("Moving", moveDir.magnitude);
        //Time.timeScale = moveDir.magnitude;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, dist))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Door")) {
                messageBox.enabled = true;
                messageBox.text = "Press E to Open Door";
                messageBox.transform.GetComponent<MessageBox>().StartCoroutine("DisableText");
                
            }
            //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            //hit.transform.parent = this.transform;
        }
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        moveDir = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (GroundCheck())
        {
            StartCoroutine(JumpAnim());
            anim.SetTrigger("Jump");
        }
        
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        float dist = 5;
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, dist))
        {
            if (hit.collider.tag == "Door")
            {
                hit.collider.GetComponent<DoorScript>().doorOpen = true;            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }

    bool GroundCheck()
    {
        float dist = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, dist, rbGroundMask);
    }


    float DampenValue(float readValue, float moveDir)
    {
        readValue = Mathf.MoveTowards(readValue, moveDir, Time.deltaTime * 2);

        return readValue = Mathf.Clamp(readValue, -1,1);
    }

    IEnumerator JumpAnim()
    {
        yield return new WaitForSeconds(0.25f);
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
