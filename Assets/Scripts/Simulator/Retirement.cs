using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Retirement : MonoBehaviour
{
    public CoinManager coinManager;
    public GameObject RetireConfirmationPanel;
    public GameObject winPanel;
    public GameObject forcedRetiredPanel;

    public Text totalSavings;

    public RectTransform retireText;

    public Sprite RetiredButton; // Already Retired Button
    public Image button; // Reference to the Image component of the button

    public Bank bank;
    public float bankTotal;
    private void Update()
    {
        bankTotal= bank.bankBalance[0] + bank.bankBalance[1] + bank.bankBalance[2];
        if (coinManager.currentAge >= 65 && PlayerPrefs.GetInt("Retirement") == 0)
        {
            if (coinManager.currentAge >= 65 && PlayerPrefs.GetInt("JobIndex") == 0) //for the perks for pension 
            {
                PlayerPrefs.SetInt("JobIndex", 0);
                PlayerPrefs.SetInt("Retirement", 1);
            }
            //Show you have Retired Panel (FORCE PLAYER TO RETIRE)
            forcedRetiredPanel.SetActive(true);
            BuildingClickHandler.canClickOnBuildings = false;
            PlayerPrefs.SetInt("JobIndex", 3);
            PlayerPrefs.SetInt("Salary", 0);
            PlayerPrefs.SetInt("Retirement", 1);
            Debug.Log(PlayerPrefs.GetInt("JobIndex"));
        }

        if (coinManager.currentAge >= 90)
        {
            totalSavings.text = "You have retired with\n$" + (coinManager.currentCoins + bankTotal) + " in your savings";
            winPanel.SetActive(true);
            BuildingClickHandler.canClickOnBuildings = false;
            Debug.Log(totalSavings.text);
        }

        //if the player has already retired
        if (PlayerPrefs.GetInt("Retirement") == 1)
        {
            //change the retire button image to the locked one
            button.sprite = RetiredButton;
            Vector3 newPosition = retireText.anchoredPosition;
            newPosition.x = -8f;
            retireText.anchoredPosition = newPosition;
        }
    }

    //Retire button
    public void Retire()
    {
        if (PlayerPrefs.GetInt("Retirement") == 1)
        {
            forcedRetiredPanel.SetActive(true);
            BuildingClickHandler.canClickOnBuildings = false;
        }
        else
        {
            RetireConfirmationPanel.SetActive(true);
            BuildingClickHandler.canClickOnBuildings = false;
        }
    }

    public void YesRetire()
    {
        //Set the player's salary to $0
        PlayerPrefs.SetInt("Salary", 0);
        PlayerPrefs.SetInt("Retirement", 1);
        PlayerPrefs.SetInt("JobIndex", 3);

        RetireConfirmationPanel.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;
    }

    public void NoRetire()
    {
        RetireConfirmationPanel.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;
    }

    public void Proceed()
    {
        forcedRetiredPanel.SetActive(false);
        BuildingClickHandler.canClickOnBuildings = true;
    }
}
