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
    //public TMP_Text messageBoxObj;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;

    }


    private void Update()
    {
        if(playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / playerHealth;
        if (currentHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        gameOver = true;
        //messageBoxObj.text = $"You died Game Over!";
        //messageBoxObj.color = Color.red;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }
}
