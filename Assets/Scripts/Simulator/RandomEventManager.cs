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

    public int amountRobbed;
    public int medicalSlippedBill;
    public float medicalInsurancePercentage;
    public bool randomEventHasHappened;

    public GameObject robbedPanel;
    public GameObject slippedPanel;

    public GameObject slippedInsurance;
    public GameObject slippedGreyInsurance;
    public GameObject noInsurancePanel;
    public GameObject insuranceBillPanel;
    // Start is called before the first frame update
    void Start()
    {
        randomEventHasHappened = false;
        //if (gameObject.name == "")
        medicalSlippedBill = 2000;
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
        StartCoroutine(InsuranceBill(medicalSlippedBill, medicalInsurancePercentage));
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
        coinManager.currentCoins = coinManager.currentCoins - insuredBill;
        coinManager.UpdateCoinDisplay();
        insuranceBillPanel.SetActive(false);
    }
}
