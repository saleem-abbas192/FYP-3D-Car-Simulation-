using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    public GameObject[] bgMusic;
    

    void Awake()
    {

        bgMusic = GameObject.FindGameObjectsWithTag("bgmusic");
        if(bgMusic.Length >= 2)
        {
            Destroy(bgMusic[1]);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sound)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.loop = s.loop;
        }

    }

    void Start()
    {
        playAudio("Background Music");
    }

    void Update()
    {
        foreach (Sounds s in sound)
        {
            if (s.audioSource.clip.name == "Background Music")
            {
                s.audioSource.volume = PlayerPrefs.GetFloat("MusicSliderValue");
            }
            else
            {
                s.audioSource.volume = PlayerPrefs.GetFloat("SoundSliderValue");
            }
        }
    }

    public void playAudio(string name)
    {
        Sounds s = Array.Find(sound, sound=>sound.name == name);
        if(s.name == null)
        {
            return;
        }
        s.audioSource.Play();
    }
}
