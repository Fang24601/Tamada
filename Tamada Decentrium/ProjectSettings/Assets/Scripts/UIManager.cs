using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGameCanvas;
    public GameObject gameCanvas;
    public TextMeshProUGUI inGameScoreText; // For displaying score during the game
    public TextMeshProUGUI endGameScoreText; // For displaying score on the end game screen
    public int score;

    public void UpdateScoreDisplay(int newScore)
    {
        if (inGameScoreText != null && endGameScoreText.text != null)
        {
            score = newScore; 
            inGameScoreText.text = "Score: " + newScore;
            endGameScoreText.text = "Score: " + newScore;
        }
    }

    // Call this method to show the end game canvas
    public void ShowEndGameUI()
    {
        Time.timeScale = 0; // Pause game time
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(true);

        User mUser = DatabaseManager.instance.getCurrUser();
        mUser.numCoins += score;
        DatabaseManager.instance.UpdateUser(mUser);

        // Update Pet Scores
        PetManager.instance.needs.ChangeHappiness(30);
        PetManager.instance.needs.ChangeLove(30);
        PetManager.instance.needs.ChangeStatus(30);
        PetManager.instance.needs.ChangeGold(30);
        PetManager.instance.needs.ChangeClean(30);
        PetManager.instance.needs.ChangePower(30);
        PetManager.instance.petData.SetNeeds(PetManager.instance.needs);
        DatabaseManager.instance.UpdateActivePet(PetManager.instance.petData);
    }

    // Call this method to hide the end game canvas
    public void HideEndGameUI()
    {
        if (endGameCanvas != null)
        {
            gameCanvas.SetActive(true);
            endGameCanvas.SetActive(false);
        }
    }

    // Add methods to update other UI elements as needed
    // Example: UpdateScore, ShowPauseMenu, HidePauseMenu, etc.

    // Optionally, if your game has a start menu or similar, you can add methods to handle those as well
}
