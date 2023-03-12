using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public LaserAttack laser;
    public BladesAttack blades;
    public SpikesAttack spikes;

    public void SetUpgrades(int level)
    {
        switch (level)
        {
            case 1:
                player.AddAttackUpgrade(spikes);
                break;
            case 2:
            case 6:
                player.AddStatUpgrade(UpgradeType.Energy, 20f);
                break;
            case 3:
            case 7:
                player.AddAttackUpgrade(blades);
                break;
            case 4:
            case 8:
                player.AddStatUpgrade(UpgradeType.Energy, 20f);
                break;
            case 5:
            case 9:
                player.AddAttackUpgrade(laser);
                player.AddStatDowngrade(DowngradeType.Draining, 0.3f);
                break;
            case 10:
                player.AddStatUpgrade(UpgradeType.Energy, 20f);
                break;
        }
    }
}
