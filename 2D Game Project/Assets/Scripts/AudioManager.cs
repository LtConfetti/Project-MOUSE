using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip jumpClip;
    public AudioClip footstepSound;
    public AudioClip backgroundMusic;
    public AudioClip peteCalling;
    public AudioClip mainMenu;

    private AudioSource soundEffectsSource;//what plays the sound
    private AudioSource backgroundMusicSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)//makes sure this is the only audio manager/first, if it tries to run again it will check if there is another and destroy this one
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundEffectsSource = gameObject.AddComponent<AudioSource>();//constructors
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayJumpSound()
    {
        soundEffectsSource.PlayOneShot(jumpClip);
    }
   
    public void PlayFootstepSound()
    {
        soundEffectsSource.PlayOneShot(footstepSound);
    }

    public void PeteShout()
    {
        soundEffectsSource.PlayOneShot(peteCalling);
    }

    public void PetePhone();
    {
        soundEffectsSource.PlayOneShot(mainMenu);
    }


    public void PlayBackgroundMusic()
    {
        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }
    public void PauseBackgroundMusic()
    {
        backgroundMusicSource.Pause();
    }
    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }
}
