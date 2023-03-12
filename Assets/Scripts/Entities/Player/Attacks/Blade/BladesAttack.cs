using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesAttack : Attack
{
    private CircleCollider2D[] colliders;

    private void Start()
    {
        colliders = gameObject.GetComponents<CircleCollider2D>();
    }
    public override void DoAttack()
    {
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
