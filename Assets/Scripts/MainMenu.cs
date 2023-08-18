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

        PlayerPrefs.SetInt("BankOfRashidBalance", 0);
        PlayerPrefs.SetInt("BankOfJunnieBalance", 0);
        PlayerPrefs.SetInt("BankOfFooBalance", 0);

        PlayerPrefs.SetInt("JobIndex", 0);
        PlayerPrefs.SetInt("Salary", 0);

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
