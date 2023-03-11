using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public Image energyBarImage;
    public Player player;
    public void UpdateEnergyBar()
    {
        energyBarImage.fillAmount = Mathf.Clamp(player.energy / player.maxEnergy, 0, 1f);
    }
}