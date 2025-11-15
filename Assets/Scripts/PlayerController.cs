using UnityEngine;
using DefaultNamespace;

public class PlayerController : MonoBehaviour, IDamagable
{
    public Rigidbody2D playerRigidbody;
    public float moveSpeed = 5f;
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float directionalResponsiveness =100f;
    public int health = 10;

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

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle player death (e.g., play animation, restart level, etc.)
        Debug.Log("Player has died.");
    }
}
