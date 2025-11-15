using System;
using DefaultNamespace;
using UnityEngine;

public class rangedEnemyBehaviour : MonoBehaviour, IEnemyBehavior
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;
    
    [Header("Gun Sprite")] public Transform gunTransform;
    [Header("Aiming")] public Transform target;

    private void Update()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {
        if(target == null || shootPoint == null) return;

        Vector2 dir = (target.position - shootPoint.position).normalized;

        if (gunTransform != null)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Attack(Transform player)
    {
        if(projectilePrefab == null || shootPoint == null) return;
        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        
        //calculates direction toward player at moment of shooting
        Vector2 dir = (player.position - shootPoint.position).normalized;

        Projectile p = proj.GetComponent<Projectile>();
        p.direction = dir;
        p.speed = projectileSpeed;
    }
}
