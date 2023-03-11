using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesAttack : Attack
{
    private void Update()
    {
        
    }

    public override void Upgrade()
    {
        damage += 1;
    }
}
