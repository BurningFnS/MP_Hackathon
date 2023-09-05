using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Sound[] sounds; //Array of all the Sounds and respective audio clips
    //bools to check for the different scenes
    public bool isStartScene = false;
    public bool isRunnerScene = false;
    public bool isSimScene = false;

    public Slider _MusicSlider;

    void Start()
    {

        LoadValue();

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); //Set the according properties of the audiosource of the gameobject
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        //Check what scene the player is in and plays the respective music
        if(isStartScene == true && isRunnerScene == false && isSimScene == false)
        {
            PlaysSound("StartSong");
        }
        if(isSimScene == false && isRunnerScene == true && isSimScene == false)
        {
            PlaysSound("RunnerSong");
        }
        else if(isStartScene == false && isRunnerScene == false && isSimScene == true)
        {
            PlaysSound("SimSong");
        }
        
    }

    private void FixedUpdate()
    {
        VolumeAdjustments();
    }

    public void PlaysSound(string name)
    {
        foreach(Sound s in sounds)
        {
            //Checks if the name of the sound is the same of the argument name and plays the according sound
            if (s.name == name)
                s.source.Play();
        }
    }

    public void VolumeAdjustments()
    {
        foreach (Sound s in sounds)
        {
            s.volume = _MusicSlider.value;
            PlayerPrefs.SetFloat("GeneralVolumeFloat", s.volume);
            AudioListener.volume = s.volume;
        }

        LoadValue();
    }

    public void LoadValue()
    {
        foreach (Sound s in sounds)
        {
            s.volume = PlayerPrefs.GetFloat("GeneralVolumeFloat");
            _MusicSlider.value = s.volume;
        }


    }
}
