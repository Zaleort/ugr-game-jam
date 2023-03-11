using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackType type;
    public float damage;

    private void FixedUpdate()
    {
        DoAttack();
    }

    public abstract void DoAttack();
    public abstract void Upgrade();
}
