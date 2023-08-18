using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Text[] livingExpensesText;
    public int[] livingExpenses;
    public GameObject yourExpenses;
    public CoinManager coinManager;
    public GameObject LoseScreen;
    public Text loseText;

    void Start()
    {
        for (int i = 0; i < livingExpenses.Length; i++)
        {
            if(i == 0)
            {
                livingExpenses[i] = 100;
                livingExpensesText[i].text = "Water Bill: " + livingExpenses[0];
            }
            if(i == 1)
            {
                livingExpenses[i] = 100;
                livingExpensesText[i].text = "Electrical Bill: " + livingExpenses[1];
            }
            if(i == 2)
            {
                livingExpenses[i] = livingExpenses[0] + livingExpenses[1];
                livingExpensesText[i].text = "Total Bill: " + livingExpenses[i];
            }
        }

        if (coinManager.currentCoins >= livingExpenses[2])
        {
            yourExpenses.SetActive(true);
        }
        else if (coinManager.currentCoins < livingExpenses[2])
        {
            LoseScreen.SetActive(true);
            loseText.text = "You do not have enough to pay you your expenses";
        }
        else
        {
            LoseScreen.SetActive(true);
            loseText.text = "You have $0 in your\n savings, you do not have enough to live";
        }
    }

    public void Pay()
    {
        coinManager.currentCoins -= livingExpenses[2];
        coinManager.UpdateCoinDisplay();
        yourExpenses.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
