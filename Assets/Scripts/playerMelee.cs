using UnityEngine;
using DefaultNamespace;
using System.Collections; 

public class playerMelee : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 1;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private AudioSource Broom;
    public WeaponSwitcher switcher;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextAttackTime)
        {
            switcher.ShowMelee(); 
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    private void Awake()
    {
        Broom = GetComponent<AudioSource>();
    }    void Attack()
{
    StartCoroutine(Swing());
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach (Collider2D enemy in hitEnemies)
    {
        IDamagable damagable = enemy.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
        }
    }
    Broom.Play();
}

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
IEnumerator Swing()
{
    float baseSwingAngle = -110f; // default slash direction

    // Detect facing direction
    float facing = transform.parent.localScale.x;  // assumes weapon is child of player
    float swingAngle = (facing > 0) ? baseSwingAngle : -baseSwingAngle;

    float swingTime = 0.25f;

    Quaternion startRot = transform.rotation;
    Quaternion endRot = startRot * Quaternion.Euler(0, 0, swingAngle);

    float t = 0;
    while (t < swingTime)
    {
        t += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startRot, endRot, t / swingTime);
        yield return null;
    }

    transform.rotation = startRot;
Debug.Log("Current Rotation: " + transform.rotation.eulerAngles);
}


}
