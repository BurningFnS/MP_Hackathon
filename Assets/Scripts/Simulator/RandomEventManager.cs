using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomEventManager : MonoBehaviour
{
    public CoinManager coinManager;
    public EventHandler eventHandler;

    // Text objects for displaying event details
    public Text robbedText;
    public Text beforeInsuranceText;
    public Text insuranceCoverageText;
    public Text finalBillText;
    public Text fireText;
    public Text carAcciText;
    public Text electricalFireText;
    public Text grandPrizeText;
    public Text claimableMoneyText;
    public Text carBreakdownText;
    public Text secretJewelleryText;
    public Text pickpockettedText;
    public Text companyBonusText;
    public Text arsonText;
    public Text luckyDrawText;
    public Text firstPlaceText;
    public Text secondPlaceText;
    public Text thirdPlaceText;
    public Text foundMissingText;
    public Text fracturedArmText;
    public Text tornHamstringText;
    public Text concussionText;

    // Various int and float variables for random events
    public int amountRobbed;
    public int medicalSlippedBill;
    public float medicalInsurancePercentage;
    public int moneyLostInFire;
    public float fireInsurancePercentage;
    public int carAccidentBill;
    public float carInsurancePercentage;
    public int grandPrize;
    public int moneyBeforeBankrupt;
    public float percentageLostInBankrupt;
    public int moneyAfterBankrupt;
    public int carBreakdownBill;
    public int jewelleryWorth;
    public int moneyPickpocketted;
    public float payRaise;
    public float payRaise2;
    public int companyBonus;
    public int moneyLostFromArson;
    public int luckyDrawMoney;
    public int firstPlacePrize;
    public int secondPlacePrize;
    public int thirdPlacePrize;
    public int missingBountyReward;
    public int fracturedArmBill;
    public int tornHamstringBill;
    public int concussionBill;

    // Flags to check if random event has happened
    public bool randomEventHasHappened;

    // References to UI panels for events
    public GameObject robbedPanel;
    public GameObject slippedPanel;
    public GameObject firePanel;
    public GameObject carAccidentPanel;
    public GameObject electricalFirePanel;
    public GameObject triathlonWinPanel;
    public GameObject bankruptBankPanel;
    public GameObject carBreakdownPanel;
    public GameObject foundJewelleryPanel;
    public GameObject pickpockettedPanel;
    public GameObject payRaisePanel;
    public GameObject payRaisePanel2;
    public GameObject companyBonusPanel;
    public GameObject arsonPanel;
    public GameObject luckyDrawPanel;
    public GameObject firstPlacePanel;
    public GameObject secondPlacePanel;
    public GameObject thirdPlacePanel;
    public GameObject missingBountyRewardPanel;
    public GameObject fracturedArmPanel;
    public GameObject tornHamPanel;
    public GameObject concussionPanel;

    // References to UI elements regarding insurance buttons
    public GameObject slippedInsurance;
    public GameObject slippedGreyInsurance;
    public GameObject fireInsurance;
    public GameObject fireGreyInsurance;
    public GameObject carAcciInsurance;
    public GameObject carAcciGreyInsurance;
    public GameObject electricalFireInsurance;
    public GameObject electricalFireGreyInsurance;
    public GameObject claimBankruptMoneyBtn;
    public GameObject carBreakdownInsurance;
    public GameObject carBreakdownGreyInsurance;
    public GameObject fracturedArmInsurance;
    public GameObject fracturedArmGreyInsurance;
    public GameObject tornHamstringInsurance;
    public GameObject tornHamstringGreyInsurance;
    public GameObject concussionInsurance;
    public GameObject concussionGreyInsurance;

    public GameObject chainedBankruptLock;
    public GameObject claimableMoneyTextUI;


    public GameObject noInsurancePanel;
    public GameObject insuranceBillPanel;
    // Start is called before the first frame update
    void Start()
    {
        // Initialization of various game variables
        randomEventHasHappened = false;

        medicalSlippedBill = 850;
        medicalInsurancePercentage = 0.2f;
        fracturedArmBill = 1000;
        fracturedArmText.text = "Amount Lost: " + fracturedArmBill;
        tornHamstringBill = 350;
        tornHamstringText.text = "Amount Lost: " + tornHamstringBill;
        concussionBill = 500;
        concussionText.text = "Amount Lost: " + concussionBill;

        moneyLostInFire = Random.Range(150, 550);
        fireInsurancePercentage = 0.25f;
        fireText.text = "Amount Lost: " + moneyLostInFire;
        electricalFireText.text = "Amount Lost: " + moneyLostInFire;

        carAccidentBill = Random.Range(650, 1000);
        carInsurancePercentage = 0.2f;
        carAcciText.text = "Amount Lost: " + carAccidentBill;
        carBreakdownBill = Random.Range(300, 650);
        carBreakdownText.text = "Amount Lost: " + carBreakdownBill;

        grandPrize = 1000;

        jewelleryWorth = Random.Range(200, 850);

        payRaise = 1.25f;
        payRaise2 = 1.15f;

        companyBonus = 1500;

        luckyDrawMoney = 750;
        
        firstPlacePrize = 1000;
        secondPlacePrize = 750;
        thirdPlacePrize = 500;

        missingBountyReward = 500;
        //Check if certain game conditions are met and updating UI accordingly
        if (PlayerPrefs.GetInt("FooBankBankrupt") == 1)
        {
            bankruptBankPanel.SetActive(false);
            chainedBankruptLock.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ClaimableBankruptcyMoney") == 0)
        {
            claimBankruptMoneyBtn.SetActive(false);
            claimableMoneyText.text = "The money has\r\nbeen claimed";
            claimableMoneyTextUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for what random event is happening
        if (eventHandler.gettingRobbed)
        {
            GettingRobbedEvent();
        }
        if (eventHandler.hospitalInsurance)
        {
            CheckForMedicalInsurance();
        }
        if (eventHandler.fireAccident)
        {
            CheckForFireInsurance();
        }
        if (eventHandler.carAccident)
        {
            CheckForCarInsurance();
        }
        if (eventHandler.triathlonWon)
        {
            WonTriathlon();
        }
        if (eventHandler.bankGoneBankrupt && PlayerPrefs.GetInt("FooBankBankrupt") == 0)
        {
            DeclaringBankruptcy();
        }
        if (eventHandler.foundJewellery)
        {
            SellJewellery();
        }
        if (eventHandler.gotPickpocketted)
        {
            GettingPickpockettedEvent();
        }
        if (eventHandler.companyBonus)
        {
            ReceiveCompanyBonus();
        }
        if (eventHandler.arsonCase)
        {
            ArsonEvent();
        }
        if (eventHandler.luckyDraw)
        {
            LuckyDrawEvent();
        }
        if (eventHandler.firstPlace)
        {
            FirstPlaceEvent();
        }
        if (eventHandler.secondPlace)
        {
            SecondPlaceEvent();
        }
        if (eventHandler.thirdPlace)
        {
            ThirdPlaceEvent();
        }
        if (eventHandler.lostnFound)
        {
            MissingCatEvent();
        }
        //if (eventHandler.fracturedArm)
        //{
        //    CheckForMedicalInsurance();
        //}
        
    }

    //Hides the respective panels and update coins of player
    public void ProceedRobbed()
    {
        robbedPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - amountRobbed);
    }

    public void ProceedSlipped()
    {
        slippedPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - medicalSlippedBill);
    }
    public void ProceedFire()
    {
        firePanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - moneyLostInFire);
    }
    public void ProceedAccident()
    {
        carAccidentPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - carAccidentBill);
    }
    public void ProceedElecFire()
    {
        electricalFirePanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - moneyLostInFire);
    }
    public void ProceedTriathlon()
    {
        triathlonWinPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + grandPrize);
    }
    public void ProceedBankrupt()
    {
        bankruptBankPanel.SetActive(false);
        chainedBankruptLock.SetActive(true);
        PlayerPrefs.SetInt("FooBankBankrupt", 1);
    }
    public void ProceedCarBreakdown()
    {
        carBreakdownPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - carBreakdownBill);
    }
    public void ProceedSellJewellery()
    {
        foundJewelleryPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + jewelleryWorth);
    }
    public void ProceedPickpocketted()
    {
        pickpockettedPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - moneyPickpocketted);
    }
    public void ProceedPayRaise()
    {
        payRaisePanel.SetActive(false);
        int currentSalary = PlayerPrefs.GetInt("Salary");
        int newSalary = Mathf.CeilToInt(currentSalary * payRaise);
        PlayerPrefs.SetInt("Salary", newSalary);
        
    }
    public void ProceedPayRaise2()
    {
        payRaisePanel2.SetActive(false);
        int currentSalary = PlayerPrefs.GetInt("Salary");
        int newSalary = Mathf.CeilToInt(currentSalary * payRaise2);
        PlayerPrefs.SetInt("Salary", newSalary);

    }
    public void ProceedCompanyBonus()
    {
        companyBonusPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + companyBonus);
    }
    public void ProceedArson()
    {
        arsonPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - moneyLostFromArson);
    }
    public void ProceedLuckyDraw() 
    {
        luckyDrawPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + luckyDrawMoney);
    }
    public void ProceedFirstPlace()
    {
        firstPlacePanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + firstPlacePrize);
    }
    public void ProceedSecondPlace()
    {
        secondPlacePanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + secondPlacePrize);
    }
    public void ProceedThirdPlace()
    {
        thirdPlacePanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + thirdPlacePrize);
    }
    public void ProceedMissingCat()
    {
        missingBountyRewardPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + missingBountyReward);
    }
    public void ProceedFractured()
    {
        fracturedArmPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - fracturedArmBill);
    }
    public void ProceedHamstring()
    {
        tornHamPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - tornHamstringBill);
    }
    public void ProceedConcussion()
    {
        concussionPanel.SetActive(false);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - concussionBill);
    }

    public void GettingRobbedEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            //Make sure they can never lose more than they own
            if (coinManager.currentCoins > 0)
            {
                amountRobbed = Random.Range(0, coinManager.currentCoins);
                robbedText.text = "Amount Lost: " + amountRobbed;
                randomEventHasHappened = true;
            }
            else
            {
                robbedText.text = "Amount Lost: 0";
                randomEventHasHappened = true;
            }

        }
    }

    public void GettingPickpockettedEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            //Make sure they can never lose more than they own
            if (coinManager.currentCoins > 0)
            {
                moneyPickpocketted = Random.Range(0, coinManager.currentCoins);
                pickpockettedText.text = "Money Lost: " + moneyPickpocketted;
                randomEventHasHappened = true;
            }
            else
            {
                pickpockettedText.text = "Money Lost: 0";
                randomEventHasHappened = true;
            }

        }
    }

    public void ArsonEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            //Make sure they can never lose more than they own
            if (coinManager.currentCoins > 0)
            {
                moneyLostFromArson = Random.Range(0, coinManager.currentCoins);
                arsonText.text = "Amount Lost: " + moneyLostFromArson;
                randomEventHasHappened = true;
            }
            else
            {
                arsonText.text = "Money Lost: 0";
                randomEventHasHappened = true;
            }

        }
    }

    //Update UI text for all these random events
    public void WonTriathlon()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            grandPrizeText.text = "Grand Prize: " + grandPrize;
            randomEventHasHappened = true;

        }
    }
    public void ReceiveCompanyBonus()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            companyBonusText.text = "Bonus: " + companyBonus;
            randomEventHasHappened = true;

        }
    }
    public void SellJewellery()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            secretJewelleryText.text = "Sold for: " + jewelleryWorth;
            randomEventHasHappened = true;
        }
    }

    public void LuckyDrawEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            luckyDrawText.text = "Amount Won: " + luckyDrawMoney;
            randomEventHasHappened = true;
        }
    }

    public void FirstPlaceEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            firstPlaceText.text = "Grand Prize: " + firstPlacePrize;
            randomEventHasHappened = true;
        }
    }
    public void SecondPlaceEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            secondPlaceText.text = "Prize: " + secondPlacePrize;
            randomEventHasHappened = true;
        }
    }
    public void ThirdPlaceEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            thirdPlaceText.text = "Prize: " + thirdPlacePrize;
            randomEventHasHappened = true;
        }
    }

    public void MissingCatEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            foundMissingText.text = "Rewarded: " + missingBountyReward;
            randomEventHasHappened = true;
        }
    }

    public void DeclaringBankruptcy()
    {
        moneyBeforeBankrupt = Mathf.RoundToInt(PlayerPrefs.GetFloat("BankOfFooBalance"));
        percentageLostInBankrupt = Random.Range(0.4f, 0.7f);
        moneyAfterBankrupt = Mathf.RoundToInt(moneyBeforeBankrupt * percentageLostInBankrupt);
        PlayerPrefs.SetInt("ClaimableBankruptcyMoney", moneyAfterBankrupt);
        Debug.Log(moneyAfterBankrupt);
    }


    public void ClaimRemainderOfBank()
    {
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + PlayerPrefs.GetInt("ClaimableBankruptcyMoney"));
        claimBankruptMoneyBtn.SetActive(false);
        claimableMoneyText.text = "You have claimed $" + PlayerPrefs.GetInt("ClaimableBankruptcyMoney");
        claimableMoneyTextUI.SetActive(true);
        PlayerPrefs.SetInt("ClaimableBankruptcyMoney", 0);

    }

    public void InsuranceSlipped()
    {
        slippedPanel.SetActive(false);
        StartCoroutine(InsuranceBill(medicalSlippedBill, medicalInsurancePercentage));
    }

    public void InsuranceFractured()
    {
        fracturedArmPanel.SetActive(false);
        StartCoroutine(InsuranceBill(fracturedArmBill, medicalInsurancePercentage));
    }

    public void InsuranceHamstring()
    {
        tornHamPanel.SetActive(false);
        StartCoroutine(InsuranceBill(tornHamstringBill, medicalInsurancePercentage));
    }

    public void InsuranceConcussion()
    {
        concussionPanel.SetActive(false);
        StartCoroutine(InsuranceBill(concussionBill, medicalInsurancePercentage));
    }

    public void InsuranceFire()
    {
        firePanel.SetActive(false);
        StartCoroutine(InsuranceBill(moneyLostInFire, fireInsurancePercentage));
    }

    public void InsuranceCar()
    {
        carAccidentPanel.SetActive(false); 
        StartCoroutine(InsuranceBill(carAccidentBill, carInsurancePercentage));
    }

    public void InsuranceElecFire()
    {
        electricalFirePanel.SetActive(false);
        StartCoroutine(InsuranceBill(moneyLostInFire, fireInsurancePercentage));
    }

    public void InsuranceCarBreakdown()
    {
        carBreakdownPanel.SetActive(false);
        StartCoroutine(InsuranceBill(carBreakdownBill, carInsurancePercentage));
    }

    //Check if player has medical insurance and updates UI accordingly
    public void CheckForMedicalInsurance()
    {
        if (PlayerPrefs.GetInt("HealthInsurance") == 1)
        {
            slippedGreyInsurance.SetActive(false);
            slippedInsurance.SetActive(true);
            fracturedArmGreyInsurance.SetActive(false);
            fracturedArmInsurance.SetActive(true);
            tornHamstringGreyInsurance.SetActive(false);
            tornHamstringInsurance.SetActive(true);
            concussionGreyInsurance.SetActive(false);
            concussionInsurance.SetActive(true);
        }
        if (PlayerPrefs.GetInt("HealthInsurance") == 0)
        {
            slippedGreyInsurance.SetActive(true);
            slippedInsurance.SetActive(false);
            fracturedArmGreyInsurance.SetActive(true);
            fracturedArmInsurance.SetActive(false);
            tornHamstringGreyInsurance.SetActive(true);
            tornHamstringInsurance.SetActive(false);
            concussionGreyInsurance.SetActive(true);
            concussionInsurance.SetActive(false);
        }
    }

    //Check if player has fire insurance and updates UI accordingly
    public void CheckForFireInsurance()
    {
        //Debug.Log("FireInsurance: " + PlayerPrefs.GetInt("FireInsurance"));
        if (PlayerPrefs.GetInt("FireInsurance") == 1)
        {
            electricalFireGreyInsurance.SetActive(false);
            fireGreyInsurance.SetActive(false);
            electricalFireInsurance.SetActive(true);
            fireInsurance.SetActive(true);
        }
        if (PlayerPrefs.GetInt("FireInsurance") == 0)
        {
            electricalFireGreyInsurance.SetActive(true);
            fireGreyInsurance.SetActive(true);
            electricalFireInsurance.SetActive(false);
            fireInsurance.SetActive(false);
        }
    }

    //Check if player has car insurance and updates UI accordingly
    public void CheckForCarInsurance()
    {
        if (PlayerPrefs.GetInt("CarInsurance") == 1)
        {
            carAcciGreyInsurance.SetActive(false);
            carAcciInsurance.SetActive(true);
            carBreakdownGreyInsurance.SetActive(false);
            carBreakdownInsurance.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CarInsurance") == 0)
        {
            carAcciGreyInsurance.SetActive(true);
            carAcciInsurance.SetActive(false);
            carBreakdownGreyInsurance.SetActive(true);
            carBreakdownInsurance.SetActive(false);
        }
    }

    // Coroutine to display a warning when they have no insurance
    public void NoInsuranceWarning()
    {
        StartCoroutine(NoInsurance());
    }

    IEnumerator NoInsurance()
    {
        noInsurancePanel.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        noInsurancePanel.SetActive(false);
    }

    //Coroutine to display the insurance panel with all the correct insurance information
    IEnumerator InsuranceBill(int billBeforeInsurance, float insurancePercentage)
    {
        insuranceBillPanel.SetActive(true);
        int insuredBill = Mathf.CeilToInt(billBeforeInsurance * insurancePercentage);

        Debug.Log("Insured bill is : " + insuredBill);
        beforeInsuranceText.text = "Bill: $" + billBeforeInsurance;
        insuranceCoverageText.text = "Insurance covers:\r\n" + "$" + billBeforeInsurance + " x " + (100 - (insurancePercentage * 100)) + "% = $" + (billBeforeInsurance - insuredBill);
        finalBillText.text = "Final Bill: $" + insuredBill;

        yield return new WaitForSeconds(3f);
        coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - insuredBill);
        insuranceBillPanel.SetActive(false);
    }
}
