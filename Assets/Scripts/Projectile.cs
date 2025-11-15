using System;
using DefaultNamespace;
using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        public int damage = 1;
        public float speed = 10f;
        public float lifeTime = 3f;
        public Vector2 direction;

        [Header("Visuals")] public float spin = 360f;
        [SerializeField]public Transform spriteTransform;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);

            if (spriteTransform != null)
            {
                spriteTransform.Rotate(Vector3.forward, spin * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamagable dmg = other.GetComponent<IDamagable>();
            if (dmg != null)
            {
                dmg.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }