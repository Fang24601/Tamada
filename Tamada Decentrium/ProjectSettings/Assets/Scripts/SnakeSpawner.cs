using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    public GameObject snakePrefab; // Assign the snake prefab in the Inspector
    public float spawnInterval = 2f; // Time in seconds between each spawn
    public float spawnHeightOffset = 1f; // Height above the camera where snakes spawn

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnSnake();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnSnake()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            // Calculate a random position above the camera's viewport
            float randomX = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x,
                                         mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane)).x);
            Vector3 spawnPosition = new Vector3(randomX, mainCamera.transform.position.y + spawnHeightOffset, 0);

            // Instantiate the snake prefab at the calculated position
            Instantiate(snakePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
