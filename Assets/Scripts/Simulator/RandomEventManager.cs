using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomEventManager : MonoBehaviour
{
    public CoinManager coinManager;
    public EventHandler eventHandler;

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

    public bool randomEventHasHappened;

    public GameObject robbedPanel;
    public GameObject slippedPanel;
    public GameObject firePanel;
    public GameObject carAccidentPanel;
    public GameObject electricalFirePanel;
    public GameObject triathlonWinPanel;
    public GameObject bankruptBankPanel;
    public GameObject carBreakdownPanel;


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

    public GameObject chainedBankruptLock;
    public GameObject claimableMoneyTextUI;


    public GameObject noInsurancePanel;
    public GameObject insuranceBillPanel;
    // Start is called before the first frame update
    void Start()
    {
        randomEventHasHappened = false;

        medicalSlippedBill = 850;
        medicalInsurancePercentage = 0.2f;

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
        if (eventHandler.gettingRobbed)
        {
            GettingRobbedEvent();
        }
        if (eventHandler.slipAndFall)
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
    }

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



    public void GettingRobbedEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
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

    public void WonTriathlon()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            grandPrizeText.text = "Grand Prize: " + grandPrize;
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

    public void CheckForMedicalInsurance()
    {
        if (PlayerPrefs.GetInt("HealthInsurance") == 1)
        {
            slippedGreyInsurance.SetActive(false);
            slippedInsurance.SetActive(true);
        }
        if (PlayerPrefs.GetInt("HealthInsurance") == 0)
        {
            slippedGreyInsurance.SetActive(true);
            slippedInsurance.SetActive(false);
        }
    }

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
