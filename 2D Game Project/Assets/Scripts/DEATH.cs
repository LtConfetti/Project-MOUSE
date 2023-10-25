using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//obtained from https://www.youtube.com/watch?v=ynH51MiKutY&pp=ygUQdW5pdHkgZGVhdGggY29kZQ%3D%3D
public class DEATH : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioPlayer;

    private void Start()
    {
        //referencing components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //in this case it checks if it has a "hazard" tag and activates the Die method
        if (collision.gameObject.tag == "Hazard")
        {
            Die();
        }
    }
    
    //freezes player and triggers the death animation, and noise
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        AudioManager.instance.PlayDeathSound();
    }

    //resets the current scene
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
