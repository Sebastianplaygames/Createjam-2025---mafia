using UnityEngine;

public class WeaponLook : MonoBehaviour
{
    public float offsetY = -0.5f; // how far down to shift the rotation origin

    void Update()
    {
        // Get mouse position in world (Vector3)
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3.z = 0;

        // Convert to Vector2
        Vector2 mousePos = mousePos3;
        Vector2 weaponPos = transform.position;

        // Add downward offset
        Vector2 pivotOffset = new Vector2(0, offsetY);

        // Direction with offset applied
        Vector2 direction = (mousePos - (weaponPos + pivotOffset));

        // Rotate toward mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
