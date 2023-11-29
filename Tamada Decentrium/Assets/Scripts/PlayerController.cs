using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public static Transform PlayerTransform;
    private bool isKnockedBack = false;
    private float knockbackEndTime = 0f;
    public float knockbackDuration = 0.5f; // Duration of knockback effect in seconds
    private float moveX;

    void Awake()
    {
        Debug.Log("PlayerController Awake called");
        PlayerTransform = transform;
        rb = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(-9f, 9f);
        transform.position = new Vector3(randomX, 0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        WrapAroundScreen();
        /*Debug.Log("Input received: " + moveX); // This should log movement input*/
    }

    public void ApplyKnockbackEffect()
    {
        Debug.Log("knockback applied");
        isKnockedBack = true;
        knockbackEndTime = Time.time + knockbackDuration;
    }

    private void FixedUpdate()
    {
        if (isKnockedBack && Time.time > knockbackEndTime)
        {
            isKnockedBack = false;
        }

        Vector2 velocity = rb.velocity;
        float horizontalInput = isKnockedBack ? 0 : moveX; // Disable horizontal input during knockback
        velocity.x = Mathf.Lerp(velocity.x, horizontalInput, 0.5f);

        rb.velocity = velocity;
    }



    public static void ResetPlayerState()
    {
        if (PlayerTransform != null)
        {
            PlayerTransform.position = new Vector3(0f, 0f, PlayerTransform.position.z);
            Rigidbody2D rb = PlayerTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void WrapAroundScreen()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
            bool isWrapped = false;

            if (viewportPosition.x > 1)
            {
                viewportPosition.x = 0;
                isWrapped = true;
            }
            else if (viewportPosition.x < 0)
            {
                viewportPosition.x = 1;
                isWrapped = true;
            }

            if (isWrapped)
            {
                transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
            }
        }
    }

}
