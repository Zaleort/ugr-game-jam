using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public LaserAttack laser;
    public BladesAttack blades;

    public void SetUpgrades(int level)
    {
        switch (level)
        {
            case 1:
            case 5:
                Debug.Log("Add upgrade");
                player.AddAttackUpgrade(laser);
                break;
            case 2:
            case 6:
                player.AddAttackUpgrade(laser);
                break;
            case 3:
            case 7:
                player.AddAttackUpgrade(laser);
                break;
            case 4:
            case 8:
                player.AddStatUpgrade(UpgradeType.Energy, 20f);
                break;
        }
    }
}
