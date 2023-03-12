using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackType type;
    public float damage;
    public float attackSpeed;
    public float nextAttack;
    public abstract void Upgrade();

    protected bool CheckIfShouldAttack()
    {
        return nextAttack <= Time.time;
    }

    protected void GetNextAttackTime()
    {
        nextAttack = Time.time + attackSpeed;
    }

    public abstract void DoAttack();
}
