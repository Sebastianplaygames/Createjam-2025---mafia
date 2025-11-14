using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float moveSpeed = 5f;
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float directionalResponsiveness =100f;

    private Vector2 input;
    private Vector2 desiredVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     input = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
     ).normalized;

    desiredVelocity = input * moveSpeed;
    }


    private void FixedUpdate()
    {
        Vector2 velocity = playerRigidbody.linearVelocity;

        // if player is moving
        if(input.magnitude > 0.1f)
        {
            velocity = Vector2.MoveTowards(
                velocity,
                desiredVelocity,
                acceleration * Time.fixedDeltaTime
                );
        }
        else
        {
            // Decelerate to a stop
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }
    playerRigidbody.linearVelocity = velocity;

    }
}
