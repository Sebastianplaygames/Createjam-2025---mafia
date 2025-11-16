using UnityEngine;

public class PlayerAmmoUI : MonoBehaviour
{
    public Ammo ammo;          
    public Animator animammo;  

    private int lastAmmo = -1;

    private void Update()
    {
        if (ammo == null)
            return;

        if (ammo.ammo != lastAmmo)
        {
            lastAmmo = ammo.ammo;
            animammo.SetInteger("Ammo", lastAmmo);
        }
    }
}
