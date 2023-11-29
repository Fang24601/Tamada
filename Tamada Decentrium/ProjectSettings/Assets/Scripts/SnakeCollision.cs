using UnityEngine;
using System.Collections;

public class SnakeCollision : MonoBehaviour
{
    public float topBounceForce = 10f; // Force applied when hitting the top
    public float bottomBounceForce = 5f; // Reduced force for bottom collisions
    public float sideBounceForce = 15f; // Force applied when hitting the sides
    public float collisionCooldown = 0.5f;

    private BoxCollider2D boxCollider;
    private float lastCollisionTime = -1;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private IEnumerator DespawnRoutine()
    {
        float duration = 6.0f; // Duration of the despawn animation
        float elapsed = 0;

        // Disable the collider so the snake can't be hit again
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Find and temporarily disable the SnakeMovement script
        SnakeMovement snakeMovementScript = GetComponent<SnakeMovement>();
        if (snakeMovementScript != null)
        {
            snakeMovementScript.enabled = false;
        }

        // Freeze the snake's position on the x and y axes
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        // Define the initial scale and target scale
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.zero; // Shrink to nearly invisible

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            // Calculate the current scale based on the elapsed time
            float scaleProgress = elapsed / duration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleProgress);

            // Calculate the rotation angle based on the elapsed time (720 degrees for 6 seconds)
            float rotationAngle = (720.0f / duration) * Time.deltaTime;

            // Rotate the snake around its center point (no movement on x and y axes)
            transform.Rotate(Vector3.forward * rotationAngle);

            yield return null;
        }

        // Re-enable the SnakeMovement script
        if (snakeMovementScript != null)
        {
            snakeMovementScript.enabled = true;
        }

        // Deactivate or destroy the snake object
        gameObject.SetActive(false);
        Destroy(gameObject); // Uncomment if you want to destroy the object instead
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("SnakeTail"))
        {
            // Handle bounce up when player collides with the snake's tail
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(Vector2.up * topBounceForce, ForceMode2D.Impulse);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - lastCollisionTime < collisionCooldown)
        {
            Debug.Log("Collision ignored due to cooldown.");
            return; // Cooldown check
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerRb != null && playerController != null)
            {
                Vector2 contactPoint = collision.contacts[0].point;
                Bounds bounds = boxCollider.bounds;

                bool isTopCollision = contactPoint.y > bounds.center.y && Mathf.Abs(contactPoint.y - bounds.max.y) < 0.1f;
                bool isBottomCollision = contactPoint.y < bounds.center.y && Mathf.Abs(contactPoint.y - bounds.min.y) < 0.1f;

                if (isTopCollision)
                {
                    Vector2 force = Vector2.up * bottomBounceForce;
                    Debug.Log($"Collision with top detected. Applying force: {force}");
                    playerRb.AddForce(force, ForceMode2D.Impulse);
                }
                else if (isBottomCollision)
                {
                    Vector2 force = Vector2.down * bottomBounceForce;
                    Debug.Log($"Collision with bottom detected. Applying force: {force}");
                    playerRb.AddForce(force, ForceMode2D.Impulse);
                }
                else // Side collision
                {
                    // Adjusted side bounce for more horizontal movement
                    Vector2 directionToPlayer = (collision.transform.position - transform.position).normalized;
                    float horizontalComponent = directionToPlayer.x;
                    float verticalComponent = 0.05f; // Reduced vertical component

                    Vector2 sideBounceDirection = new Vector2(horizontalComponent, verticalComponent).normalized;
                    Vector2 force = sideBounceDirection * sideBounceForce;
                    Debug.Log($"Side collision detected. Applying force: {force}");
                    playerRb.AddForce(force, ForceMode2D.Impulse);

                    // Apply knockback effect
                    playerController.ApplyKnockbackEffect();
                }

                lastCollisionTime = Time.time;
                StartCoroutine(DespawnRoutine());
            }
        }
    }
}
