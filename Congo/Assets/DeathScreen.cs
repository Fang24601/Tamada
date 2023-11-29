using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public void Setup(int score) 
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        instance = this;
    }

    //This function is used for the Play button, it loads the Snake scene.
    public void PlayGame()
    {
        SceneManager.LoadScene("Snake");
    }

    //This function is used for the Exit button, it loads the MainMenu scene
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
