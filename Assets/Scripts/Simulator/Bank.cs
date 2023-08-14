using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public InputField amountInputField;
    public Text moneyInBankText;
    public GameObject error;
    public Text errorText;

    private int totalCoins = 0;
    public Text coinText;

    private float bankBalance = 0;

    private void Start()
    {
        UpdateBankBalanceText();

        // Retrieve the number of collected coins from PlayerPrefs
        totalCoins += PlayerPrefs.GetInt("CollectedCoins", 0);
        // Optionally, you can update the player's coins display or any other relevant UI elements
        UpdateCoinDisplay();
    }
    public void DepositAmount()
    {
        // Check if the input is a valid number
        if (int.TryParse(amountInputField.text, out int InputAmount))
        {
            //Deposit amount is less than or equal to total coins, so player can deposit
            if(InputAmount <= totalCoins)
            {
                // Update the bank balance
                bankBalance += InputAmount;

                //Update the coin balance
                totalCoins -= InputAmount;

                // Update the balance text
                UpdateBankBalanceText();
                UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField.text = "";
            }
            else
            {
                // Display a message for insufficient balance
                error.SetActive(true);
                errorText.text = "Insufficient balance.";
            }
        }
        else
        {
            // Display a message for invalid input
            error.SetActive(true);
            errorText.text = "Please enter a valid number.";
        }
    }

    public void WithdrawAmount()
    {
        // Check if the input is a valid number
        if (int.TryParse(amountInputField.text, out int InputAmount))
        {
            if (InputAmount <= bankBalance)
            {
                totalCoins += InputAmount;

                bankBalance -= InputAmount;

                // Update the balance text
                UpdateBankBalanceText();
                UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField.text = "";
            }
            else
            {
                // Display a message for insufficient balance
                error.SetActive(true);
                errorText.text = "Insufficient balance.";
            }
        }
        else
        {
            // Display a message for invalid input
            error.SetActive(true);
            errorText.text = "Please enter a valid number.";
        }
    }

    private void UpdateCoinDisplay()
    {
        // Code to update the UI display of the collected coins
        // For example, you could set the text of a UI Text component to show the totalCoins value.
     
        coinText.text = "" + totalCoins;
    }
    
    private void UpdateBankBalanceText()
    {
        moneyInBankText.text = "Money in bank: $" + bankBalance.ToString("");
    }

    public void Close()
    {
        error.SetActive(false);
        errorText.text = "";
    }
}
