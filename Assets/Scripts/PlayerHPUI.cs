using UnityEngine;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerController player; 
    public Animator animhealth;     

    private int lastHP;

    private void Start()
    {
        lastHP = -1;  // force first update
        UpdateHPUI();
    }

    private void Update()
    {
        if (player.health != lastHP)
        {
            lastHP = player.health;
            UpdateHPUI();
        }
    }

    private void UpdateHPUI()
    {
        animhealth.SetInteger("HP", player.health);
    }
}
