using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    public Transform gunPivot;
    public SpriteRenderer body;
    private float lastX;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (agent.isStopped ) return;
        
        if(target != null)
        {
            float dx = target.position.x - transform.position.x;
            if (Mathf.Abs(dx) > 0.01f)
            {
                setFacing(dx > 0 ? 1 : -1);
            }

            // Only move if needed
            agent.SetDestination(target.position);
        }
    }

    public void MoveTo(Transform target)
    {
        this.target = target;
        agent.isStopped = false;
    }

    public void MoveTo(Vector2 worldPosition)
    {
        target = null;
        agent.isStopped = false;
        agent.SetDestination(worldPosition);
    }
    public void stop()
    {
        target = null;
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void KeepDistance(Transform target, float desiredRange)
    {
        float dist = Vector2.Distance(transform.position, target.position);

        if (dist < desiredRange * 0.8f)
        {
            //Move backward
            Vector2 dir = (transform.position - target.position).normalized;
            Vector2 newPos = (Vector2)transform.position + dir * 2f;
            MoveTo(newPos);
        }
        else if (dist * 1.2f > desiredRange)
        {
            MoveTo(target);
        }
        else
        {
            stop();
        }
    }

    public void setFacing(int dir)
    {
        if (gunPivot != null)
        {
            Vector3 gunScale = gunPivot.localScale;
            gunScale.x = Mathf.Abs(gunScale.x) * dir;
            gunPivot.localScale = gunScale;
        }

        if (body != null)
        {
            body.flipX = (dir > 0);
        }

        lastX = dir;
    }

    public void faceTarget(Transform target)
    {
        if (target == null) return;
        float dx = target.position.x - transform.position.x;
        if (MathF.Abs(dx)> 0.01f)
        {
            setFacing(dx > 0 ? 1 : -1);
        }
    }

    public void faceMovement()
    {
        if (MathF.Abs(agent.velocity.x) > 0.01f)
        {
            setFacing(agent.velocity.x > 0 ? 1 : -1);
        }
    }
    
}