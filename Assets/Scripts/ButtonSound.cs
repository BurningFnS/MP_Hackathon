using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{
    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound clip to play
    private bool soundPlaying;       // Flag to track if sound is currently playing

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>(); //Get the AudioSource component and assign it to the soundSource variable
        soundSource.clip = buttonSound; //Set the AudioSource clip to buttonSound
    }

    //Play button sound and change the bool flags
    public void PlayButtonSound()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            soundPlaying = false;
        }
    }

    //Play the button sound then load the next scene after the sound finishes
    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadScene", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }

    //Loads the selection scene
    private void LoadScene()
    {
        SceneManager.LoadScene("Selection");
    }
}
