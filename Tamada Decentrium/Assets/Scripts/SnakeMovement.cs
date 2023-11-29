using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2f; // Speed at which the snake moves down

    void Update()
    {
        // Move the snake down
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the snake is below the camera view
        if (Camera.main != null && transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y)
        {
            Destroy(gameObject); // Destroy the snake
        }
    }
}


