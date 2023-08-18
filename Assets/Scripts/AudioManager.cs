using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject character;
    public AudioSource backgroundMusicSource;
    public AudioClip calmMusic;
    public AudioClip backgroundMusic;

    //public AudioSource collisionSource;
    //public AudioClip collisionImpactSFX;

    public bool isSimScene = false;

    private void Start()
    {
        PlayBackgroundMusic(calmMusic);
    }

    private void Update()
    {
        // Logic for detecting scene changes and player collisions
        // Update isIntenseScene variable accordingly

        

        UpdateBackgroundMusic();
    }

    //idk how this works for oncollision diwefwife
    //private void OnCollisionEnter(Collision collision)
    //{
        // Check if the collision involves an obstacle
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //       PlayCollisionSFX();
    //    }
    //}

    private void UpdateBackgroundMusic()
    {
        AudioClip targetMusic = isSimScene ? backgroundMusic : calmMusic;

        if (backgroundMusicSource.clip != targetMusic)
        {
            PlayBackgroundMusic(targetMusic);
        }
    }

    private void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusicSource.clip = music;
        backgroundMusicSource.Play();
    }

    //private void PlayCollisionSFX()
    //{
    //    collisionSource.PlayOneShot(collisionImpactSFX);
    //}
}
