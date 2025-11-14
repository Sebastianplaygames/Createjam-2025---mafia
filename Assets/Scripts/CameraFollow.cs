using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Targets")]
    public Transform player;
    public Rigidbody2D playerrigidbody;

    [Header("Camera Settings")]
    public float smoothSpeed = 10f;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Look Ahead")]
    public float movementLookAhead = 2f;
    public float aimLookAhead = 3f;
    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;

        // Movement look-ahead (like option 2)
        Vector3 moveOffset = (Vector3)playerrigidbody.linearVelocity.normalized * movementLookAhead;

        // Aim look-ahead (toward mouse)
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mouseWorldPos - player.position).normalized;
        Vector3 aimOffset = aimDir * aimLookAhead;

        // Final camera position
        Vector3 desiredPosition = player.position + moveOffset + aimOffset + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
