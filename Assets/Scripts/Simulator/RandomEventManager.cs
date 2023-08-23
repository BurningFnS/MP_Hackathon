using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventManager : MonoBehaviour
{
    public CoinManager coinManager;
    public EventHandler eventHandler;

    public Text robbedText;

    public int amountRobbed;
    public int medicalSlippedBill;
    public float medicalInsurancePercentage;
    public bool randomEventHasHappened;

    public GameObject robbedPanel;
    public GameObject slippedPanel;

    public GameObject slippedInsurance;
    public GameObject slippedGreyInsurance;
    // Start is called before the first frame update
    void Start()
    {
        randomEventHasHappened = false;
        //if (gameObject.name == "")
        medicalSlippedBill = 200;
        medicalInsurancePercentage = 0.2f;

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

    }

    public void ProceedRobbed()
    {
        
        robbedPanel.SetActive(false);
        coinManager.currentCoins = coinManager.currentCoins - amountRobbed;
        coinManager.UpdateCoinDisplay();
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

    public void ProceedSlipped()
    {
        slippedPanel.SetActive(false);
        coinManager.currentCoins = coinManager.currentCoins - medicalSlippedBill;
        coinManager.UpdateCoinDisplay();
    }

    public void InsuranceSlipped()
    {
        slippedPanel.SetActive(false);
        int insuredBill = Mathf.CeilToInt(medicalSlippedBill * medicalInsurancePercentage);
        coinManager.currentCoins = coinManager.currentCoins - insuredBill;
        Debug.Log("Insured bill is : " +  insuredBill);
        coinManager.UpdateCoinDisplay();
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
}
