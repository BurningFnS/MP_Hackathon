using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    //Arrays of the inputfields and money in bank texts in the different bank panels
    public InputField[] amountInputField; 
    public Text[] moneyInBankText;

    public GameObject error; //Error panel to show any errors to player
    public Text errorText;//Error text to show any errors to player

    public float[] bankBalance; //Array to store the bank balance
    public CoinManager coinManager; 

    //Variables to store interest amount and bank balance including the interest
    public float interestAmount;
    public float bankBalanceWithInterest;

    //Panel to show deposit and withdraw panels
    public GameObject depositPanel;
    public GameObject withdrawnPanel;
    private void Start()
    {
        //Initialize the bank balances with PlayerPrefs
        bankBalance[0] = PlayerPrefs.GetFloat("BankOfRashidBalance");
        bankBalance[1] = PlayerPrefs.GetFloat("BankOfJunnieBalance");
        bankBalance[2] = PlayerPrefs.GetFloat("BankOfFooBalance");

        //Loop through the 3 different banks and calculate the balance including interest and round it
        for (int i = 0; i < moneyInBankText.Length; i++)
        {
            if(i == 0)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.05f, 4));
            }
            if (i == 1)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.07f, 1));
            }
            if (i == 2)
            {
                bankBalance[i] = RoundBalance(CalculateInterest(bankBalance[i], 0.12f, 1));
            }
            //Update the UI text after calculating the balance
            moneyInBankText[i].text = "Money in bank: $" + bankBalance[i].ToString("");
        }
    }

    public void DepositAmount()
    {
        int bankIndex = GetBankIndex(); //Get the index of the bank the player is on

        // Check if the input is a valid number
        if (int.TryParse(amountInputField[bankIndex].text, out int InputAmount))
        {
            if (InputAmount < 0)
            {
                // Display a warning message for negative input
                error.SetActive(true);
                errorText.text = "Please enter a positive number.";

                // Exit the method to prevent further execution
                return;
            }
            //Deposit amount is less than or equal to total coins, so player can deposit
            if (InputAmount <= coinManager.currentCoins)
            {
                //Play the animation for depositing
                StartCoroutine(SuccessfullyDepositedMoney());
                // Update the bank balance
                bankBalance[bankIndex] += InputAmount;

                //Update the coin balance
                coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins -= InputAmount);//Make the coin UI animate to the new amount

                // Update the balance text
                moneyInBankText[bankIndex].text = "Money in bank: $" + bankBalance[bankIndex].ToString("");
                //coinManager.UpdateCoinDisplay();

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
            if (InputAmount < 0)
            {
                // Display a warning message for negative input
                error.SetActive(true);
                errorText.text = "Please enter a positive number.";

                // Exit the method to prevent further execution
                return;
            }
            if (InputAmount <= bankBalance[bankIndex])
            {
                //Play the animation for withdraw
                StartCoroutine(SuccessfullyWithdrawnMoney());
                coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins += InputAmount); //Make the coin UI animate to the new amount

                bankBalance[bankIndex] -= InputAmount;

                // Update the balance text
                moneyInBankText[bankIndex].text = "Money in bank: $" + bankBalance[bankIndex].ToString("");
                //coinManager.UpdateCoinDisplay();

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

    //Close the error panel and reset the error text
    public void Close()
    {
        error.SetActive(false);
        errorText.text = "";
    }

    //Get the index of the bank the player is currently on
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

    //Calculate interest of the bank by 5 years
    public float CalculateInterest(float bankBalance, float annualIntRate, int compoundFrequency)
    {
        int years = 5;

        float calculatedAmount = CalculateCompoundInterest(bankBalance, annualIntRate, compoundFrequency, years);

        return calculatedAmount;
    }

    //Calculate the compound interest using principal value, interest rate and compounding frequency
    private float CalculateCompoundInterest(float principal, float rate, int compoundingFreq, int years)
    {
        // Convert annual rate to per-compounding period rate
        float ratePerPeriod = rate / compoundingFreq;

        // Calculate the compound interest amount
        float amount = principal * Mathf.Pow(1 + ratePerPeriod, compoundingFreq * years);

        return amount;
    }

    //Display the deposit success panel then hide it after a few seconds
    IEnumerator SuccessfullyDepositedMoney()
    {
        depositPanel.SetActive(true);

        yield return new WaitForSeconds(2.09f);

        depositPanel.SetActive(false);
    }
    //Display the withdraw success panel then hide it after a few seconds
    IEnumerator SuccessfullyWithdrawnMoney()
    {
        withdrawnPanel.SetActive(true);

        yield return new WaitForSeconds(1.99f);

        withdrawnPanel.SetActive(false);
    }
}
