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

    public float[] bankBalance;
    public CoinManager coinManager;

    public float interestAmount;
    public float bankBalanceWithInterest;

    private void Start()
    {
        bankBalance[0] = PlayerPrefs.GetFloat("BankOfRashidBalance");
        bankBalance[1] = PlayerPrefs.GetFloat("BankOfJunnieBalance");
        bankBalance[2] = PlayerPrefs.GetFloat("BankOfFooBalance");


        for (int i = 0; i < moneyInBankText.Length; i++)
        {
            if(i == 0)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.03f, 1));
            }
            if (i == 1)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.12f, 1));
            }
            if (i == 2)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.10f, 1));
            }
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

    private int RoundBalance(float value)
    {
        // Check if the fractional part is greater than or equal to 0.5
        if (value - Mathf.Floor(value) >= 0.5f)
        {
            return Mathf.CeilToInt(value);
        }
        else
        {
            return Mathf.FloorToInt(value);
        }
    }

    public float CalculateInterest(float bankBalance, float annualIntRate, int compoundFrequency)
    {
        int years = 5;

        float calculatedAmount = CalculateCompoundInterest(bankBalance, annualIntRate, compoundFrequency, years);

        return calculatedAmount;
    }

    private float CalculateCompoundInterest(float principal, float rate, int compoundingFreq, int years)
    {
        // Convert annual rate to per-compounding period rate
        float ratePerPeriod = rate / compoundingFreq;

        // Calculate the compound interest amount
        float amount = principal * Mathf.Pow(1 + ratePerPeriod, compoundingFreq * years);

        return amount;
    }
}
