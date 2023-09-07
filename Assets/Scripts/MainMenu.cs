using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //Reset all PlayerPrefs to make it into a new game for the player
    private void Start()
    {

        PlayerPrefs.SetInt("CollectedCoins", 0);
        PlayerPrefs.SetInt("CurrentCoins", 0);
        PlayerPrefs.SetInt("CurrentAge", 25);

        PlayerPrefs.SetInt("WaterBill", 200);
        PlayerPrefs.SetInt("ElectricalBill", 200);

        PlayerPrefs.SetFloat("BankOfRashidBalance", 0f);
        PlayerPrefs.SetFloat("BankOfJunnieBalance", 0f);
        PlayerPrefs.SetFloat("BankOfFooBalance", 0f);

        PlayerPrefs.SetInt("JobIndex", 0);
        PlayerPrefs.SetInt("Salary", 0);

        PlayerPrefs.SetFloat("GameInvestmentBalance", 0f);
        PlayerPrefs.SetFloat("BusinessInvestmentBalance", 0f);
        PlayerPrefs.SetFloat("GymInvestmentBalance", 0f);

        PlayerPrefs.SetInt("FireInsurance", 0);
        PlayerPrefs.SetInt("HealthInsurance", 0);
        PlayerPrefs.SetInt("CarInsurance", 0);

        PlayerPrefs.SetInt("Retirement", 0);

        PlayerPrefs.SetInt("Apartment", 0);
        PlayerPrefs.SetInt("Condo", 0);
        PlayerPrefs.SetInt("Landed", 0);

        PlayerPrefs.SetInt("FooBankBankrupt", 0);
        PlayerPrefs.SetInt("ClaimableBankruptcyMoney", 0);

        PlayerPrefs.SetFloat("GeneralVolumeFloat", 0.5f);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Not in use
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Selection"); //Not in use
    }
}
