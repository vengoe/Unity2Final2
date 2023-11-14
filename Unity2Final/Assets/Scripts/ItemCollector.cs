using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public int itemsCollected, itemsInLevel;
    public TMP_Text itemHUD;
    // Start is called before the first frame update
    void Start()
    {
        itemHUD.text = $"Coin {itemsCollected}/{itemsInLevel}";
    }

    public void ItemCollect()
    {
        itemsCollected++;
        itemHUD.text = $"Coin {itemsCollected}/{itemsInLevel}";

        if (itemsCollected >= itemsInLevel)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        itemHUD.text = $"You Collected all the Coins";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
