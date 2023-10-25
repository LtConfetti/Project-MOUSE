using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//fucntions used to connect to buttons when on click, load levels
//modified lectur's code
public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level");
    }
    //ends the game
    public void quitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
