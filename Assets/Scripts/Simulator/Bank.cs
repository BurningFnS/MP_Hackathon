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

    private float bankBalance = 0;
    public CoinManager coinManager;

    private void Start()
    {
        UpdateBankBalanceText();
        // Retrieve the number of collected coins from PlayerPrefs
    }
    public void DepositAmount()
    {
        // Check if the input is a valid number
        if (int.TryParse(amountInputField.text, out int InputAmount))
        {
            //Deposit amount is less than or equal to total coins, so player can deposit
            if(InputAmount <= coinManager.totalCoins)
            {
                // Update the bank balance
                bankBalance += InputAmount;

                //Update the coin balance
                coinManager.totalCoins -= InputAmount;

                // Update the balance text
                UpdateBankBalanceText();
                coinManager.UpdateCoinDisplay();

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
                coinManager.totalCoins += InputAmount;

                bankBalance -= InputAmount;

                // Update the balance text
                UpdateBankBalanceText();
                coinManager.UpdateCoinDisplay();

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
