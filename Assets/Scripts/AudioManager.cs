using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Audio[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playMusic("MainTheme");
    }

    public void playMusic(string name)
    {
        Audio audio = Array.Find(musicAudio, x => x.name == name);

        if(audio == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            musicSource.clip = audio.clip;
            musicSource.Play();
        }
    }

    public void playSFX(string name)
    {
        Audio audio = Array.Find(sfxAudio, x => x.name == name);

        if (audio == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            sfxSource.PlayOneShot(audio.clip);
        }
    }


    public void OnButtonePress()
    {
        stopMusic("MainTheme");
    }

    public void stopMusic(string name)
    {
        Audio audio = Array.Find(musicAudio, x => x.name == name);

        if (audio == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            musicSource.clip = audio.clip;
            musicSource.Stop();
        }
    }

    public void toggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void toggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void musicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void sfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    
}
