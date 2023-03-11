using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackType type;
    public float damage;
    public abstract void Upgrade();
}
