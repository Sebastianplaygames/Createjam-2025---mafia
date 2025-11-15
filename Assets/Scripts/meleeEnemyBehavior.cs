using DefaultNamespace;
using UnityEngine;

public class meleeEnemyBehavior : MonoBehaviour, IEnemyBehavior
{
    public int damage = 1;
    public float attackRange = 1f;
    [SerializeField]public GameObject hitboxPrefab; // assign Hitbox prefab here

    public void Attack(Transform player)
    {
        if (hitboxPrefab == null || player == null) 
            return;

        // Direction toward player
        Vector2 dir = (player.position - transform.position).normalized;
        
        // Spawn slightly in front of enemy
        Vector2 spawnPos = (Vector2)transform.position + dir * (attackRange * 0.6f);
        
        // Create hitbox
        GameObject hb = Instantiate(hitboxPrefab, spawnPos, Quaternion.identity);

        Hitbox h = hb.GetComponent<Hitbox>();
        h.damage = damage;

        // Aim the hitbox toward the player (for slashes, etc.)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        hb.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}