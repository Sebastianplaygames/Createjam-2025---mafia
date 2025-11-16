using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerController player;    
    public Image hpImage;              // The UI image on the Canvas
    public Sprite[] hpSprites;         // 5 sprites (0–4)

    private int lastHP;

    private void Start()
    {
        lastHP = player.health;
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
        int hp = Mathf.Clamp(player.health, 0, hpSprites.Length - 1);

        hpImage.sprite = hpSprites[hp];
    }
}
