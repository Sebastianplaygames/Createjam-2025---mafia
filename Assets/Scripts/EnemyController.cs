using System;using DefaultNamespace;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    public bool rangedEnemy;
    public Rigidbody2D rb;
    public EnemyMovement movement;
    public enum EnemyState{Idle, Chase, Attack, Dead}
    public EnemyState currentState = EnemyState.Idle;

    public float aggroRange = 5f;
    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public int health = 1;
    public float leaveAggroMultiplier = 1.2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    public Animator animator;

    public Transform player;
    private IEnemyBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<IEnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", currentState == EnemyState.Idle);
        animator.SetBool("isAttacking", currentState == EnemyState.Attack);
        animator.SetBool("isDead", currentState == EnemyState.Dead);
        if (currentState == EnemyState.Dead)
        {
            return;
        }

        float dist = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (dist < aggroRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                if (rangedEnemy)
                {
                    movement.KeepDistance(player, attackRange);
                }
                else
                {
                    movement.MoveTo(player);
                }
                if (dist < attackRange)
                {
                    currentState = EnemyState.Attack;
                }

                if (dist > aggroRange * leaveAggroMultiplier)
                {
                    currentState = EnemyState.Idle;
                }
                break;
            case EnemyState.Attack:
                movement.stop();
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    Debug.Log("enemy attacking");
                    behavior?.Attack(player);
                    attackTimer = attackCooldown;
                }
                if (dist > attackRange + 0.5f)
                {
                    currentState = EnemyState.Chase;
                }
                break;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        currentState = EnemyState.Dead;
        movement.stop();
    }

    public void DoAttack()
    {
        Debug.Log("enemy attacks");
    }
    
}
