using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
  
    void Update()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float cameraBottomEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y;
            if (transform.position.y < cameraBottomEdge)
            {
                Debug.Log("Destroying platform at: " + transform.position);
                Destroy(gameObject);
            }
        }
    }
}

