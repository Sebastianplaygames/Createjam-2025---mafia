using UnityEngine;

public class WeaponLook : MonoBehaviour
{

    // Update is called once per frame
     void Update()
    {
        // Get mouse position in world
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Direction from weapon to mouse
        Vector2 direction = mousePos - transform.position;

        // Rotate weapon toward mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
