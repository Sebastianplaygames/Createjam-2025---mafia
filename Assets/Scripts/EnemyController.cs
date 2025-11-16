using System;using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

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
    public float leaveAggroMultiplier = 1000000f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;
    public ParticleSystem deathParticle;
    public AudioSource AttackClip;

    
    //boss things
    public bool MouseFather;
    public bool Scargaroo;
    public bool useBurstFiring = false;
    public float burstDuration = 2f;
    public float burstCooldown = 4f;
    private float burstTimer = 0f;
    private bool inBurstCooldown = false;
    private bool canShoot = true; 
    public ParticleSystem muzzleFlash;

    public Animator animator;

    public Transform player;
    private IEnemyBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<IEnemyBehavior>();

        if (MouseFather)
        {
            useBurstFiring = true;
            burstDuration = 4.5f; // minigun madness
            burstCooldown = 5f;
            attackCooldown = 0.1f; // even faster
        }
        else if (Scargaroo)
        {
            useBurstFiring = true;
            burstDuration = 2.5f;  // tommy gun
            burstCooldown = 4f;
            attackCooldown = 0.2f; // shoot fast
        }
    }
    
    private void HandleBurstFiring()
    {
        if (!useBurstFiring) return; // normal enemies skip this entirely

        if (inBurstCooldown)
        {
            burstTimer -= Time.deltaTime;
            if (burstTimer <= 0f)
            {
                inBurstCooldown = false;
                canShoot = true;              // boss may shoot again
                burstTimer = burstDuration;   // reset burst time
            }
            return;
        }

        // currently in burst
        burstTimer -= Time.deltaTime;
        if (burstTimer <= 0f)
        {
            inBurstCooldown = true;
            canShoot = false;          // STOP shooting
            burstTimer = burstCooldown;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleBurstFiring();
        animator.SetBool("isMoving", currentState == EnemyState.Chase);
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
                movement.stop();
                targetNothing();
                if (dist < aggroRange)
                {
                    currentState = EnemyState.Chase;
                    targetPlayer();
                }
                break;
            case EnemyState.Chase:
                movement.faceTarget(player);
                if (rangedEnemy)
                {
                    movement.KeepDistance(player, attackRange);
                }
                else
                {
                    movement.MoveTo(player);
                }
                //enter attack
                if (dist < attackRange * 1.5f)
                {
                    movement.stop();
                    currentState = EnemyState.Attack;
                    targetPlayer();
                }break;
                //leave aggro disabled because it was buggy, now enemies eternally chase you
                /*
                if (dist > aggroRange * leaveAggroMultiplier)
                {
                    currentState = EnemyState.Idle;
                    targetNothing();
                }
                break;*/
            case EnemyState.Attack:
                movement.faceTarget(player);
                movement.stop();
                attackTimer -= Time.deltaTime;
                if (canShoot && attackTimer <= 0f)
                {
                    if (muzzleFlash != null)
                    {
                        muzzleFlash.Play();
                    }
                    AttackClip.Play();
                    Debug.Log("enemy attacking");
                    behavior?.Attack(player);
                    attackTimer = attackCooldown;
                }
                //chase after him!
                if (dist > attackRange * 1.6f)
                {
                    currentState = EnemyState.Chase;
                    targetPlayer();
                }
                break;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (deathParticle != null)
        {
            ParticleSystem blood = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(blood.gameObject, blood.main.duration + blood.main.startLifetime.constantMax);
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        currentState = EnemyState.Dead;
        movement.stop();
        Destroy(gameObject, 0.1f); // small delay so particle spawns first
    }

    public void targetPlayer()
    {
        if (behavior is rangedEnemyBehaviour ranged)
        {
            ranged.PointGunAt(player);
        }
    }

    public void targetNothing()
    {
        if (behavior is rangedEnemyBehaviour ranged)
        {
            ranged.clearTarget();
        }
    }
    
    
    
}
