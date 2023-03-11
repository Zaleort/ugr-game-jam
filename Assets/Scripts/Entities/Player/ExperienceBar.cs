using UnityEngine;
using UnityEngine.UI;
public class ExperienceBar : MonoBehaviour
{
    public Image experienceBarImage;
    public Player player;
    public void UpdateExperienceBar()
    {
        experienceBarImage.fillAmount = Mathf.Clamp((float)player.experience / (float)Player.EXP_TO_LEVEL_UP, 0, 1f);
    }
}