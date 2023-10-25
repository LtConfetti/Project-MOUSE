using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCAPE : MonoBehaviour
{//getting function from playermover for boolean to check for mOUSEMODE (mOUSEMODE false = getting cheese, true = no cheese)
    [SerializeField] private MOUSEMOVERR mouseMode;

    //checks for player with mOUSEMODE false (mOUSEMODE false = getting cheese) and if they have it false, it loads the victory scene.
    //made by me
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && mouseMode.mOUSEMODE == false)
        {
            SceneManager.LoadScene("You Win");
        }
    }
}
