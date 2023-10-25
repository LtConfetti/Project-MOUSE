using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip jumpClip;
    public AudioClip backgroundMusic;
    public AudioClip deathSound;

    private AudioSource soundEffectsSource;
    private AudioSource backgroundMusicSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundEffectsSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayJumpSound()
    {
        soundEffectsSource.PlayOneShot(jumpClip);
    }

    public void PlayDeathSound()
    {
        soundEffectsSource.PlayOneShot(deathSound);
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
