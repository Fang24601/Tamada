using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public Text earningsText;
    public void Setup(int score) 
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        instance = this;
        earningsText.text = "Your score was " + DatabaseManager.instance.score.ToString();
        int coinsEarned = DatabaseManager.instance.score * 3;
        DatabaseManager.instance.score = 0;

        // Update coins
        User mUser = DatabaseManager.instance.getCurrUser();
        mUser.numCoins += coinsEarned;
        DatabaseManager.instance.UpdateUser(mUser);

        // Update Pet Scores
        PetManager.instance.needs.ChangeHappiness(30);
        PetManager.instance.needs.ChangeLove     (30);
        PetManager.instance.needs.ChangeStatus   (30);
        PetManager.instance.needs.ChangeGold     (30);
        PetManager.instance.needs.ChangeClean    (30);
        PetManager.instance.needs.ChangePower    (30);
        PetManager.instance.petData.SetNeeds(PetManager.instance.needs);
        DatabaseManager.instance.UpdateActivePet(PetManager.instance.petData);
    }

    //This function is used for the Play button, it loads the Snake scene.
    public void PlayGame()
    {
        SceneManager.LoadScene("Snake");
    }

    //This function is used for the Exit button, it loads the MainMenu scene
    public void ExitGame()
    {
        
        SceneManager.LoadScene("Main");
    }
}
