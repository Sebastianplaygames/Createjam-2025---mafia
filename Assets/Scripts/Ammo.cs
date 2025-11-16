using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public int maxAmmo = 7;
    public int ammo = 7;

    public float reloadTime = 1.2f;  // how long reload takes
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

    public IEnumerator AutoReload()
    {
        isReloading = true;

        // wait for reload
        yield return new WaitForSeconds(reloadTime);

        ammo = maxAmmo;
        isReloading = false;
    }
}
