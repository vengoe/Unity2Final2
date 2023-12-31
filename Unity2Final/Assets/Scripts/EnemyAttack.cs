using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackTransform;
    [Range(0, 4)]
    public float attackRadius = 0.25f;
    public NavMeshBasic agentScript;
    [SerializeField] private AudioSource AttackSoundEffect;
    public void AttackPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackTransform.position, attackRadius);

        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                hitCollider.GetComponent<PlayerHealth>().TakeDamage(30.0f);
                AttackSoundEffect.Play();
            }
        }
        agentScript.isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackTransform.position, attackRadius);
    }


}
