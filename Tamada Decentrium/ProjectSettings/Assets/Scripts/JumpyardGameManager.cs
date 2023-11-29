using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpyardGameManager : MonoBehaviour
{
    private UIManager uiManager;
    public GameObject endGameCanvas;
    public GameObject gameCanvas;
    private bool isGameOver = false;
    private float restartDelay = 1f; // Time in seconds before the game can be restarted
    private float lastRestartTime;
    private float highestYPosition; // Declare at class level
    private int score;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        highestYPosition = PlayerController.PlayerTransform.position.y; // Assuming PlayerController has a static reference to the player's transform
    }

    private void UpdateScoreBasedOnHeight()
    {
        float currentPlayerY = PlayerController.PlayerTransform.position.y;
        if (currentPlayerY > highestYPosition)
        {
            highestYPosition = currentPlayerY;
            score = Mathf.FloorToInt(highestYPosition); // Or any other formula you wish to use
            uiManager.UpdateScoreDisplay(score);
        }
    }

    void Update()
    {
        UpdateScoreBasedOnHeight();
        // Skip updates if within the restart delay period
        if (Time.time < lastRestartTime + restartDelay) return;

        // Game over condition check
        CheckGameOverCondition();
    }

    public void RestartGame()
    {
        lastRestartTime = Time.time;
        isGameOver = false;
        Time.timeScale = 1; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CheckGameOverCondition()
    {
        float cameraBottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;
        float gameOverBuffer = 2.0f; // Buffer distance below camera's edge for game over

        if (PlayerController.PlayerTransform.position.y < cameraBottomEdge - gameOverBuffer)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (isGameOver) return; // Prevent multiple calls to GameOver
        isGameOver = true;
        uiManager.ShowEndGameUI();
    }
}
