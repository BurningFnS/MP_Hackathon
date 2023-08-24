using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public Sound[] sounds;
    public bool isStartScene = false;
    public bool isRunnerScene = false;
    public bool isSimScene = false;
   
    

    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
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

    public void PlaysSound(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
}
