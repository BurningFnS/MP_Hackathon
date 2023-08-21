using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InsuranceManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] insurance;
    public GameObject[] noInsurance;
    public GameObject insuranceBill;

    public GameObject successPurchasePanel;

    public Text insuranceExpensesText;
    public Text successText;
    public int[] insuranceExpenses;

    public int totalInsuranceExpenses;

    void Start()
    {
        PlayerPrefs.GetInt("HealthInsurance");
        PlayerPrefs.GetInt("CarInsurance");

        if (PlayerPrefs.GetInt("FireInsurance") == 1)
        {
            noInsurance[0].SetActive(false);
            insurance[0].SetActive(true);
            insuranceExpenses[0] = 2000;
        }

        if (PlayerPrefs.GetInt("HealthInsurance") == 1)
        {
            noInsurance[1].SetActive(false);
            insurance[1].SetActive(true);
            insuranceExpenses[1] = 3000;
        }

        if (PlayerPrefs.GetInt("CarInsurance") == 1)
        {
            noInsurance[2].SetActive(false);
            insurance[2].SetActive(true);
            insuranceExpenses[2] = 1000;
        }

        totalInsuranceExpenses = insuranceExpenses[0] + insuranceExpenses[1] + insuranceExpenses[2];
        Debug.Log(totalInsuranceExpenses);

        if (totalInsuranceExpenses != 0)
        {
            insuranceBill.SetActive(true);
            insuranceExpensesText.text = "Insurance Bill: $" + totalInsuranceExpenses;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "FireConfirmButton")
        {
            PlayerPrefs.SetInt("FireInsurance", 1);
            noInsurance[0].SetActive(false); //get rid of the grey logo
            insurance[0].SetActive(true); //show the colored logo
            successText.text = "Successfully purchased\n the fire insurance";
        }
        if (gameObject.name == "HealthConfirmButton")
        {
            PlayerPrefs.SetInt("HealthInsurance", 1);
            noInsurance[1].SetActive(false);
            insurance[1].SetActive(true);
            successText.text = "Successfully purchased\n the health insurance";
        }
        if (gameObject.name == "CarConfirmButton")
        {
            PlayerPrefs.SetInt("CarInsurance", 1);
            noInsurance[2].SetActive(false);
            insurance[2].SetActive(true);
            successText.text = "Successfully purchased\n the car insurance";
        }

        StartCoroutine(successfullyPurchasedInsurace());
    }

    IEnumerator successfullyPurchasedInsurace()
    {
        successPurchasePanel.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        successPurchasePanel.SetActive(false);
    }
}


