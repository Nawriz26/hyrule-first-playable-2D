using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI gemText;
    public PlayerHealth player;

    void Update()
    {
        if (player != null)
        {
            hpText.text = "HP: " + player.CurrentHP + "/" + player.maxHP;
            gemText.text = "Gems: " + Gem.Count;
        }
    }
}
