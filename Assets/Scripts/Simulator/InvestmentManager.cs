using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestmentManager : MonoBehaviour
{
    public InputField[] amountInputField;
    public Text[] moneyInvestedText;
    public GameObject error;
    public Text errorText;

    public float[] investmentBalance;
    public CoinManager coinManager;

    [HideInInspector] public float gameInvestmentRate;
    [HideInInspector] public float businessInvestmentRate;
    [HideInInspector] public float gymInterestRate;


    private void Start()
    {
        investmentBalance[0] = PlayerPrefs.GetFloat("GameInvestmentBalance");
        investmentBalance[1] = PlayerPrefs.GetFloat("BusinessInvestmentBalance");
        investmentBalance[2] = PlayerPrefs.GetFloat("GymInvestmentBalance");

        //gameInvestmentRate = Random.RandomRange
        
        for (int i = 0; i < moneyInvestedText.Length; i++)
        {
            if (i == 0)
            {
                investmentBalance[i] = RoundBalance(CalculateNewInvestmentPrice(investmentBalance[i], 0.03f));
            }
            if (i == 1)
            {
                investmentBalance[i] = RoundBalance(CalculateNewInvestmentPrice(investmentBalance[i], 0.12f));
            }
            if (i == 2)
            {
                investmentBalance[i] = RoundBalance(CalculateNewInvestmentPrice(investmentBalance[i], 0.10f));
            }
            moneyInvestedText[i].text = "Money invested:  $" + investmentBalance[i].ToString("");
        }
    }

    public void DepositAmount()
    {
        int investmentIndex = GetInvestmentIndex();

        // Check if the input is a valid number
        if (int.TryParse(amountInputField[investmentIndex].text, out int InputAmount))
        {
            //Deposit amount is less than or equal to total coins, so player can deposit
            if (InputAmount <= coinManager.currentCoins)
            {
                // Update the bank balance
                investmentBalance[investmentIndex] += InputAmount;

                //Update the coin balance
                coinManager.currentCoins -= InputAmount;

                // Update the balance text
                moneyInvestedText[investmentIndex].text = "Money invested:  $" + investmentBalance[investmentIndex].ToString("");
                coinManager.UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField[investmentIndex].text = "";
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
            Debug.Log(investmentIndex);
            // Display a message for invalid input
            error.SetActive(true);
            errorText.text = "Please enter a valid number.";
        }
    }

    public void WithdrawAmount()
    {
        int investmentIndex = GetInvestmentIndex();

        // Check if the input is a valid number
        if (int.TryParse(amountInputField[investmentIndex].text, out int InputAmount))
        {
            if (InputAmount <= investmentBalance[investmentIndex])
            {
                coinManager.currentCoins += InputAmount;

                investmentBalance[investmentIndex] -= InputAmount;

                // Update the balance text
                moneyInvestedText[investmentIndex].text = "Money invested: $" + investmentBalance[investmentIndex].ToString("");
                coinManager.UpdateCoinDisplay();

                // Clear the input field and feedback text
                amountInputField[investmentIndex].text = "";
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
            Debug.Log("withdraw:" + investmentIndex);
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

    int GetInvestmentIndex()
    {
        if (UIManager.atGameInvest)
            return 0;
        else if (UIManager.atBusinessInvest)
            return 1;
        else if (UIManager.atGymInvest)
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

    public float CalculateNewInvestmentPrice(float moneyInvested, float stockWorth)
    {
        //int years = 5;

        float calculatedAmount = moneyInvested * stockWorth;

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
