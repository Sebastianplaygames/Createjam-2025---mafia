using DefaultNamespace;
using UnityEngine;

public class meleeEnemyBehavior : MonoBehaviour, IEnemyBehavior
{
    public int damage = 1;
    public float hitRange = 1f;
    public void Attack(Transform player)
    {
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist <= hitRange)
        {
            IDamagable dmg = player.GetComponent<IDamagable>();
            dmg?.TakeDamage(damage);
        }
    }
}
