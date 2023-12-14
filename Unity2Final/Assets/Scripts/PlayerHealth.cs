using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth;
    public float currentHealth;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;

    }


    public void Update()
    {
        if(currentHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / playerHealth;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(4);
    }
}
