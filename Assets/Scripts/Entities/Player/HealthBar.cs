using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Player player;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.health / 100, 0, 1f);
    }
}