using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject meleeWeapon;
    public GameObject rangedWeapon;

    public void ShowMelee()
    {
        meleeWeapon.SetActive(true);
        rangedWeapon.SetActive(false);
    }

    public void ShowRanged()
    {
        meleeWeapon.SetActive(false);
        rangedWeapon.SetActive(true);
    }
}
