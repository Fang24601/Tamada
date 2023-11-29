using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameUIController : MonoBehaviour
{

    private void Start()
    {
        
    }

    public void LoadCongo()
    {
        SceneManager.LoadScene("Congo");
    }

    public void LoadSalon()
    {
        SceneManager.LoadScene("Salon");
    }

    public void LoadJump()
    {
        SceneManager.LoadScene("Jump");
    }
}
