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

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
