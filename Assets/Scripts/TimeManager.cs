using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float totalTime = 60f; //Total time for the game in seconds
    public static float timer; //Remaining time 
    private bool isGameOver = false;

    public Text timerText;
    public GameObject timeUpPanel;

    public PlayerController playerController; // Reference to the player script
    public Text shieldTimerText;
    public Text magnetTimerText;

    public GameObject shieldPanel;
    public GameObject magnetPanel;

    void Start()
    {
        timer = totalTime; // Initialize the timer with the total time
        shieldPanel.SetActive(false);
        magnetPanel.SetActive(false);

    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

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
    }

    private void UpdateTimerUI()
    {
        // Format the remaining time as minutes:seconds
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.CeilToInt(timer % 60f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        timeUpPanel.SetActive(true);
    }
}
