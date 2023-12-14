using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshBasic : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public Animator anim;

    public bool isAttacking = false;
    public PlayerHealth health;
    bool gameOverAnim = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        if (Vector3.Distance(player.position, transform.position) < agent.stoppingDistance && !isAttacking) {
            isAttacking = true;
            anim.SetTrigger("Attack");

        }
        anim.SetFloat("Move", agent.velocity.magnitude);
    }
}
