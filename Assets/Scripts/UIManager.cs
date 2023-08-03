using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject ClickToVisitCanvas;
    public GameObject ClickedOnCanvas;
    public GameObject AfterVisitCanvas;
    public GameObject TownCanvas; 
    public GameObject AlertPanel;
    public GameObject Map;
    public GameObject Property;
    public GameObject Bank;
    public GameObject Investment;
    public GameObject Insurance;
    public GameObject Job;
    public GameObject PropertyClickedPanel;
    public GameObject BankClickedPanel;
    public GameObject InvestmentClickedPanel;
    public GameObject InsuranceClickedPanel;
    public GameObject JobClickedPanel;
    public GameObject InvestmentPanel;
    public GameObject InsurancePanel;
    public GameObject PropertyPanel;
    public GameObject BankPanel;
    public GameObject JobPanel;
    public GameObject NoInsurancePanel;
    public GameObject LifeInsurancePanel;
    public GameObject HealthInsurancePanel;
    public GameObject CriticalIllnessInsurancePanel;
    public GameObject OptionsPanel;
    public GameObject OptionsButton;
    public GameObject ApartmentPanel;
    public GameObject LandedPanel;
    public GameObject CondominiumPanel;
    public GameObject PlumberPanel;
    public GameObject ZooKeeperPanel;
    public GameObject PhotographerPanel;
    public GameObject GameInvestmentPanel;
    public GameObject BusinessInvestmentPanel;
    public GameObject GymInvestmentPanel;
    public GameObject BankOfRashidPanel;
    public GameObject JunnieBankPanel;
    public GameObject LegalFooBankPanel;
    public GameObject BankOfRashidDepositPanel;
    public GameObject JunnieBankDepositPanel;
    public GameObject LegalFooBankDepositPanel;
    public GameObject InformationPanel;
    public GameObject InformationPanelTwo;
    public GameObject BankButton;
    public GameObject[] panelsToCheck;
    public GameObject[] buttonsToDisable;
    public GameObject[] InsurancePanels;
    public GameObject[] PropertyPanels;
    public GameObject[] BankPanels;
    public GameObject[] JobPanels;
    public GameObject[] InvestmentPanels;
    public GameObject[] DepositPanels; 
    private int clickCount = 0;
    public void CheckPanelActivityAndDisableButtons()
    {
        for (int i = 0; i < panelsToCheck.Length; i++)
        {
            GameObject panel = panelsToCheck[i];
            // Check if the panel is active
            if (panel.activeSelf)
            {
                // Disable buttons
                for (int j = 0; j < buttonsToDisable.Length; j++)
                {
                    buttonsToDisable[j].SetActive(false);
                }
                break;
            }
            else
            {
                // Enable buttons for inactive panels
                for (int j = 0; j < buttonsToDisable.Length; j++)
                {
                    buttonsToDisable[j].SetActive(true);
                }
            }
        }
        Debug.Log("INISFN");
    }
    public void CloseAlertBox()
    {
        if (AlertPanel != null)
        {
            AlertPanel.SetActive(false);
            Map.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void ReturnBack() //Just for the Return Arrows, where if the respective panels pop up and u press the return arrow, the respective panel will close. 
    {
        if (GameObject.FindGameObjectWithTag("ReturnBack"))
        {
            if (PropertyClickedPanel != null)
            {
                PropertyClickedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (BankClickedPanel != null)
            {
                BankClickedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (InsuranceClickedPanel != null)
            {
                InsuranceClickedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (InvestmentClickedPanel != null)
            {
                InvestmentClickedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (JobClickedPanel != null)
            {
                JobClickedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (NoInsurancePanel != null)
            {
                NoInsurancePanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (LifeInsurancePanel != null)
            {
                LifeInsurancePanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (HealthInsurancePanel != null)
            {
                HealthInsurancePanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (CriticalIllnessInsurancePanel != null)
            {
                CriticalIllnessInsurancePanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (BankOfRashidPanel != null)
            {
                BankOfRashidPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (JunnieBankPanel != null)
            {
                JunnieBankPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (LegalFooBankPanel != null)
            {
                LegalFooBankPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (LandedPanel != null)
            {
                LandedPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (ApartmentPanel != null)
            {
                ApartmentPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (CondominiumPanel != null)
            {
                CondominiumPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (GameInvestmentPanel != null)
            {
                GameInvestmentPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (BusinessInvestmentPanel != null)
            {
                BusinessInvestmentPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (GymInvestmentPanel != null)
            {
                GymInvestmentPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (PlumberPanel != null)
            {
                PlumberPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (ZooKeeperPanel != null)
            {
                ZooKeeperPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (PhotographerPanel != null)
            {
                PhotographerPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if(BankOfRashidDepositPanel != null)
            {
                BankOfRashidDepositPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if(JunnieBankDepositPanel != null)
            {
                JunnieBankDepositPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if(LegalFooBankDepositPanel != null)
            {
                LegalFooBankDepositPanel.SetActive(false);
                TownCanvas.SetActive(true);
            }
            if (OptionsPanel != null)
            {
                OptionsPanel.SetActive(false);
                OptionsButton.SetActive(true);
            }
        }
    }
    public void ConfirmBankOfRashidButton()
    {
        if (BankOfRashidPanel != null)
        {
            TownCanvas.SetActive(false);
            BankOfRashidPanel.SetActive(false);
            BankOfRashidDepositPanel.SetActive(true);
        }
    }
    public void ConfirmJunnieBankButton()
    {
        if (JunnieBankPanel != null)
        {
            TownCanvas.SetActive(false);
            JunnieBankPanel.SetActive(false);
            JunnieBankDepositPanel.SetActive(true);
        }
    }
    public void ConfirmLegalFooBankButton()
    {
        if (LegalFooBankPanel != null)
        {
            TownCanvas.SetActive(false);
            LegalFooBankPanel.SetActive(false);
            LegalFooBankDepositPanel.SetActive(true);
        }
    }
    public void OkayButton()
    {
        if (InformationPanel != null && clickCount == 0 )
        {
            TownCanvas.SetActive(false);
            InformationPanel.SetActive(false);
            BankOfRashidPanel.SetActive(true);
        }
        if (InformationPanel != null && clickCount == 1)
        {
            TownCanvas.SetActive(false);
            InformationPanel.SetActive(false);
            JunnieBankPanel.SetActive(true);           
        }
        if (InformationPanel != null && clickCount == 2 )
        {
            TownCanvas.SetActive(false);
            InformationPanel.SetActive(false);
            LegalFooBankPanel.SetActive(true);
        }
    }
    public void DepositOkayButton()
    {
        if (InformationPanelTwo != null && clickCount == 0 && GameObject.FindGameObjectWithTag("Okay"))
        {
            TownCanvas.SetActive(false);
            InformationPanelTwo.SetActive(false);
            BankOfRashidDepositPanel.SetActive(true);
        }
        if (InformationPanelTwo != null && clickCount == 1 && GameObject.FindGameObjectWithTag("Okay"))
        {
            TownCanvas.SetActive(false);
            InformationPanelTwo.SetActive(false);
            JunnieBankDepositPanel.SetActive(true);
        }
        if (InformationPanelTwo != null && clickCount == 2 && GameObject.FindGameObjectWithTag("Okay"))
        {
            TownCanvas.SetActive(false);
            InformationPanelTwo.SetActive(false);
            LegalFooBankDepositPanel.SetActive(true);
        }
    }
    public void BankOpenVisitButton()//For the ClickToVisitCanvas Bank panel to appear :} 
    {
        if (GameObject.FindGameObjectWithTag("BankOpenVisit"))
        {
            BankPanel.SetActive(true);
            PropertyPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            JobPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void InvestmentOpenVisitButton()//For the ClickToVisitCanvas Investment panel to appear :D
    {
        if (GameObject.FindGameObjectWithTag("InvestmentOpenVisit"))
        {
            InvestmentPanel.SetActive(true);
            BankPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            PropertyPanel.SetActive(false);
            JobPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void PropertyOpenVisitButton()//For the ClickToVisitCanvas Property panel to appear :} 
    {
        if (GameObject.FindGameObjectWithTag("PropertyOpenVisit"))
        {
            PropertyPanel.SetActive(true);
            InsurancePanel.SetActive(false);
            BankPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            JobPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void InsuranceOpenVisitButton()//For the ClickToVisitCanvas Insurance panel to appear :} 
    {
        if (GameObject.FindGameObjectWithTag("InsuranceOpenVisit"))
        {
            InsurancePanel.SetActive(true);
            BankPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            PropertyPanel.SetActive(false);
            JobPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void JobOpenVisitButton()//For the ClickToVisitCanvas Job panel to appear :} 
    {
        if (GameObject.FindGameObjectWithTag("JobOpenVisit"))
        {
            JobPanel.SetActive(true);
            InsurancePanel.SetActive(false);
            BankPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            PropertyPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
    }
    public void InformationButton()
    {
        InformationPanel.SetActive(true);
        OptionsButton.SetActive(false);
        BankOfRashidDepositPanel.SetActive(false);
        BankOfRashidPanel.SetActive(false);
        JunnieBankPanel.SetActive(false);
        JunnieBankDepositPanel.SetActive(false);
        LegalFooBankDepositPanel.SetActive(false);
        LegalFooBankPanel.SetActive(false);
        TownCanvas.SetActive(false);
    }
    public void InformationButton2()
    {
        InformationPanelTwo.SetActive(true);
        OptionsButton.SetActive(false);
        BankOfRashidDepositPanel.SetActive(false);
        BankOfRashidPanel.SetActive(false);
        JunnieBankPanel.SetActive(false);
        JunnieBankDepositPanel.SetActive(false);
        LegalFooBankDepositPanel.SetActive(false);
        LegalFooBankPanel.SetActive(false);
        TownCanvas.SetActive(false);
    }
    public void InsuranceOnLeftArrowButtonClick()
    {
        clickCount++;
        
        if (clickCount >= InsurancePanels.Length)
        {
            clickCount = 0;
        }
        InsuranceShowPanel(clickCount);
    }
    public void BankOnLeftArrowButtonClick()
    {
        clickCount++;
        
        if (clickCount >= BankPanels.Length)
        {
            clickCount = 0;
        }
        BankShowPanel(clickCount);
    }
    public void InvestmentLeftArrowButtonClick()
    {
        clickCount++;
        
        if (clickCount >= InvestmentPanels.Length)
        {
            clickCount = 0;
        }
        InvestmentShowPanel(clickCount);
    }
    public void PropertyLeftArrowButtonClick()
    {
        clickCount++;
        
        if (clickCount >= PropertyPanels.Length)
        {
            clickCount = 0;
        }
        PropertyShowPanel(clickCount);
    }
    public void JobLeftArrowButtonClick()
    {
        clickCount++;
        
        if (clickCount >= JobPanels.Length)
        {
            clickCount = 0;
        }
        JobShowPanel(clickCount);
    }
    public void DepositLeftArrowButtonClick()
    {
        clickCount++;

        if (clickCount >= DepositPanels.Length)
        {
            clickCount = 0;
        }
        DepositShowPanel(clickCount);
    }
    public void InsuranceOnRightArrowButtonClick()
    {
        clickCount--;
        
        if (clickCount < 0 )
        {
            clickCount = InsurancePanels.Length -1;
        }
        InsuranceShowPanel(clickCount);
    }
    public void BankOnRightArrowButtonClick()
    {
        clickCount--;
       
        if (clickCount < 0)
        {
            clickCount = BankPanels.Length - 1;
        }
        BankShowPanel(clickCount);
    }
    public void InvestmentRightArrowButtonClick()
    {
        clickCount--;
        
        if (clickCount < 0)
        {
            clickCount = InvestmentPanels.Length - 1;
        }
        InvestmentShowPanel(clickCount);
    }
    public void PropertyRightArrowButtonClick()
    {
        clickCount--;
        
        if (clickCount < 0)
        {
            clickCount = PropertyPanels.Length - 1;
        }
        PropertyShowPanel(clickCount);
    }
    public void JobRightArrowButtonClick()
    {
        clickCount--;
       
        if (clickCount < 0)
        {
            clickCount = JobPanels.Length - 1;
        }
        JobShowPanel(clickCount);
    }
    public void DepositRightArrowButtonClick()
    {
        clickCount--;

        if (clickCount < 0)
        {
            clickCount = DepositPanels.Length - 1;
        }
        DepositShowPanel(clickCount);
    }
    private void InvestmentShowPanel(int index)
    {
        for (int i = 0; i < InvestmentPanels.Length; i++)
        {
            InvestmentPanels[i].SetActive(i == index);
        }
    }
    private void JobShowPanel(int index)
    {
        for (int i = 0; i < JobPanels.Length; i++)
        {
            JobPanels[i].SetActive(i == index);
        }
    }
    private void PropertyShowPanel(int index)
    {
        for (int i = 0; i < PropertyPanels.Length; i++)
        {
            PropertyPanels[i].SetActive(i == index);
        }
    }
    private void InsuranceShowPanel(int index)
    {
        for (int i = 0; i < InsurancePanels.Length; i++)
        {
            InsurancePanels[i].SetActive(i == index);
        }
    }
    private void BankShowPanel(int index )
    {
        for(int i = 0; i< BankPanels.Length; i++)
        {
            BankPanels[i].SetActive(i == index);  
        }      
    }
    private void DepositShowPanel(int index)
    {
        for (int i = 0; i < DepositPanels.Length; i++)
        {
            DepositPanels[i].SetActive(i == index);
        }
    }
    public void NoInsuranceButton()
    {
        NoInsurancePanel.SetActive(true);
    }
    public void LifeInsuranceButton()
    {   
        OptionsButton.SetActive(false);
        InsuranceClickedPanel.SetActive(false);
        LifeInsurancePanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void HealthInsuranceButton()
    {
        OptionsButton.SetActive(false);
        InsuranceClickedPanel.SetActive(false);
        HealthInsurancePanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void CriticalIllnessInsuranceButton()
    {
        OptionsButton.SetActive(false);
        InsuranceClickedPanel.SetActive(false);
        CriticalIllnessInsurancePanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void BankOfRashidButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        BankButton.SetActive(false);    
        BankOfRashidPanel.SetActive(true);
        TownCanvas.SetActive(false);

    }
    public void JunnieBankButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        JunnieBankPanel.SetActive(true);
        TownCanvas.SetActive(false);

    }
    public void NationalFooBankButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        LegalFooBankPanel.SetActive(true);
        TownCanvas.SetActive(false);

    }
    public void ApartmentButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        ApartmentPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void LandedButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        LandedPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void CondominiumButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        CondominiumPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void GameInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        GameInvestmentPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void BusinessInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        BusinessInvestmentPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void GymInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        GymInvestmentPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void PlumberButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        PlumberPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void ZooKeeperButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        ZooKeeperPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void PhotographerButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        PhotographerPanel.SetActive(true);
        TownCanvas.SetActive(false);
    }
    public void ProceedOn()
    {
        if(GameObject.FindGameObjectWithTag("Proceed") || GameObject.FindGameObjectWithTag("Confirm"))
        {
            if(AlertPanel != null)
            {
                AlertPanel.SetActive(false);
            }         
        }
    }
    public void OptionsPanelOpen()
    {
        OptionsPanel.SetActive(true);
        OptionsButton.SetActive(false);
        TownCanvas.SetActive(false);
    }
    public void CloseCanvas()
    {
        if(InsurancePanel != null)
        {
            InsurancePanel.SetActive(false);
            TownCanvas.SetActive(true);
        }
        if (BankPanel != null)
        {
            BankPanel.SetActive(false);
            TownCanvas.SetActive(true);
        }
        if (InvestmentPanel != null)
        {
            InvestmentPanel.SetActive(false);
            TownCanvas.SetActive(true);
        }
         if(PropertyPanel != null)
        {
            PropertyPanel.SetActive(false);
            TownCanvas.SetActive(true);
        }
         if(JobPanel != null)
        {
            JobPanel.SetActive(false);
            TownCanvas.SetActive(true);
        }
    }
    public void OpenClickedCanvas()
    {
        if (GameObject.FindGameObjectWithTag("PropertyVisit"))
        {
            PropertyClickedPanel.SetActive(true);
            PropertyPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            InsuranceClickedPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            InvestmentClickedPanel.SetActive(false);
            BankPanel.SetActive(false);
            BankClickedPanel.SetActive(false);
            JobPanel.SetActive(false);
            JobClickedPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("InsuranceVisit"))
        {
            InsurancePanel.SetActive(false);
            InsuranceClickedPanel.SetActive(true);
            BankClickedPanel.SetActive(false);
            BankPanel.SetActive(false);
            InvestmentClickedPanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            PropertyClickedPanel.SetActive(false);
            PropertyPanel.SetActive(false);
            JobPanel.SetActive(false);
            JobClickedPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("BankVisit"))
        {
            BankPanel.SetActive(false);
            BankClickedPanel.SetActive(true);
            InvestmentClickedPanel.SetActive (false);
            InvestmentPanel.SetActive(false);
            InsuranceClickedPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            PropertyClickedPanel.SetActive(false);
            PropertyPanel.SetActive (false);
            JobPanel.SetActive(false);
            JobClickedPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("InvestmentVisit"))
        {
            InvestmentPanel.SetActive(false);
            InvestmentClickedPanel.SetActive(true);
            BankClickedPanel.SetActive(false);
            BankPanel.SetActive(false);
            InsuranceClickedPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            PropertyClickedPanel.SetActive(false);
            PropertyPanel.SetActive(false);
            JobPanel.SetActive(false);
            JobClickedPanel.SetActive(false);
            TownCanvas.SetActive(false);
        }
        if(GameObject.FindGameObjectWithTag("JobVisit"))
        {
            PropertyClickedPanel.SetActive(false);
            PropertyPanel.SetActive(false);
            InsuranceClickedPanel.SetActive(false);
            InsurancePanel.SetActive(false);
            InvestmentPanel.SetActive(false);
            InvestmentClickedPanel.SetActive(false);
            BankPanel.SetActive(false);
            BankClickedPanel.SetActive(false);
            JobPanel.SetActive(false);
            JobClickedPanel.SetActive(true);
            TownCanvas.SetActive(false);
        }
    }
}
