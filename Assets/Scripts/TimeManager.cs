using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float totalTime = 60f; //Total time for the game in seconds
    private float timer; //Remaining time 
    private bool isGameOver = false;

    public Text timerText;
    public GameObject timeUpPanel;

    void Start()
    {
        timer = totalTime; // Initialize the timer with the total time
    }

    void Update()
    {
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
    }

    private void UpdateTimerUI()
    {
        // Format the remaining time as minutes:seconds
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        timeUpPanel.SetActive(true);
    }
}
