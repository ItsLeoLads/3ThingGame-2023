using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            playMusic("MainTheme");
        }
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

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {

        Audio audio = new Audio();

        switch (scene.name)
        {
            case "tutorial":
                audio = Array.Find(musicAudio, x => x.name == "CityTheme");
                musicSource.clip = audio.clip;
                musicSource.Play();
                break;
            case "level1":
                audio = Array.Find(musicAudio, x => x.name == "CityTheme");
                musicSource.clip = audio.clip;
                musicSource.Play();
                break;
            default:
                audio = Array.Find(musicAudio, x => x.name == "MainTheme");
                musicSource.clip = audio.clip;
                musicSource.Play();
                break;
        }

        if (musicSource.clip != audio.clip)
        {
            audio.enabled = false;
            audio.clip = musicSource.clip;
            audio.enabled = true;
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
    
    public void landAudio()
    {
        Audio audio = Array.Find(sfxAudio, x => x.name == "Land");

        if( audio == null)
        {
            Debug.Log("Audio not found!");
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
