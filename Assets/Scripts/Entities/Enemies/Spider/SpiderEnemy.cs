using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        enemy.health = 10f;
        enemy.damage = 5f;
    }
}
