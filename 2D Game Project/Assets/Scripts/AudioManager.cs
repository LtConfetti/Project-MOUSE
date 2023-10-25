using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//from Lecturer's code, modified
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    //sounds as variables
    public AudioClip jumpClip;
    public AudioClip backgroundMusic;
    public AudioClip deathSound;

    private AudioSource soundEffectsSource;
    private AudioSource backgroundMusicSource;
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //checks if there is another version in the code, and destorys that one
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
    //sets scripts for use in other scripts 
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
}
