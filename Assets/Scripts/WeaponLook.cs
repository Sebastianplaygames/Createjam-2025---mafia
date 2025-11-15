using UnityEngine;

public class WeaponLook : MonoBehaviour
{
    public float offsetY = -0.5f;
    private Transform player;    

    void Start()
    {
        player = transform.parent; // make sure weapon is child of player
    }

    void Update()
    {
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3.z = 0;

        Vector2 mousePos = mousePos3;
        Vector2 weaponPos = transform.position;
        Vector2 pivotOffset = new Vector2(0, offsetY);

        Vector2 direction = (mousePos - (weaponPos + pivotOffset));

        // Calculate angle normally
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (player.localScale.x < 0)
        {
            angle = -angle;
            angle = 180 - angle;
        } else
        {
            angle = angle;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
