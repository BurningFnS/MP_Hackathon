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
    public float percentageDiscount = 0.5f;

    public int randomizedIndexPanel;
    public GameObject[] randomEventPanel;
    public InsuranceManager insuranceManager;
    public PropertyManager propertyManager;
    //public GameObject randomEventManager;

    public bool randomEventCanHappen;
    public bool gettingRobbed;
    public bool slipAndFall;
    public bool fireAccident;
    public bool carAccident;
    public bool triathlonWon;
    public bool bankGoneBankrupt;
    public bool foundJewellery;

    void Start()
    {
        randomEventCanHappen = false;
        gettingRobbed = false;
        slipAndFall = false;
        fireAccident = false;
        carAccident = false;
        triathlonWon = false;
        bankGoneBankrupt = false;
        foundJewellery = false;
        //randomEventManager.SetActive(false);
        int waterBill = PlayerPrefs.GetInt("WaterBill");
        int elecBill = PlayerPrefs.GetInt("ElectricalBill");
        //Debug.Log("script functions");

        for (int i = 0; i < livingExpenses.Length; i++)
        {
            int changeInCostOfLiving = Random.Range(-50, 100);
            if (i == 0)
            {
                livingExpenses[i] = waterBill + changeInCostOfLiving;
                livingExpensesText[i].text = "Water Bill: $" + livingExpenses[0];
                PlayerPrefs.SetInt("WaterBill", livingExpenses[i]);
                Debug.Log("Water Bill  not discount = " + livingExpenses[i]);
            }
            if(i == 0 && PlayerPrefs.GetInt("Landed") == 1)
            {
                livingExpenses[i] = (int)((waterBill + changeInCostOfLiving) *percentageDiscount);
                livingExpensesText[i].text = "Water Bill: $" + livingExpenses[0];
                PlayerPrefs.SetInt("WaterBill", livingExpenses[i]);
                Debug.Log("Water Bill = " + livingExpenses[i]);
            }
            if (i == 1)
            {
                livingExpenses[i] = (elecBill + changeInCostOfLiving);
                livingExpensesText[i].text = "Electrical Bill: $" + livingExpenses[1];
                PlayerPrefs.SetInt("ElectricalBill", livingExpenses[i]);
                Debug.Log("Elec Bill not discount = " + livingExpenses[i]);
            }
            if (i == 1 && PlayerPrefs.GetInt("Landed") == 1)
            {
                livingExpenses[i] = (int)((elecBill + changeInCostOfLiving) * percentageDiscount);
                livingExpensesText[i].text = "Electrical Bill: $" + livingExpenses[1];
                PlayerPrefs.SetInt("ElectricalBill", livingExpenses[i]);
                Debug.Log("Elec Bill = " + livingExpenses[i]);
            }
            if (i == 2)
            {
                livingExpenses[i] = livingExpenses[0] + livingExpenses[1] + InsuranceManager.totalInsuranceExpenses;
                livingExpensesText[i].text = "Total: $" + livingExpenses[i];
            }
        }

        //Show expenses panel
        yourExpenses.SetActive(true);

        BuildingClickHandler.canClickOnBuildings = false;
    }

    public void Pay()
    {
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins -= livingExpenses[2]);

        //coinManager.UpdateCoinDisplay();

        yourExpenses.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;
        randomEventCanHappen = true;
        //randomEventManager.SetActive(true);
        PlayRandomEvent();
    }

    public void PlayRandomEvent()
    {
        RandomizeIndex(randomizedIndexPanel);
        randomizedIndexPanel = 8; //For Debugging purpose
        if(PlayerPrefs.GetInt("Condo") == 1)
        {
            while(randomizedIndexPanel == 0)
            {
                RandomizeIndex(randomizedIndexPanel);
            }
        }
        if(PlayerPrefs.GetInt("FooBankBankrupt") == 1)
        {
            while (randomizedIndexPanel == 6)
            {
                RandomizeIndex(randomizedIndexPanel);
            }
        }
        randomEventPanel[randomizedIndexPanel].SetActive(true);
        if(randomizedIndexPanel == 0)
        {
            gettingRobbed = true;
        }
        if(randomizedIndexPanel == 1)
        {
            slipAndFall = true;
        }
        if(randomizedIndexPanel == 2 || randomizedIndexPanel == 4)
        {
            fireAccident = true;
        }
        if(randomizedIndexPanel == 3 || randomizedIndexPanel == 7)
        {
            carAccident = true;
        }
        if(randomizedIndexPanel == 5)
        {
            triathlonWon = true;
        }
        if(randomizedIndexPanel == 6)
        {
            bankGoneBankrupt = true;
        }
        if (randomizedIndexPanel == 8)
        {
            foundJewellery = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RandomizeIndex(int randomizedEventIndexPanel)
    {
        randomizedIndexPanel = Random.Range(0, randomEventPanel.Length);
    }
}

