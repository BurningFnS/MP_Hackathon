using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int amountRobbed;
    public int medicalSlippedBill;
    public float medicalInsurancePercentage;
    public int moneyLostInFire;
    public float fireInsurancePercentage;
    public int carAccidentBill;
    public float carInsurancePercentage;
    public int grandPrize;

    public bool randomEventHasHappened;

    public GameObject robbedPanel;
    public GameObject slippedPanel;
    public GameObject firePanel;
    public GameObject carAccidentPanel;
    public GameObject electricalFirePanel;
    public GameObject triathlonWinPanel;

    public GameObject slippedInsurance;
    public GameObject slippedGreyInsurance;
    public GameObject fireInsurance;
    public GameObject fireGreyInsurance;
    public GameObject carAcciInsurance;
    public GameObject carAcciGreyInsurance;
    public GameObject electricalFireInsurance;
    public GameObject electricalFireGreyInsurance;


    public GameObject noInsurancePanel;
    public GameObject insuranceBillPanel;
    // Start is called before the first frame update
    void Start()
    {
        randomEventHasHappened = false;
        medicalSlippedBill = 2000;
        medicalInsurancePercentage = 0.2f;
        moneyLostInFire = Random.Range(150, 750);
        fireInsurancePercentage = 0.25f;
        fireText.text = "Amount Lost: " + moneyLostInFire;
        carAccidentBill = Random.Range(750, 1250);
        carInsurancePercentage = 0.2f;
        carAcciText.text = "Amount Lost: " + carAccidentBill;
        electricalFireText.text = "Amount Lost: " + moneyLostInFire;
        grandPrize = 1500;
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
        }
        if (PlayerPrefs.GetInt("CarInsurance") == 0)
        {
            carAcciGreyInsurance.SetActive(true);
            carAcciInsurance.SetActive(false);
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
