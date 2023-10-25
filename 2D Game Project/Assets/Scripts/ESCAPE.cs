using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCAPE : MonoBehaviour
{
    [SerializeField] private MOUSEMOVERR mouseMode;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && mouseMode.mOUSEMODE == false)
        {
            SceneManager.LoadScene("You Win");
        }
    }
}
