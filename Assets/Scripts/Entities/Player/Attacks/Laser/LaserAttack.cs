using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : Attack
{

    public override void DoAttack()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        if (!CheckIfShouldAttack())
        {
            collider.enabled = true;
            return;
        }

        GetNextAttackTime();
        collider.enabled = false;
    }

    public override void Upgrade()
    {
        damage += 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, transform.parent.forward, 125 * Time.deltaTime);
        DoAttack();
    }
}
