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

    // Boolean flags to track various game events
    public bool randomEventCanHappen;
    public bool gettingRobbed;
    public bool hospitalInsurance;
    public bool fireAccident;
    public bool carAccident;
    public bool triathlonWon;
    public bool bankGoneBankrupt;
    public bool foundJewellery;
    public bool gotPickpocketted;
    public bool payRaised;
    public bool companyBonus;
    public bool arsonCase;
    public bool luckyDraw;
    public bool firstPlace;
    public bool secondPlace;
    public bool thirdPlace;
    public bool lostnFound;
    //public bool fracturedArm;

    void Start()
    {
        //Initialise the boolean flags as false on start
        randomEventCanHappen = false;
        gettingRobbed = false;
        hospitalInsurance = false;
        fireAccident = false;
        carAccident = false;
        triathlonWon = false;
        bankGoneBankrupt = false;
        foundJewellery = false;
        gotPickpocketted = false;
        payRaised = false;
        companyBonus = false;
        arsonCase = false;
        luckyDraw = false;
        firstPlace = false;
        secondPlace = false; 
        thirdPlace = false;
        lostnFound = false;

        //Initialise the living expenses based on PlayerPrefs
        int waterBill = PlayerPrefs.GetInt("WaterBill");
        int elecBill = PlayerPrefs.GetInt("ElectricalBill");
        //Debug.Log("script functions");

        //Randomize the living expenses through a change in cost of living factor
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
            //Display the living expenses ui and set the playerprefs
            if (i == 1)
            {
                livingExpenses[i] = (elecBill + changeInCostOfLiving);
                livingExpensesText[i].text = "Electrical Bill: $" + livingExpenses[1];
                PlayerPrefs.SetInt("ElectricalBill", livingExpenses[i]);
                Debug.Log("Elec Bill not discount = " + livingExpenses[i]);
            }
            //Give a discount on living expenses if they live in a landed house
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
        // Deduct expenses from the player's coins using animation
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins -= livingExpenses[2]);

        //coinManager.UpdateCoinDisplay();
        // Hide the expenses panel and allow player to click on buildings
        yourExpenses.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;
        randomEventCanHappen = true;
        //randomEventManager.SetActive(true);
        // Play a random event
        PlayRandomEvent();
    }

    public void PlayRandomEvent()
    {
        // Randomize the index of the event panel
        RandomizeIndex(randomizedIndexPanel);
        //randomizedIndexPanel = 9; //For Debugging purpose

        // Handle certain event restrictions based on player properties such as property & job
        if (PlayerPrefs.GetInt("Condo") == 1)
        {
            while (randomizedIndexPanel == 0 || randomizedIndexPanel == 9 || randomizedIndexPanel == 13)
            {
                RandomizeIndex(randomizedIndexPanel);
            }
        }
        //Rerandomize if bankruptcy happens again
        if(PlayerPrefs.GetInt("FooBankBankrupt") == 1)
        {
            while (randomizedIndexPanel == 6)
            {
                RandomizeIndex(randomizedIndexPanel);
            }
        }
        // Activate the selected random event panel
        randomEventPanel[randomizedIndexPanel].SetActive(true);
        //Set the boolean flags depending on the random event the player gets
        if(randomizedIndexPanel == 0)
        {
            gettingRobbed = true;
        }
        if(randomizedIndexPanel == 1 || randomizedIndexPanel == 19 || randomizedIndexPanel == 20 || randomizedIndexPanel == 21)
        {
            hospitalInsurance = true;
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
        if (randomizedIndexPanel == 9)
        {
            gotPickpocketted = true;
        }
        if (randomizedIndexPanel == 10 || randomizedIndexPanel == 11)
        {
            payRaised = true;
        }
        if (randomizedIndexPanel == 12)
        {
            companyBonus = true;
        }
        if(randomizedIndexPanel == 13)
        {
            arsonCase = true;
        }
        if(randomizedIndexPanel == 14)
        {
            luckyDraw = true;
        }
        if(randomizedIndexPanel == 15)
        {
            firstPlace = true;
        }
        if(randomizedIndexPanel == 16)
        {
            secondPlace = true;
        }
        if(randomizedIndexPanel == 17)
        {
            thirdPlace = true;
        }
        if(randomizedIndexPanel == 18)
        {
            lostnFound = true;
        }
    }

    // Restart the game by loading back into the menu scene
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RandomizeIndex(int randomizedEventIndexPanel)
    {
        // Randomly select an event index
        randomizedIndexPanel = Random.Range(0, randomEventPanel.Length);
    }
}

