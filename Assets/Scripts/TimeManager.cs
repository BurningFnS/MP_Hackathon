using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
=======
using UnityEngine.SceneManagement;
>>>>>>> HJ-Autistic

public class TimeManager : MonoBehaviour
{
    public float totalTime = 60f; //Total time for the game in seconds
    public static float timer; //Remaining time 
    private bool isGameOver = false;

    public Text timerText;
    public GameObject timeUpPanel;

<<<<<<< HEAD
    void Start()
    {
        timer = totalTime; // Initialize the timer with the total time
=======
    public PlayerController playerController; // Reference to the player script
    public Text shieldTimerText;
    public Text magnetTimerText;
    public GameObject pausedScreen;
    public static bool isPaused;

    public GameObject shieldPanel;
    public GameObject magnetPanel;

    public Text coinText;

    void Start()
    {
        timer = totalTime; // Initialize the timer with the total time
        shieldPanel.SetActive(false);
        magnetPanel.SetActive(false);
        pausedScreen.SetActive(false);
>>>>>>> HJ-Autistic
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

<<<<<<< HEAD
=======

        coinText.text = "Collected: " + PlayerManager.numberOfCoins;    


>>>>>>> HJ-Autistic
        if (!isGameOver) 
        {
            // Update the timer every frame
            timer -= Time.deltaTime;

            // Check if the timer has reached zero or below
            if (timer <= 0f)
            {
                timer = 0f;
                isGameOver = true;

                // Call the GameOver function or display the Time's Up UI here
                GameOver();
            }

            // Update the UI text to display the remaining time
            UpdateTimerUI();
        }
<<<<<<< HEAD
=======

        if (playerController != null)
        {
            // Get and display the remaining time for the Shield power-up
            float shieldRemainingTime = playerController.GetShieldRemainingTime();
            float magnetRemainingTime = playerController.GetMagnetRemainingTime();

            if (shieldRemainingTime > 0)
            {
                shieldPanel.SetActive(true);
                shieldTimerText.text = shieldRemainingTime.ToString("F1") + "s";
            }
            else
            {
                shieldPanel.SetActive(false);
            }

            if (magnetRemainingTime > 0)
            {
                magnetPanel.SetActive(true);
                magnetTimerText.text = magnetRemainingTime.ToString("F1") + "s";
            }
            else
            {
                magnetPanel.SetActive(false);
            }
        }


>>>>>>> HJ-Autistic
    }

    private void UpdateTimerUI()
    {
        // Format the remaining time as minutes:seconds
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.CeilToInt(timer % 60f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

<<<<<<< HEAD
    private void GameOver()
=======
    public void GameOver()
>>>>>>> HJ-Autistic
    {
        Time.timeScale = 0;
        timeUpPanel.SetActive(true);
    }
<<<<<<< HEAD
=======

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        pausedScreen.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        pausedScreen.SetActive(false);
        isPaused = false;
    }

    public void Proceed()
    {
        SceneManager.LoadScene("Simulator");

        PlayerPrefs.SetInt("CollectedCoins", PlayerManager.numberOfCoins);
    }
>>>>>>> HJ-Autistic
}
