using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioControler : SingletonPersistent<AudioControler>
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        PlayRandomBackgroundMusic();
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    private void PlayRandomBackgroundMusic()
    {
        if (musicSounds.Length > 0)
        {
            int index = UnityEngine.Random.Range(0, musicSounds.Length);
            musicSource.clip = musicSounds[index].clip;
            musicSource.loop = true; // Ensure the music loops
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("No background tracks to play.");
        }
    }
}