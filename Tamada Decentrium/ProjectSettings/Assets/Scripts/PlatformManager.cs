using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform playerTransform;
    private Camera mainCamera;
    private float lastSpawnedPlatformY;
    private List<float> recentXPositions = new List<float>();
    private int maxRecentPositions = 5; // Maximum number of recent X positions to consider

    void Start()
    {
        mainCamera = Camera.main;
        Vector3 firstPlatformPosition = new Vector3(playerTransform.position.x, playerTransform.position.y - 2f, 0f);
        SpawnPlatform(firstPlatformPosition);
        lastSpawnedPlatformY = firstPlatformPosition.y;
        recentXPositions.Add(firstPlatformPosition.x);
    }

    void Update()
    {
        if (ShouldSpawnNewPlatform())
        {
            SpawnNewPlatform();
        }
    }

    private bool ShouldSpawnNewPlatform()
    {
        float topOfCamera = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        return lastSpawnedPlatformY < topOfCamera;
    }

    private void SpawnNewPlatform()
    {
        float verticalOffset = Random.Range(0.5f, 2f);
        float newX;

        do
        {
            newX = Random.Range(-9f, 9f); // Adjusting the X position to be between -9 and 9
        } while (IsTooCloseToRecentX(newX));

        Vector3 newPlatformPosition = new Vector3(newX, lastSpawnedPlatformY + verticalOffset, 0f);
        SpawnPlatform(newPlatformPosition);

        lastSpawnedPlatformY = newPlatformPosition.y; // Update the Y position of the last spawned platform
        recentXPositions.Add(newX);
        if (recentXPositions.Count > maxRecentPositions)
        {
            recentXPositions.RemoveAt(0); // Remove the oldest entry
        }
    }


    private bool IsTooCloseToRecentX(float newX)
    {
        foreach (float x in recentXPositions)
        {
            if (Mathf.Abs(x - newX) < 2f) // Check if newX is too close to a recent X position
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnPlatform(Vector3 position)
    {
        Instantiate(platformPrefab, position, Quaternion.identity);
    }
}
