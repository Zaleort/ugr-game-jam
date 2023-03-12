using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField]
    [Header("Press Z")]
    private GameObject easyEnemy;
    [SerializeField]
    [Header("Press X")]
    private GameObject mediumEnemy;
    [SerializeField]
    [Header("Press C")]
    private GameObject hardEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(easyEnemy, this.transform.position, this.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(mediumEnemy, this.transform.position, this.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(mediumEnemy, this.transform.position, this.transform.rotation);
        }
    }

}
