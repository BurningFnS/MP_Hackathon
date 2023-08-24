using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
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
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Selection");
    }
}
