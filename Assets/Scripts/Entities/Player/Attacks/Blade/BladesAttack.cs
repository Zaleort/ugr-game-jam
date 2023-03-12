using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesAttack : Attack
{
    public override void DoAttack()
    {
        CircleCollider2D[] colliders = gameObject.GetComponents<CircleCollider2D>();
        if (!CheckIfShouldAttack())
        {
            foreach (CircleCollider2D col in colliders)
            {
                col.enabled = true;
            }
            return;
        }

        GetNextAttackTime();
        foreach (CircleCollider2D col in colliders)
        {
            col.enabled = false;
        }
    }

    private void Update()
    {
        DoAttack();
    }

    public override void Upgrade()
    {
        damage += 1;
    }
}
