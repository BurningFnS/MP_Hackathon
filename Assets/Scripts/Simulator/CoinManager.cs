using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;
    public int currentCoins;
    public int cashAtHand;
    public Text coinText;
    public Text ageText;

    public int currentAge;
    public int defaultAge = 25;

    public Bank bank;
    public GameObject negativeBalancePanel;
    public GameObject losePanel;
    public GameObject retireButton;
    public Text alertText;

    // Variables for confirmation.
    public GameObject confirmationPanel;
    public Text _MoneyEarned, _Expenditures, _Tips;
    public InsuranceManager insuranceManager;

    public InvestmentManager investment;

    [HideInInspector] public bool fireInsurance;
    [HideInInspector] public bool healthInsurance;
    [HideInInspector] public bool carInsurance;




    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("CollectedCoins");
        cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        currentAge = PlayerPrefs.GetInt("CurrentAge");

        currentCoins = totalCoins + cashAtHand;
        // Optionally, you can update the player's coins display or any other relevant UI elements
        UpdateCoinDisplay();
        ageText.text = "" + currentAge;
        if (currentAge >= 65)
        {
            retireButton.SetActive(true);
        }
    }

    void Update()
    {
        

    }

    public void UpdateCoinDisplay()
    {
        // Code to update the UI display of the collected coins
        // For example, you could set the text of a UI Text component to show the totalCoins value.

        coinText.text = "" + currentCoins;
    }


    public void Confirmation()
    {
        // This function is to open the Continue panel under "ClickedOnCanvas".
        // It contains a portion of the code from the Continue function
        // as it is dumb for users to be allowed to confirm if they can not proceed.
        if (currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if (currentCoins >= 0)
        {
            confirmationPanel.SetActive(true);

            insuranceManager.InsuranceUpdate();

            _MoneyEarned.text = "$" + PlayerPrefs.GetInt("Salary");
            Debug.Log("total insurance expenses: "+ InsuranceManager.totalInsuranceExpenses);
            _Expenditures.text = "$" + (PlayerPrefs.GetInt("WaterBill") + PlayerPrefs.GetInt("ElectricalBill") + InsuranceManager.totalInsuranceExpenses);
            _Tips.text = "Tips: " + Tips.TipArray[Random.Range(0, Tips.TipArray.Length)];

        }
    }

    public void CloseConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    public void Continue()
    {
        if(currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if(currentCoins >= 0)
        {
            confirmationPanel.SetActive(false);

            PlayerPrefs.SetInt("CurrentCoins", currentCoins);
            PlayerPrefs.SetInt("CurrentAge", currentAge + 5);

            PlayerPrefs.SetFloat("BankOfRashidBalance", bank.bankBalance[0]);
            PlayerPrefs.SetFloat("BankOfJunnieBalance", bank.bankBalance[1]);
            PlayerPrefs.SetFloat("BankOfFooBalance", bank.bankBalance[2]);

            PlayerPrefs.SetFloat("GameInvestmentBalance", investment.investmentBalance[0]);
            PlayerPrefs.SetFloat("BusinessInvestmentBalance", investment.investmentBalance[1]);
            PlayerPrefs.SetFloat("GymInvestmentBalance", investment.investmentBalance[2]);

            SceneManager.LoadScene("Level");
        }
    }
 
    public void Proceed()
    {
        losePanel.SetActive(true);
    }

    public void Return()
    {
        negativeBalancePanel.SetActive(false);
    }
}
