using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip audioClip;
    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
    
}
