using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] clickedPanel;

    [HideInInspector]
    public GameObject[] currentUIpanels;

    public GameObject[] investmentUIPanels;
    public GameObject[] bankUIPanels;
    public GameObject[] jobUIPanels;
    public GameObject[] insuranceUIPanels;
    public GameObject[] propertyUIPanels;

    public GameObject[] bankDepositUIPanels;
    [HideInInspector]
    public int currentPanelIndex;

    public static bool atBankOfRashid;
    public static bool atBankOfJunnie;
    public static bool atBankOfFoo;

    public static bool atInvest;
    public static bool atGameInvest;
    public static bool atBusinessInvest;
    public static bool atGymInvest;
    public GameObject haveInsurancePanel;
    private void Start()
    {
        currentPanelIndex = 0;  // Set an initial value for currentPanelIndex
    }
    private void Update()
    {
        if (atInvest)
        {
            if (investmentUIPanels[0].activeSelf)
            {
                atGameInvest = true;
            }
            else
            {
                atGameInvest = false;
            }
            if (investmentUIPanels[1].activeSelf)
            {
                atBusinessInvest = true;
            }
            else
            {
                atBusinessInvest = false;
            }
            if (investmentUIPanels[2].activeSelf)
            {
                atGymInvest = true;
            }
            else
            { 
                atGymInvest = false;
            }
        }
    }
    public void ProceedHaveInsurance()
    {
        if(PlayerPrefs.GetInt("JobIndex") == 1)
        {
            insuranceUIPanels[1].SetActive(false);
            haveInsurancePanel.SetActive(false);
        }
        else
        {
            insuranceUIPanels[1].SetActive(true);
            haveInsurancePanel.SetActive(true);
        }
    }
    public void OpenHaveInsurancePanel()
    {
        if (PlayerPrefs.GetInt("JobIndex") == 1 && insuranceUIPanels[1].activeSelf == true)
        {
            haveInsurancePanel.SetActive(true);
        }
        else
        {
            haveInsurancePanel.SetActive(false);
        }
        Debug.Log("This is working");
    }
    public void ReturnBack()
    {
        for (int i = 0; i < clickedPanel.Length; i++)
        {
            clickedPanel[i].SetActive(false);
        }
        BuildingClickHandler.canClickOnBuildings = true;
    }

    private void SetCurrentPanelIndex(int newIndex)
    {
        currentPanelIndex = newIndex;
        if (currentPanelIndex >= bankUIPanels.Length)
        {
            currentPanelIndex = 0;
        }
    }


    public void GoNext(string listPanel)
    {
        if (listPanel == "Bank")
        {
            currentUIpanels = bankUIPanels;
        }
        if (listPanel == "Job")
        {
            currentUIpanels = jobUIPanels;
        }
        if (listPanel == "Investment")
        {
            currentUIpanels = investmentUIPanels;
        }
        if (listPanel == "Insurance")
        {
            currentUIpanels = insuranceUIPanels;
            if(insuranceUIPanels[1].activeSelf == true)
            {
                OpenHaveInsurancePanel();
            }  
        }
        if (listPanel == "Property")
        {
            currentUIpanels = propertyUIPanels;
        }
        for (var i = 0; i < currentUIpanels.Length; i++)
        {
            if (currentUIpanels[i].activeSelf == true)
            {
                currentPanelIndex = i;
                //Debug.Log(currentPanelIndex);
                break;
            }
        }
        //Debug.Log("before: " + currentPanelIndex);
        currentUIpanels[currentPanelIndex].SetActive(false);
        currentPanelIndex++;
        if (currentPanelIndex >= currentUIpanels.Length)
        {
            //Debug.Log("back to 0");
            currentPanelIndex = 0;
        }
        //Debug.Log("After: " + currentPanelIndex);
        currentUIpanels[currentPanelIndex].SetActive(true);
    }

    public void GoPrevious(string listPanel)
    {
        if (listPanel == "Bank")
        {
            currentUIpanels = bankUIPanels;
        }
        if (listPanel == "Job")
        {
            currentUIpanels = jobUIPanels;
        }
        if (listPanel == "Investment")
        {
            currentUIpanels = investmentUIPanels;
        }
        if (listPanel == "Insurance")
        {
            currentUIpanels = insuranceUIPanels;
            if(insuranceUIPanels[1].activeSelf == true)
            {
                OpenHaveInsurancePanel();
            } 
        }
        if (listPanel == "Property")
        {
            currentUIpanels = propertyUIPanels;
        }
        for (var i = 0; i < currentUIpanels.Length; i++)
        {
            if (currentUIpanels[i].activeSelf == true)
            {
                currentPanelIndex = i;
                //Debug.Log(currentPanelIndex);
                break;
            }
        }
        //Debug.Log("before: " + currentPanelIndex);
        currentUIpanels[currentPanelIndex].SetActive(false);
        currentPanelIndex--;
        if (currentPanelIndex < 0)
        {
            //Debug.Log("back to 2");
            currentPanelIndex = 2;
        }
        //Debug.Log("After: " + currentPanelIndex);
        currentUIpanels[currentPanelIndex].SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Investment Panels
        if (gameObject.name == "GameCompanyButton")
        {
            atInvest = true;
            investmentUIPanels[0].SetActive(true);
            
            
        }
        else if (gameObject.name == "BusinessButton")
        {
            atInvest = true;
            investmentUIPanels[1].SetActive(true);
            
        }
        else if (gameObject.name == "GymCompanyButton")
        {
            atInvest = true;
            investmentUIPanels[2].SetActive(true);
            
        }

        if (gameObject.name == "ReturnBackButtonGame")
        {
            atInvest = false;
            clickedPanel[0].SetActive(true);
            investmentUIPanels[0].SetActive(false);
            
        }
        if (gameObject.name == "ReturnBackButtonBusiness")
        {
            atInvest = false;
            clickedPanel[0].SetActive(true);
            investmentUIPanels[1].SetActive(false);
            
        }
        if (gameObject.name == "ReturnBackButtonGym")
        {
            atInvest = false;
            clickedPanel[0].SetActive(true);
            investmentUIPanels[2].SetActive(false);
            
        }

        //Bank Panels
        if (gameObject.name == "BankOfRashidButton")
        {
            SetCurrentPanelIndex(0);
            Debug.Log("Current panel Index: " + currentPanelIndex);
            bankUIPanels[currentPanelIndex].SetActive(true);
        }
        else if (gameObject.name == "JunnieBankButton")
        {
            SetCurrentPanelIndex(1);
            Debug.Log("Current panel Index: " + currentPanelIndex);
            bankUIPanels[currentPanelIndex].SetActive(true);
        }
        else if (gameObject.name == "NationalFooBankButton")
        {
            SetCurrentPanelIndex(2);
            Debug.Log("Current panel Index: " + currentPanelIndex);
            bankUIPanels[currentPanelIndex].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonRashid")
        {
            clickedPanel[1].SetActive(true);
            bankUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonJunnie")
        {
            clickedPanel[1].SetActive(true);
            bankUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonFoo")
        {
            clickedPanel[1].SetActive(true);
            bankUIPanels[2].SetActive(false);
        }

        //Job Panels
        if (gameObject.name == "PlumberButton")
        {
            jobUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "ZooKeeperButton")
        {
            jobUIPanels[1].SetActive(true);
        }
        else if (gameObject.name == "PhotographerButton")
        {
            jobUIPanels[2].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonPlumber")
        {
            clickedPanel[2].SetActive(true);
            jobUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonZoo")
        {
            clickedPanel[2].SetActive(true);
            jobUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonPhoto")
        {
            clickedPanel[2].SetActive(true);
            jobUIPanels[2].SetActive(false);
        }

        //Insurance Panels
        if (gameObject.name == "FireInsuranceButton")
        {
            insuranceUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "HealthInsuranceButton")
        {
            insuranceUIPanels[1].SetActive(true);
            if(PlayerPrefs.GetInt("JobIndex") ==1 )
            {
                haveInsurancePanel.SetActive(true);
            }
            else
            {
                haveInsurancePanel.SetActive(false);
            }
        }
        else if (gameObject.name == "CarInsuranceButton")
        {
            insuranceUIPanels[2].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonFire")
        {
            clickedPanel[3].SetActive(true);
            insuranceUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonHealth")
        {
            clickedPanel[3].SetActive(true);
            insuranceUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonCar")
        {
            clickedPanel[3].SetActive(true);
            insuranceUIPanels[2].SetActive(false);
        }

        //Property Panels
        if (gameObject.name == "ApartmentButton")
        {
            propertyUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "LandedButton")
        {
            propertyUIPanels[1].SetActive(true);
        }
        else if (gameObject.name == "CondominiumButton")
        {
            propertyUIPanels[2].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonApartment")
        {
            clickedPanel[4].SetActive(true);
            propertyUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonLanded")
        {
            clickedPanel[4].SetActive(true);
            propertyUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonCondo")
        {
            clickedPanel[4].SetActive(true);
            propertyUIPanels[2].SetActive(false);
        }

        //Bank Confirmation Button
        if (gameObject.name == "ConfirmButtonRashid")
        {
            bankDepositUIPanels[0].SetActive(true);
            atBankOfRashid = true;
        }
        if (gameObject.name == "ConfirmButtonJunnie")
        {
            bankDepositUIPanels[1].SetActive(true);
            atBankOfJunnie = true;
        }
        if (gameObject.name == "ConfirmButtonFoo")
        {
            bankDepositUIPanels[2].SetActive(true);
            atBankOfFoo = true;
        }

        if (gameObject.name == "ReturnBackButtonRashid1")
        {
            bankUIPanels[0].SetActive(true);
            bankDepositUIPanels[0].SetActive(false);
            atBankOfRashid = false;
        }
        if (gameObject.name == "ReturnBackButtonJunnie1")
        {
            bankUIPanels[1].SetActive(true);
            bankDepositUIPanels[1].SetActive(false);
            atBankOfJunnie = false;
        }
        if (gameObject.name == "ReturnBackButtonFoo1")
        {
            bankUIPanels[2].SetActive(true);
            bankDepositUIPanels[2].SetActive(false);
            atBankOfFoo = false;
        }
    }
}
