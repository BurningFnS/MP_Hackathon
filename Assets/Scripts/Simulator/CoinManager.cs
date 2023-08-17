using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;
    public int currentCoins;
    public int cashAtHand;
    public Text coinText;
    public Text ageText;

    public int currentAge;
    public int defaultAge = 25;

    public Bank bank;

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("CollectedCoins");
        cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        currentAge = PlayerPrefs.GetInt("CurrentAge");

        currentCoins = totalCoins + cashAtHand;

        // Optionally, you can update the player's coins display or any other relevant UI elements
        UpdateCoinDisplay();
        ageText.text = "" + currentAge;
    }

    public void UpdateCoinDisplay()
    {
        // Code to update the UI display of the collected coins
        // For example, you could set the text of a UI Text component to show the totalCoins value.

        coinText.text = "" + currentCoins;
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("CurrentCoins", currentCoins);
        currentAge = currentAge + 5;
        PlayerPrefs.SetInt("CurrentAge", currentAge);

        PlayerPrefs.SetFloat("BankOfRashidBalance", bank.bankBalance[0]);
        PlayerPrefs.SetFloat("BankOfJunnieBalance", bank.bankBalance[1]);
        PlayerPrefs.SetFloat("BankOfFooBalance", bank.bankBalance[2]);

        SceneManager.LoadScene("Level");
    }
}
