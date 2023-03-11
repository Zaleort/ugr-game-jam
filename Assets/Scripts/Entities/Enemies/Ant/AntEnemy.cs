using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEnemy : MonoBehaviour
{
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        enemy.health = 5f;
        enemy.damage = 2f;
    }
}
