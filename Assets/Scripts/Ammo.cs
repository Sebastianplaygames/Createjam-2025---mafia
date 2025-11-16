using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public int maxAmmo = 7;
    public int ammo = 7;
    // how long reload takes
    public bool isReloading = false;

    public bool HasAmmo()
    {
        return ammo > 0;
    }

    public void Shoot()
    {
        if (ammo > 0)
            ammo--;
    }

    public void AutoReload()
    {
        print("I am realoding");
        ammo = maxAmmo;
        print(ammo);
    }
}
