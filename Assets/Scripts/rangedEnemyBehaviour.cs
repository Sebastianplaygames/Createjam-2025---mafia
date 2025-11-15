using DefaultNamespace;
using UnityEngine;

public class rangedEnemyBehaviour : MonoBehaviour, IEnemyBehavior
{
    public GameObject projectilePrefab;

    public Transform shootPoint;

    public float projectileSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Attack(Transform player)
    {
        if(projectilePrefab == null || shootPoint == null) return;
        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Vector2 dir = (player.position - shootPoint.position).normalized;

        Projectile p = proj.GetComponent<Projectile>();
        p.direction = dir;
        p.speed = projectileSpeed;
    }
}
