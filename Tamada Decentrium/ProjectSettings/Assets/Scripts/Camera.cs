using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float upwardOffset = 1f; // Additional height player needs to reach before camera starts moving up

    private void LateUpdate()
    {
        // Check if the player's y position is greater than the camera's y position plus the offset
        if (target.position.y > transform.position.y + upwardOffset)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y - upwardOffset, transform.position.z);
            transform.position = newPosition;
        }
    }
}
