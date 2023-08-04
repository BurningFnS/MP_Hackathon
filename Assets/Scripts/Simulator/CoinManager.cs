using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int totalCoins = 0;
    public Text coinText;

    private void Start()
    {
        // Retrieve the number of collected coins from PlayerPrefs
        totalCoins = PlayerPrefs.GetInt("CollectedCoins", 0);

        // Optionally, you can update the player's coins display or any other relevant UI elements
        UpdateCoinDisplay();
    }

    private void UpdateCoinDisplay()
    {
        // Code to update the UI display of the collected coins
        // For example, you could set the text of a UI Text component to show the totalCoins value.
        coinText.text = "" + totalCoins;
    }  
}
