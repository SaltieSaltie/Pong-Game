using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);  //It loads my game which is scene 1 as seen in the build settings of the project.
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
