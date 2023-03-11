using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    void Start()
    {
        InvokeRepeating("instantiate", 0, 2);
    }

    private void instantiate()
    {
        Instantiate(enemy, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }
}
