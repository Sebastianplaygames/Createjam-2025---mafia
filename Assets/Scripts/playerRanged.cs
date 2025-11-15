using UnityEngine;

public class PlayerRanged : MonoBehaviour
{
    [Header("References")]
    public Transform firePoint;
    public GameObject projectilePrefab;

    [Header("Settings")]
    public float fireRate = 1f;

    private float nextFireTime = 0f;
    private Transform player;

    private AudioSource gun;

    public WeaponSwitcher switcher;


    private void Start()
    {
        player = transform;
    }

    private void Awake()
    {
        gun = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(1) && Time.time >= nextFireTime)
        {
            switcher.ShowRanged();
            Shoot();
            nextFireTime = Time.time + (1f / fireRate);
        }
    }

    private void Shoot()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;

        Vector2 dir = (mouseWorld - firePoint.position).normalized;

        GameObject bulletObj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile proj = bulletObj.GetComponent<Projectile>();
        proj.direction = dir;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bulletObj.transform.rotation = Quaternion.Euler(0, 0, angle);
        gun.Play(); 

    }
}
