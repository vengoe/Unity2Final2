using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPlayerName : MonoBehaviour
{
    string playerName;
    GameManager gm;
    TMP_Text playerNameDisplay;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerName = gm.playerName;
        playerNameDisplay = GetComponent<TMP_Text>();
        playerNameDisplay.text = playerName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
