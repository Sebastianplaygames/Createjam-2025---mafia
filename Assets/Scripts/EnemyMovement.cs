using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 1f;
    public bool aggro = false;

    public Vector2 playerLocation;
    // Update is called once per frame
    void Update()
    {
        if (aggro)
        {
            
        }
    }

    public void MoveTo(Vector2 target)
    {
        
    }

    public void stop()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}