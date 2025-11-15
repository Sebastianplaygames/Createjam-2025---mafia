using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Targets")]
    public Transform player;
    public Rigidbody2D playerrigidbody;

    [Header("Camera Settings")]
    public float smoothTime = 0.2f; // Smooth time instead of speed
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Look Ahead")]
    public float movementLookAhead = 2f;
    public float aimLookAhead = 3f;

    private Vector3 velocity = Vector3.zero; // for SmoothDamp

    void LateUpdate()
    {
        if (player == null) return;

        // Movement look-ahead, scaled by actual speed
        Vector3 moveOffset = (Vector3)playerrigidbody.linearVelocity * 0.1f * movementLookAhead;

        // Aim look-ahead (toward mouse)
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mouseWorldPos - player.position);
        aimDir.z = 0; // Ignore z-axis
        Vector3 aimOffset = aimDir.normalized * aimLookAhead;

        // Combine offsets
        Vector3 targetPosition = player.position + moveOffset + aimOffset + offset;

        // Smooth camera movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}