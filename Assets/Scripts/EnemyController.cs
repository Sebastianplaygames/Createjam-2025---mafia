using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public enum EnemyState{Idle, Chase, Attack, Dead}
    public EnemyState currentState;
    
    public float moveSpeed = 1f;
    public float aggroRange = 5f;
    public int health = 1;
    public bool aggro = false;
    public Vector2 playerLocation;
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            
        }
    }

    private void FixedUpdate()
    {
        
    }
}
