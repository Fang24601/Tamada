using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This function is used for the Play button, it loads the Snake scene.
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Snake");
    }

    //This function is used for the Exit button, it
    public void ExitGame()
    {
        Application.Quit();
    }
}
