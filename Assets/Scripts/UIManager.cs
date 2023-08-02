using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject ClickToVisitCanvas;
    public GameObject ClickedOnCanvas;
    public GameObject AfterVisitCanvas;
    public GameObject AlertPanel;
    public GameObject Background;
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
    public GameObject NationalFooBankPanel;
    public GameObject BankOfRashidDepositPanel;
    public GameObject JunnieBankDepositPanel;
    public GameObject NationalFooBankDepositPanel;
    public GameObject InformationPanel;
    public GameObject[] InsurancePanels;
    public GameObject[] PropertyPanels;
    public GameObject[] BankPanels;
    public GameObject[] JobPanels;
    public GameObject[] InvestmentPanels;
    public GameObject[] DepositPanels; 
    private int clickCount = 0;

    public void CloseAlertBox()
    {
        if (AlertPanel != null)
        {
            AlertPanel.SetActive(false);
            Background.SetActive(false);
        }
    }
    public void ReturnBack() //Just for the Return Arrows, where if the respective panels pop up and u press the return arrow, the respective panel will close. 
    {
        if (GameObject.FindGameObjectWithTag("ReturnBack"))
        {
            if (PropertyClickedPanel != null)
            {
                PropertyClickedPanel.SetActive(false);
            }
            if (BankClickedPanel != null)
            {
                BankClickedPanel.SetActive(false);
            }
            if (InsuranceClickedPanel != null)
            {
                InsuranceClickedPanel.SetActive(false);
            }
            if (InvestmentClickedPanel != null)
            {
                InvestmentClickedPanel.SetActive(false);
            }
            if (JobClickedPanel != null)
            {
                JobClickedPanel.SetActive(false);
            }
            if (NoInsurancePanel != null)
            {
                NoInsurancePanel.SetActive(false);
            }
            if (LifeInsurancePanel != null)
            {
                LifeInsurancePanel.SetActive(false);
            }
            if (HealthInsurancePanel != null)
            {
                HealthInsurancePanel.SetActive(false);
            }
            if (CriticalIllnessInsurancePanel != null)
            {
                CriticalIllnessInsurancePanel.SetActive(false);
            }
            if (BankOfRashidPanel != null)
            {
                BankOfRashidPanel.SetActive(false);
            }
            if (JunnieBankPanel != null)
            {
                JunnieBankPanel.SetActive(false);
            }
            if (NationalFooBankPanel != null)
            {
                NationalFooBankPanel.SetActive(false);
            }
            if (LandedPanel != null)
            {
                LandedPanel.SetActive(false);
            }
            if (ApartmentPanel != null)
            {
                ApartmentPanel.SetActive(false);
            }
            if (CondominiumPanel != null)
            {
                CondominiumPanel.SetActive(false);
            }
            if (GameInvestmentPanel != null)
            {
                GameInvestmentPanel.SetActive(false);
            }
            if (BusinessInvestmentPanel != null)
            {
                BusinessInvestmentPanel.SetActive(false);
            }
            if (GymInvestmentPanel != null)
            {
                GymInvestmentPanel.SetActive(false);
            }
            if (PlumberPanel != null)
            {
                PlumberPanel.SetActive(false);
            }
            if (ZooKeeperPanel != null)
            {
                ZooKeeperPanel.SetActive(false);
            }
            if (PhotographerPanel != null)
            {
                PhotographerPanel.SetActive(false);
            }
            if(BankOfRashidDepositPanel != null)
            {
                BankOfRashidDepositPanel.SetActive(false);
            }
            if(JunnieBankDepositPanel != null)
            {
                JunnieBankDepositPanel.SetActive(false);
            }
            if(NationalFooBankDepositPanel != null)
            {
                NationalFooBankDepositPanel.SetActive(false);
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
            BankOfRashidPanel.SetActive(false);
            BankOfRashidDepositPanel.SetActive(true);
        }
    }
    public void ConfirmJunnieBankButton()
    {
        if (JunnieBankPanel != null)
        {
            JunnieBankPanel.SetActive(false);
            JunnieBankDepositPanel.SetActive(true);
        }
    }
    public void ConfirmNationalFooBankButton()
    {
        if (NationalFooBankPanel != null)
        {
            NationalFooBankPanel.SetActive(false);
            NationalFooBankDepositPanel.SetActive(true);
        }
    }
    public void OkayButton()
    {
        if (InformationPanel != null && clickCount ==0 )
        {
            InformationPanel.SetActive(false);
            BankOfRashidPanel.SetActive(true);
        }
        if (InformationPanel != null && clickCount == 1)
        {
            InformationPanel.SetActive(false);
            JunnieBankPanel.SetActive(true);           
        }
        if (InformationPanel != null && clickCount == 2 )
        {
            InformationPanel.SetActive(false);
            NationalFooBankPanel.SetActive(true);
        }
    }
    public void DepositOkayButton()
    {
        if (InformationPanel != null && clickCount == 0)
        {
            InformationPanel.SetActive(false);
            BankOfRashidDepositPanel.SetActive(true);
        }
        if (InformationPanel != null && clickCount == 1)
        {
            InformationPanel.SetActive(false);
            JunnieBankDepositPanel.SetActive(true);
        }
        if (InformationPanel != null && clickCount == 2)
        {
            InformationPanel.SetActive(false);
            NationalFooBankDepositPanel.SetActive(true);
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
        NationalFooBankDepositPanel.SetActive(false);
        NationalFooBankPanel.SetActive(false);
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
    }
    public void HealthInsuranceButton()
    {
        OptionsButton.SetActive(false);
        InsuranceClickedPanel.SetActive(false);
        HealthInsurancePanel.SetActive(true);
    }
    public void CriticalIllnessInsuranceButton()
    {
        OptionsButton.SetActive(false);
        InsuranceClickedPanel.SetActive(false);
        CriticalIllnessInsurancePanel.SetActive(true);
    }
    public void BankOfRashidButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        BankOfRashidPanel.SetActive(true);
        
    }
    public void JunnieBankButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        JunnieBankPanel.SetActive(true);
        
    }
    public void NationalFooBankButton()
    {
        OptionsButton.SetActive(false);
        BankClickedPanel.SetActive(false);
        NationalFooBankPanel.SetActive(true);
       
    }
    public void ApartmentButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        ApartmentPanel.SetActive(true);
    }
    public void LandedButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        LandedPanel.SetActive(true);
    }
    public void CondominiumButton()
    {
        OptionsButton.SetActive(false);
        PropertyClickedPanel.SetActive(false);
        CondominiumPanel.SetActive(true);
    }
    public void GameInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        GameInvestmentPanel.SetActive(true);
    }
    public void BusinessInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        BusinessInvestmentPanel.SetActive(true);
    }
    public void GymInvestmentButton()
    {
        OptionsButton.SetActive(false);
        InvestmentClickedPanel.SetActive(false);
        GymInvestmentPanel.SetActive(true);
    }
    public void PlumberButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        PlumberPanel.SetActive(true);
    }
    public void ZooKeeperButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        ZooKeeperPanel.SetActive(true);
    }
    public void PhotographerButton()
    {
        OptionsButton.SetActive(false);
        JobClickedPanel.SetActive(false);
        PhotographerPanel.SetActive(true);
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
    }
    public void CloseCanvas()
    {
        if(InsurancePanel != null)
        {
            InsurancePanel.SetActive(false);    
        }
        if (BankPanel != null)
        {
            BankPanel.SetActive(false);           
        }
        if (InvestmentPanel != null)
        {
            InvestmentPanel.SetActive(false);          
        }
         if(PropertyPanel != null)
        {
            PropertyPanel.SetActive(false);       
        }
         if(JobPanel != null)
        {
            JobPanel.SetActive(false);
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
        }
    }
}
