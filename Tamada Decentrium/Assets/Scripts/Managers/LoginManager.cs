using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public static LoginManager instance;

    
    public TMP_InputField usernameTextLogin;
    public TMP_InputField passwordTextLogin;
    public TMP_Text errorTextLogin;

    public TMP_InputField usernameTextCreate;
    public TMP_InputField passwordTextCreate;
    public TMP_Text errorTextCreate;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one DatabaseManager in the Scene");
        }
    }

    public void CreateAccount()
    {
        if (DatabaseManager.instance.Create(this.usernameTextCreate.text, this.passwordTextCreate.text))
        {
            this.errorTextCreate.text = "Successfully Created Account!";
        }
        else
        {
            this.errorTextCreate.text = "Username Already Exists or can't have empty password!";
        }
    }
    public void Login()
    {
        if(DatabaseManager.instance.Login(this.usernameTextLogin.text, this.passwordTextLogin.text))
        {
            this.DetermineScene();
        }
        else
        {
            this.errorTextLogin.text = "No Account Found";
        }
    }

    public void DetermineScene()
    {
        if(DatabaseManager.instance.GetUserActivePet() == null)
        {
            SceneManager.LoadScene("Select Tamada");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}
