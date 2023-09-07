using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins; //Keep track of number of coins
    public Text coinText; //Reference to number of coins UI
    public GameObject startText; //Reference to StartText

    public static bool isGameStarted; //bool to check if game has started

    void Start()
    {
        //Set number of coins to 0 on start
        numberOfCoins = 0;
        isGameStarted = false; //set bool to false on start
    }

    void Update()
    {
        //Make sure coins can never be negative
        if (numberOfCoins < 0)
        {
            numberOfCoins = 0;
        }
        //Update the text UI on the current number of coins
        coinText.text = "" + numberOfCoins;

        //Check for a tap to start the game and destroy the startText
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Time.timeScale = 1f;
            Destroy(startText);
        }
    }
}
