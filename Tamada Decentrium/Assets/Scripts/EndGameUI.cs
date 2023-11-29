using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public GameObject endGameCanvas;
    public Button restartButton; // Assign the "Restart" button in the Inspector
    public Button quitButton; // Assign the "Quit" button in the Inspector

    void Start()
    {
        // Initially, hide the end game screen
        endGameCanvas.SetActive(false);

        // Attach click event listeners to the buttons
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void RestartGame()
    {
        // Reload the current scene
        Time.timeScale = 1; // Resume the game
        Debug.Log("Time.timeScale set to: " + Time.timeScale); // Add this line to output the value of Time.timeScale
        PlayerController.ResetPlayerState(); // You might need to implement this method
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {

        SceneManager.LoadScene("Main");
    }
}
