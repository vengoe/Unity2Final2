using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MessageBox : MonoBehaviour
{
    TMP_Text messageBoxObj;
     public int itemsCollected = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        messageBoxObj = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.W) && messageBoxObj.enabled)
        {
            messageBoxObj.enabled = false;
        }*/
    }

    public void CollectFood(string msg)
    {
        itemsCollected--;
        messageBoxObj.enabled = true;
        messageBoxObj.text = $"You picked up the {msg}!";

        if (itemsCollected <= 0) {
            //You Win
            StartCoroutine(GameOver());
        }
        StartCoroutine(DisableText());
    }

    public IEnumerator DisableText()
    {
        yield return new WaitForSeconds(5.0f);
        messageBoxObj.enabled = false;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        messageBoxObj.text = $"You picked up all the items!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
