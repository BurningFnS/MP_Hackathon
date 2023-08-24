using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public Text[] livingExpensesText;
    public int[] livingExpenses;
    public GameObject yourExpenses;
    public CoinManager coinManager;

    public GameObject[] randomEventPanel;
    public InsuranceManager insuranceManager;
    //public GameObject randomEventManager;

    public bool randomEventCanHappen;
    public bool gettingRobbed;
    public bool slipAndFall;
    public bool fireAccident;
    public bool carAccident;

    void Start()
    {
        randomEventCanHappen = false;
        gettingRobbed = false;
        slipAndFall = false;
        fireAccident = false;
        carAccident = false;
        //randomEventManager.SetActive(false);
        int waterBill = PlayerPrefs.GetInt("WaterBill");
        int elecBill = PlayerPrefs.GetInt("ElectricalBill");
        Debug.Log("script functions");

        for (int i = 0; i < livingExpenses.Length; i++)
        {
            int changeInCostOfLiving = Random.Range(-50, 100);
            if (i == 0)
            {
                livingExpenses[i] = waterBill + changeInCostOfLiving;
                livingExpensesText[i].text = "Water Bill: $" + livingExpenses[0];
                PlayerPrefs.SetInt("WaterBill", livingExpenses[i]);
            }
            if (i == 1)
            {
                livingExpenses[i] = elecBill + changeInCostOfLiving;
                livingExpensesText[i].text = "Electrical Bill: $" + livingExpenses[1];
                PlayerPrefs.SetInt("ElectricalBill", livingExpenses[i]);
            }
            if (i == 2)
            {
                livingExpenses[i] = livingExpenses[0] + livingExpenses[1] + insuranceManager.totalInsuranceExpenses;
                livingExpensesText[i].text = "Total: $" + livingExpenses[i];
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

        randomEventCanHappen = true;
        //randomEventManager.SetActive(true);
        PlayRandomEvent();
    }

    public void PlayRandomEvent()
    {
        int randomizedIndexPanel = Random.Range(0, randomEventPanel.Length);
        randomizedIndexPanel = 3; //For Debugging purpose
        randomEventPanel[randomizedIndexPanel].SetActive(true);
        if(randomizedIndexPanel == 0)
        {
            gettingRobbed = true;
        }
        if(randomizedIndexPanel == 1)
        {
            slipAndFall = true;
        }
        if(randomizedIndexPanel == 2)
        {
            fireAccident = true;
        }
        if(randomizedIndexPanel == 3)
        {
            carAccident = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}

