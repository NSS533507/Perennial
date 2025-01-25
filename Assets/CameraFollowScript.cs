using System.Collections;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    // Camera follow speed
    public float followSpeed = 2f;
    public float yOffset = 1f;

    // Target for the camera to follow
    public Transform target;

    // Camera bounds (optional, adjust to fit your game area)
    public float minX, maxX; // Horizontal bounds (Left/Right)
    public float minY, maxY; // Vertical bounds (Top/Bottom)

    // Update is called once per frame
    void Update()
    {
        // Calculate the new camera position with the Y offset but follow only the X position
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        // Apply smoothing to the camera's movement
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

        // Keep the camera within the defined horizontal bounds (minX and maxX)
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);

        // Update the camera's position with clamped X value
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
