using DefaultNamespace;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 0.1f; // short-lived melee hitbox
    bool hasHit = false;

    

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;
        IDamagable target = other.GetComponent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(damage);
            hasHit = true;
        }
    }

}