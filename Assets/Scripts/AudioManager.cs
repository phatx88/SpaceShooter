using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonPersistent<AudioManager>
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip[] backgroundTracks; // Array to hold multiple background tracks
    public AudioClip laserFire_01;
    public AudioClip laserFire_02;
    public AudioClip flipShip;
    public AudioClip swarmDeath;
    public AudioClip death;
    public AudioClip deathBig;
    public AudioClip mouseClick;
    public AudioClip powerupCollect;


    private void Start()
    {
        PlayRandomBackgroundMusic();
    }

    private void PlayRandomBackgroundMusic()
    {
        if (backgroundTracks.Length > 0)
        {
            int index = Random.Range(0, backgroundTracks.Length);
            musicSource.clip = backgroundTracks[index];
            musicSource.loop = true; // Ensure the music loops
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("No background tracks to play.");
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
