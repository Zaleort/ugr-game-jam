using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAttack : Attack
{
    public override void DoAttack()
    {
        // Not necessary
    }

    public override void Upgrade()
    {
        damage += 5;
    }
}
