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
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = buttonSound;
    }

    public void PlayButtonSound()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            soundPlaying = false;
        }
    }

    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadScene", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Selection");
    }
}
