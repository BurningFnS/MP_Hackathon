using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public InputField[] amountInputField;
    public Text[] moneyInBankText;
    public GameObject error;
    public Text errorText;

    public int[] bankBalance;
    public CoinManager coinManager;

    private void Start()
    {
        bankBalance[0] = PlayerPrefs.GetInt("BankOfRashidBalance");
        bankBalance[1] = PlayerPrefs.GetInt("BankOfJunnieBalance");
        bankBalance[2] = PlayerPrefs.GetInt("BankOfFooBalance");

        for (int i = 0; i < moneyInBankText.Length; i++)
        {
            moneyInBankText[i].text = "Money in bank: $" + bankBalance[i].ToString("");
        }
    }
    public void DepositAmount()
    {
        int bankIndex = GetBankIndex();

        // Check if the input is a valid number
        if (int.TryParse(amountInputField[bankIndex].text, out int InputAmount))
        {
            //Deposit amount is less than or equal to total coins, so player can deposit
            if (InputAmount <= coinManager.currentCoins)
            {
                // Update the bank balance
                bankBalance[bankIndex] += InputAmount;

                //Update the coin balance
                coinManager.currentCoins -= InputAmount;

                // Update the balance text
                moneyInBankText[bankIndex].text = "Money in bank: $" + bankBalance[bankIndex].ToString("");
                coinManager.UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField[bankIndex].text = "";
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
        int bankIndex = GetBankIndex();

        // Check if the input is a valid number
        if (int.TryParse(amountInputField[bankIndex].text, out int InputAmount))
        {
            if (InputAmount <= bankBalance[bankIndex])
            {
                coinManager.currentCoins += InputAmount;

                bankBalance[bankIndex] -= InputAmount;

                // Update the balance text
                moneyInBankText[bankIndex].text = "Money in bank: $" + bankBalance[bankIndex].ToString("");
                coinManager.UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField[bankIndex].text = "";
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

    public void Close()
    {
        error.SetActive(false);
        errorText.text = "";
    }

    int GetBankIndex()
    {
        if (UIManager.atBankOfRashid)
            return 0;
        else if (UIManager.atBankOfJunnie)
            return 1;
        else if (UIManager.atBankOfFoo)
            return 2;
        return -1;
    }
}
