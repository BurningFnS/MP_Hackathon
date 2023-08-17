using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Text[] livingExpensesText;
    public int[] livingExpenses;
    public GameObject yourExpenses;
    public CoinManager coinManager;

    void Start()
    {
        yourExpenses.SetActive(true);

        for (int i = 0; i < livingExpenses.Length; i++)
        {
            if(i == 0)
            {
                livingExpenses[0] = 100;
                livingExpensesText[0].text = "Water Bill: " + livingExpenses[0];
            }
            if(i == 1)
            {
                livingExpenses[1] = 100;
                livingExpensesText[1].text = "Electrical Bill: " + livingExpenses[1];
            }
            if(i == 2)
            {
                livingExpenses[2] = livingExpenses[0] + livingExpenses[1];
                livingExpensesText[2].text = "Total Bill: " + livingExpenses[2];
            }
        }
    }

    public void Pay()
    {
        coinManager.currentCoins -= livingExpenses[2];
        coinManager.UpdateCoinDisplay();
        yourExpenses.SetActive(false);
    }

}
