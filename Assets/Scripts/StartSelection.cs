using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSelection : MonoBehaviour
{
    public GameObject[] jobPanels;
    private int currentPanelIndex = 0;
    public bool isPhotographer;
    public bool isPlumber;
    public bool isZookeeper;

    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound clip to play
    private bool soundPlaying;       // Flag to track if sound is currently playing

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = buttonSound;
    }

    public void LoadScene()
    {
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


    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadRunner", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }

    private void LoadRunner()
    {
        SceneManager.LoadScene("Level");
    }



    private void Start()
    {
        ShowPanel(currentPanelIndex);
    }

    public void ShowNextPanel()
    {
        currentPanelIndex = (currentPanelIndex + 1) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    public void ShowPreviousPanel()
    {
        currentPanelIndex = (currentPanelIndex - 1 + jobPanels.Length) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    public void ShowPanel(int index)
    {
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