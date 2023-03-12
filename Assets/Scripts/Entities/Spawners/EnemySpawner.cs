using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject easyEnemy;
    [SerializeField]
    private GameObject mediumEnemy;
    [SerializeField]
    private GameObject hardEnemy;

    [SerializeField]
    private float easyEnemyInterval = 3.5f;
    [SerializeField]
    private float mediumEnemyInterval = 10.5f;
    [SerializeField]
    private float hardEnemyInterval = 20.5f;

    [SerializeField]
    private float minRandomX;

    [SerializeField]
    private float maxRandomX;

    [SerializeField]
    private float minRandomY;

    [SerializeField]
    private float maxRandomY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(easyEnemyInterval, easyEnemy));
        StartCoroutine(spawnEnemy(mediumEnemyInterval, mediumEnemy));
        StartCoroutine(spawnEnemy(hardEnemyInterval, hardEnemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) 
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(minRandomX, maxRandomX), Random.Range(minRandomY, maxRandomY), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, newEnemy));
    }
}
