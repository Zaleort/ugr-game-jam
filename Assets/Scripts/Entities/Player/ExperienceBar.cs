using UnityEngine;
using UnityEngine.UI;
public class ExperienceBar : MonoBehaviour
{
    public Image experienceBarImage;
    public Player player;
    public void UpdateExperienceBar()
    {
        Debug.Log(player.experience);
        Debug.Log(Player.EXP_TO_LEVEL_UP);
        experienceBarImage.fillAmount = Mathf.Clamp((float)player.experience / (float)Player.EXP_TO_LEVEL_UP, 0, 1f);
    }
}