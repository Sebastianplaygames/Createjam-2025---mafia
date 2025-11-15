using UnityEngine;

public class WeaponLook : MonoBehaviour
{
    public float offsetY = -0.5f; // how far down to shift the rotation origin
    public float rightMin = -60f;
    public float rightMax = 60f;

    public float leftMin = 120f;
    public float leftMax = 240f;
    public bool facingRight = true;
    public float spriteAngleOffset = -180f;
    void Update()
    {
        // get mouse position
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3.z = 0;

        Vector2 pivot = (Vector2)transform.position + new Vector2(0, offsetY);
        Vector2 direction = (mousePos3 - (Vector3)pivot);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += spriteAngleOffset;


        if (facingRight)
        {
            angle = Mathf.Clamp(angle, rightMin, rightMax);
        }
        else
        {
            angle = Mathf.Clamp(angle, leftMin, leftMax);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // call this from player movement
    public void SetFacing(bool isRight)
    {
        facingRight = isRight;
    }
}
