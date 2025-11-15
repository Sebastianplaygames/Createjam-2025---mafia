using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(target != null)
        {
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
        else if (dist > desiredRange * 1.2f)
        {
            MoveTo(target);
        }
        else
        {
            stop();
        }
    }
}