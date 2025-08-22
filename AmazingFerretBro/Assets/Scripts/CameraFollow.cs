using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player to follow
    public Vector3 offset = new Vector3(-2, 0, -5); // Camera offset
    public float smoothTime = 0.25f; // Smoothing time (smaller = tighter follow)

    private Vector3 velocity = Vector3.zero; // Used internally by SmoothDamp

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired camera position
            Vector3 targetPosition = player.position + offset;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
