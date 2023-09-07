using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float totalTime = 60f; //Total time for the game in seconds
    public static float timer; //Remaining time 
    private bool isGameOver = false; //boolean flag to check if game has ended

    public Text timerText; //Reference to text UI
    public GameObject timeUpPanel; //Reference to the panel that shows up once the time has run out

    public PlayerController playerController; // Reference to the player script
    //Reference to the text UI
    public Text shieldTimerText;
    public Text magnetTimerText;

    public GameObject pausedScreen; //Reference to the pause screen panel
    public static bool isPaused; //boolean flag to check if the game is paused

    //Reference to the powerup panel
    public GameObject shieldPanel;
    public GameObject magnetPanel;

    //Reference to the number of coins collected and salary text
    public Text coinText;
    public Text salaryText;

    public int salary;
    public int totalCoins;

    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound clip to play
    private bool soundPlaying;       // Flag to track if sound is currently playing

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>(); //Get the component of the audio source
        soundSource.clip = buttonSound; //Set the audio clip of the audio source
    }

    void Start()
    {
        timer = totalTime; // Initialize the timer with the total time
        //Disable all the power-up panels & pause screen on start
        shieldPanel.SetActive(false);
        magnetPanel.SetActive(false);
        pausedScreen.SetActive(false);
        salary = PlayerPrefs.GetInt("Salary") * 5; //Multiply the salary by the 5 years
        Debug.Log(salary);
    }

    void Update()
    {
        //Do nothing if game hasn't started
        if (!PlayerManager.isGameStarted)
            return;

        //Constantly update the coinText and salaryText for the time's up screen
        coinText.text = "Collected: " + PlayerManager.numberOfCoins;
        salaryText.text = "Salary: " + salary;
        


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
            // Get and display the remaining time for the Shield & Magnet power-up with the respective UI
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

    public void GameOver()
    {
        //Pause the game and bring up the time's up panel
        Time.timeScale = 0;
        timeUpPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        pausedScreen.SetActive(true); //Show the pause screen
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        pausedScreen.SetActive(false); //Hide the pause screen
        isPaused = false;
    }
    //Load the Simulator scene
    public void Proceed()
    {
        SceneManager.LoadScene("Simulator");

        //PlayButtonSoundAndLoadScene();

        //Calculate total number of coins and set it to the PlayerPrefs
        totalCoins = PlayerManager.numberOfCoins + salary; 
        PlayerPrefs.SetInt("CollectedCoins", totalCoins);
    }

    //Invoke the LoadRunner function after button sound has finished playing
    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadRunner", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }
    //Load the Simulator scene
    private void LoadRunner()
    {
        SceneManager.LoadScene("Simulator");
    }

    public void QuitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); //Returns and load the main menu scene
    }
}
