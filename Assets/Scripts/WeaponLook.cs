using UnityEngine;

public class WeaponLook : MonoBehaviour
{
    public float offsetY = -0.5f;
    public float minAngle = -40f; 
    public float maxAngle = 70f;  

    private Transform player;

    void Start()
    {
        player = transform.parent;
    }

    void Update()
    {
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3.z = 0;

        Vector2 mousePos = mousePos3;
        Vector2 pivot = (Vector2)transform.position + new Vector2(0, offsetY);

        Vector2 dir = mousePos - pivot;

        bool facingLeft = player.localScale.x < 0;

        if (facingLeft)
            dir.x = -dir.x;
 

        // Local (facing-relative) angle
        float localAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Clamp local angle
        localAngle = Mathf.Clamp(localAngle, minAngle, maxAngle);

        // Convert back into world space
        float finalAngle = facingLeft ? (-localAngle) : localAngle;

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, finalAngle);
    }
}
