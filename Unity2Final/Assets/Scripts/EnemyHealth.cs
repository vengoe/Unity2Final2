using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image healthBar;
    public GameObject healthBarOBJ;
    public float enemyHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / enemyHealth;
        }
        if (currentHealth <= 0)
        {
            //Enemy Dead
            Dead();
        }
    }

    void Dead()
    {
        Destroy(healthBarOBJ);
        Destroy(gameObject);
    }
}
