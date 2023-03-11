using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public AttackType type;
    public float baseDamage;
    public float damage;

    private void FixedUpdate()
    {
        type.DoAttack();
    }
}
