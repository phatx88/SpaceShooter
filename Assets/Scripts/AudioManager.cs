using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonPersistent<AudioManager>
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip laserFire_01;
    public AudioClip laserFire_02;
    public AudioClip flipShip;
    public AudioClip moveShip;
    public AudioClip death;
    public AudioClip mouseClick;

    // Static variable to hold the instance of the AudioManager
    //private static AudioManager instance = null;

    //private void Awake()
    //{
    //    // Check if instance already exists
    //    if (instance == null)
    //    {
    //        // If not, set instance to this
    //        instance = this;
    //        // Make this active and only instance
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else if (instance != this)
    //    {
    //        // If instance already exists and it's not this, then destroy this to enforce the singleton pattern
    //        Destroy(gameObject);
    //    }
    //}

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
