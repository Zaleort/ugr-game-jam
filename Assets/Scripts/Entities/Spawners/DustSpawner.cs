using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSpawner : MonoBehaviour
{
    public GameObject dust;
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField]
    private float dustInterval = 0.25f;

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
        StartCoroutine(SpawnDust(dustInterval, dust));
    }

    private IEnumerator SpawnDust(float interval, GameObject dust) 
    {
        yield return new WaitForSeconds(interval);

        if (pool.Count < 50)
        {
            GameObject newDust = Instantiate(dust, new Vector3(Random.Range(minRandomX, maxRandomX), Random.Range(minRandomY, maxRandomY), 0), Quaternion.identity);
            pool.Add(newDust);
            StartCoroutine(SpawnDust(interval, newDust));
            yield break;
        }

        pool.RemoveAll(g => !g);
        StartCoroutine(SpawnDust(interval, dust));
    }
}
