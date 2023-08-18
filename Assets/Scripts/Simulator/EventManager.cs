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

    public GameObject[] randomEventPanel;

    void Start()
    {
        int waterBill = PlayerPrefs.GetInt("WaterBill");
        int elecBill = PlayerPrefs.GetInt("ElectricalBill");


        for (int i = 0; i < livingExpenses.Length; i++)
        {
            int changeInCostOfLiving = Random.Range(-50, 100);
            if (i == 0)
            {
                livingExpenses[i] = waterBill + changeInCostOfLiving;
                livingExpensesText[i].text = "Water Bill: " + livingExpenses[0];
                PlayerPrefs.SetInt("WaterBill", livingExpenses[i]);
            }
            if (i == 1)
            {
                livingExpenses[i] = elecBill + changeInCostOfLiving;
                livingExpensesText[i].text = "Electrical Bill: " + livingExpenses[1];
                PlayerPrefs.SetInt("ElectricalBill", livingExpenses[i]);
            }
            if (i == 2)
            {
                livingExpenses[i] = livingExpenses[0] + livingExpenses[1];
                livingExpensesText[i].text = "Total Bill: " + livingExpenses[i];
            }
        }

        //Show expenses panel
        yourExpenses.SetActive(true);
        BuildingClickHandler.canClickOnBuildings = false;
    }

    public void Pay()
    {
        coinManager.currentCoins -= livingExpenses[2];
        coinManager.UpdateCoinDisplay();
        yourExpenses.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;

        //randomEventPanel[Random.Range(0, randomEventPanel.Length)].SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
