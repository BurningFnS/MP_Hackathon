using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InsuranceManager : MonoBehaviour, IPointerClickHandler
{
    //Icons
    public GameObject[] insurance;
    public GameObject[] noInsurance;

    //Living Expenses
    public GameObject insuranceBill;
    public Text insuranceExpensesText;

    public GameObject successPurchasePanel;
    public Text successText;

    public GameObject cancelPanel;
    public Text cancelText;

    public int[] insuranceExpenses;
    public static int totalInsuranceExpenses;

    public GameObject[] cancelButton;
    public GameObject[] confirmButton;

    public GameObject cancelHealthInsuranceButton;

    public GameObject haveInsurancePanel;
    void Start()
    {
        PlayerPrefs.GetInt("HealthInsurance");
        PlayerPrefs.GetInt("CarInsurance");

        InsuranceUpdate();


        if (totalInsuranceExpenses != 0)
        {
            insuranceBill.SetActive(true);
            insuranceExpensesText.text = "Insurance Bill: $" + totalInsuranceExpenses;
        }
    }
    public void OpenHaveInsurancePanel()
    {
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            haveInsurancePanel.SetActive(true);
            cancelHealthInsuranceButton.SetActive(false);
           
        }
        else
        {
            haveInsurancePanel.SetActive(false);
            cancelHealthInsuranceButton.SetActive(true);
        }
    }
    public void InsuranceUpdate()
    {
        if (PlayerPrefs.GetInt("FireInsurance") == 1)
        {
            cancelButton[0].SetActive(true);
            noInsurance[0].SetActive(false);
            insurance[0].SetActive(true);
            insuranceExpenses[0] = (160*5);
        }
        else
        {
            insuranceExpenses[0] = 0;
        }

        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            cancelButton[1].SetActive(true);
            noInsurance[1].SetActive(false);
            insurance[1].SetActive(true);
            insuranceExpenses[1] = 0;
        }
        if (PlayerPrefs.GetInt("HealthInsurance") == 1 && !(PlayerPrefs.GetInt("JobIndex") == 1))
        {
            cancelButton[1].SetActive(true);
            noInsurance[1].SetActive(false);
            insurance[1].SetActive(true);
            insuranceExpenses[1] = (140 * 5);
        }
        else
        {
            insuranceExpenses[1] = 0;
        }

        if (PlayerPrefs.GetInt("CarInsurance") == 1)
        {
            cancelButton[2].SetActive(true);
            noInsurance[2].SetActive(false);
            insurance[2].SetActive(true);
            insuranceExpenses[2] = (190*5);
        }
        else
        {
            insuranceExpenses[2] = 0;
        }

        totalInsuranceExpenses = insuranceExpenses[0] + insuranceExpenses[1] + insuranceExpenses[2];
        Debug.Log(totalInsuranceExpenses);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            PlayerPrefs.SetInt("HealthInsurance", 1);
            insurance[1].SetActive(true);
            noInsurance[1].SetActive(false);

        }
        //else if(PlayerPrefs.GetInt("JobIndex") != 1)
        //{
        //    PlayerPrefs.SetInt("HealthInsurance", 0);
            
        //    noInsurance[1].SetActive(true);
        //    insurance[1].SetActive(false);
        //    insuranceExpenses[1] = 0;
        //}

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Confirm button, purchase Insurance

        if (gameObject.name == "FireConfirmButton")
        {
            PlayerPrefs.SetInt("FireInsurance", 1);
            noInsurance[0].SetActive(false); //get rid of the grey logo
            insurance[0].SetActive(true); //show the colored logo
            successText.text = "Successfully purchased\n the fire insurance";
            StartCoroutine(SuccessfullyPurchasedInsurace(0));
        }

        if (gameObject.name == "HealthConfirmButton")
        {
            PlayerPrefs.SetInt("HealthInsurance", 1);
            noInsurance[1].SetActive(false);
            insurance[1].SetActive(true);
            successText.text = "Successfully purchased\n the health insurance";
            
            StartCoroutine(SuccessfullyPurchasedInsurace(1));
            Debug.Log(StartCoroutine(SuccessfullyPurchasedInsurace(1)));
            
        }

        if (gameObject.name == "CarConfirmButton")
        { 
            PlayerPrefs.SetInt("CarInsurance", 1);
            noInsurance[2].SetActive(false);
            insurance[2].SetActive(true);
            successText.text = "Successfully purchased\n the car insurance";
            StartCoroutine(SuccessfullyPurchasedInsurace(2));
        }

        if (gameObject.name == "FireCancelButton")
        {
            PlayerPrefs.SetInt("FireInsurance", 0);
            noInsurance[0].SetActive(true);
            insurance[0].SetActive(false);
      
            cancelText.text = "In the event of a fire outbreak,\n you will not be covered.";
            StartCoroutine(CancelInsurace(0));
        }

        if (gameObject.name == "HealthCancelButton")
        {
            PlayerPrefs.SetInt("HealthInsurance", 0);
            noInsurance[1].SetActive(true);
            insurance[1].SetActive(false);
            cancelText.text = "In the event of a health issue,\n you will not be covered.";

            if (PlayerPrefs.GetInt("JobIndex") == 1)
            {
                PlayerPrefs.SetInt("HealthInsurance", 1);
                noInsurance[1].SetActive(false);
                insurance[1].SetActive(true);
                //StopCoroutine(CancelInsurace(1));
                haveInsurancePanel.SetActive(true);
                cancelHealthInsuranceButton.SetActive(true);
            }
            else
            {

                haveInsurancePanel.SetActive(false);
                cancelHealthInsuranceButton.SetActive(true);
                StartCoroutine(CancelInsurace(1));
            }
        }

        if (gameObject.name == "CarCancelButton")
        {
            PlayerPrefs.SetInt("CarInsurance", 0);
            noInsurance[2].SetActive(true);
            insurance[2].SetActive(false);
            cancelText.text = "In the event of a car accident,\n you will not be covered.";
            StartCoroutine(CancelInsurace(2));
        }
    }

    IEnumerator SuccessfullyPurchasedInsurace(int button)
    {
        successPurchasePanel.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        successPurchasePanel.SetActive(false);
        cancelButton[button].SetActive(true);
    }

    IEnumerator CancelInsurace(int button)
    {
        cancelPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        cancelPanel.SetActive(false);
        cancelButton[button].SetActive(false);
    }
}


