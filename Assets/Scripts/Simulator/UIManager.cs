using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] clickedPanel;

    public GameObject[] investmentUIPanels;
    public GameObject[] bankUIPanels;
    public GameObject[] jobUIPanels;
    public GameObject[] insuranceUIPanels;
    public GameObject[] propertyUIPanels;

    public GameObject[] bankDepositUIPanels;

    public void ReturnBack()
    {
        for (int i = 0; i < clickedPanel.Length; i++)
        {
            clickedPanel[i].SetActive(false);
        }
        BuildingClickHandler.canClickOnBuildings = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Investment Panels
        if (gameObject.name == "GameCompanyButton")
        {
            investmentUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "BusinessButton")
        {
            investmentUIPanels[1].SetActive(true);
        }
        else if (gameObject.name == "GymCompanyButton")
        {
            investmentUIPanels[2].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonGame")
        {
            clickedPanel[0].SetActive(true);
            investmentUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonBusiness")
        {
            clickedPanel[0].SetActive(true);
            investmentUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonGym")
        {
            clickedPanel[0].SetActive(true);
            investmentUIPanels[2].SetActive(false);
        }

        //Bank Panels
        if (gameObject.name == "BankOfRashidButton")
        {
            bankUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "JunnieBankButton")
        {
            bankUIPanels[1].SetActive(true);
        }
        else if (gameObject.name == "NationalFooBankButton")
        {
            bankUIPanels[2].SetActive(true);
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
        if (gameObject.name == "LifeInsuranceButton")
        {
            insuranceUIPanels[0].SetActive(true);
        }
        else if (gameObject.name == "HealthInsuranceButton")
        {
            insuranceUIPanels[1].SetActive(true);
        }
        else if (gameObject.name == "CriticalillnessInsuranceButton")
        {
            insuranceUIPanels[2].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonLife")
        {
            clickedPanel[3].SetActive(true);
            insuranceUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonHealth")
        {
            clickedPanel[3].SetActive(true);
            insuranceUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonCritical")
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
        }
        if(gameObject.name == "ConfirmButtonJunnie")
        {
            bankDepositUIPanels[1].SetActive(true);
        }
        if (gameObject.name == "ConfirmButtonFoo")
        {
            bankDepositUIPanels[3].SetActive(true);
        }

        if (gameObject.name == "ReturnBackButtonRashid1")
        {
            bankUIPanels[0].SetActive(true);
            bankDepositUIPanels[0].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonJunnie1")
        {
            bankUIPanels[1].SetActive(true);
            bankDepositUIPanels[1].SetActive(false);
        }
        if (gameObject.name == "ReturnBackButtonFoo1")
        {
            bankUIPanels[1].SetActive(true);
            bankDepositUIPanels[2].SetActive(false);
        }
    }
}
