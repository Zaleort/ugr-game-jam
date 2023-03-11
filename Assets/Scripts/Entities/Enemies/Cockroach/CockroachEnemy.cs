using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachEnemy : MonoBehaviour
{
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        enemy.health = 30f;
        enemy.damage = 10f;
    }
}
