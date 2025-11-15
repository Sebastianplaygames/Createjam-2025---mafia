using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject meleeWeapon;
    public GameObject rangedWeapon;

    void start()
    {
        ShowMelee();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) 
            ShowMelee();

        if (Input.GetMouseButton(1))
            ShowRanged();
    }
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
