using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSelection : MonoBehaviour
{
    public GameObject[] jobPanels; //Array of the different job panels
    private int currentPanelIndex = 0; //Index of the current job panel the player is on
    //Boolean flags for the 3 different jobs
    public bool isPhotographer;
    public bool isPlumber;
    public bool isZookeeper;

    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound clip to play
    private bool soundPlaying;      // Flag to track if sound is currently playing

    private void Awake()
    {
        //Gets a reference to the audio source of the object
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = buttonSound;
    }

    public void LoadScene()
    {
        //Depending on the job they select, the PlayerPrefs will set the index of the job and the salary that the job provides
        if (isPhotographer == true)
        {
            PlayerPrefs.SetInt("JobIndex", 0);
            PlayerPrefs.SetInt("Salary", 360);
            Debug.Log("Photographer Selected");
        }
        if (isZookeeper == true)
        {
            PlayerPrefs.SetInt("JobIndex", 1);
            PlayerPrefs.SetInt("Salary", 320);
            Debug.Log("ZooKeeper Selected");
        }
        if (isPlumber == true)
        {
            PlayerPrefs.SetInt("JobIndex", 2);
            PlayerPrefs.SetInt("Salary", 450);
            Debug.Log("Plumber Selected");
        }
        //SceneManager.LoadScene(name);
        PlayButtonSoundAndLoadScene();
    }

    //Plays a button sound and loads a scene after the sound has finished playing
    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadRunner", buttonSound.length); //Invoke LoadScene after sound duration
        }
    }
    //Loads the level scene
    private void LoadRunner()
    {
        SceneManager.LoadScene("Level");
    }


    //Show the current panel on start
    private void Start()
    {
        ShowPanel(currentPanelIndex);
    }

    //Shows the next panel in the array by increasing the current panel index
    public void ShowNextPanel()
    {
        currentPanelIndex = (currentPanelIndex + 1) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    //Shows the previous panel in the array by increasing the current panel index
    public void ShowPreviousPanel()
    {
        currentPanelIndex = (currentPanelIndex - 1 + jobPanels.Length) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    public void ShowPanel(int index)
    {
        //Shows the selected job panel and sets the respective booleans
        for (int i = 0; i < jobPanels.Length; i++)
        {
            jobPanels[i].SetActive(i == index);
            if (index == 0)
            {
                isPhotographer = true;
                isZookeeper = false;
                isPlumber = false;
                Debug.Log("Photographer");
            }
            if (index == 1)
            {
                isZookeeper = true;
                isPhotographer = false;
                isPlumber = false;
                Debug.Log("Zookeeper");
            }
            if (index == 2)
            {
                isPlumber = true;
                isPhotographer = false;
                isZookeeper = false;
                Debug.Log("Plumber");
            }
        }
    }
}