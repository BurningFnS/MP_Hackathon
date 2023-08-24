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

    private bool retired;

    private void Update()
    {
        if (coinManager.currentAge >= 65 && !retired)
        {
            //Show you have Retired Panel (FORCE PLAYER TO RETIRE)
            forcedRetiredPanel.SetActive(true);
            PlayerPrefs.SetInt("Salary", 0);
            retired = true;
        }

        if (coinManager.currentAge >= 90)
        {
            totalSavings.text = "You have retired with\n$" + coinManager.currentCoins + " in your savings";
            winPanel.SetActive(true);
        }

        //if the player has already retired
        if (retired)
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
        if (retired)
        {
            forcedRetiredPanel.SetActive(true);
        }
        else
        {
            RetireConfirmationPanel.SetActive(true);
        }
    }

    public void YesRetire()
    {
        //Set the player's salary to $0
        PlayerPrefs.SetInt("Salary", 0);
        retired = true;

        RetireConfirmationPanel.SetActive(false);
    }

    public void NoRetire()
    {
        RetireConfirmationPanel.SetActive(false);
    }

    public void Proceed()
    {
        forcedRetiredPanel.SetActive(false);
    }
}
