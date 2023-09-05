using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//This script creates a new class to define different sounds and their respective name, audio clip, volume and whether the sound should loop
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
