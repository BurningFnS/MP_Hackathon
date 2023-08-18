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
        int minNum = PlayerPrefs.GetInt("minExpenses");
        int maxNum = PlayerPrefs.GetInt("maxExpenses");

        for (int i = 0; i < livingExpenses.Length; i++)
        {
            if (i == 0)
            {
                livingExpenses[i] = Random.Range(minNum, maxNum);
                livingExpensesText[i].text = "Water Bill: " + livingExpenses[0];
            }
            if (i == 1)
            {
                livingExpenses[i] = Random.Range(minNum, maxNum);
                livingExpensesText[i].text = "Electrical Bill: " + livingExpenses[1];
            }
            if (i == 2)
            {
                livingExpenses[i] = livingExpenses[0] + livingExpenses[1];
                livingExpensesText[i].text = "Total Bill: " + livingExpenses[i];
            }
        }

        //Show expenses panel
        yourExpenses.SetActive(true);
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
