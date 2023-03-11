using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChargeStationSpawner : MonoBehaviour
{
    public List<GameObject> chargeStationsList = new List<GameObject>();
    [Header("How many seconds is the station activated")]
    public int secondsActive=5;
    int previousChargeStation;
    int randomchargeSation;
    // Start is called before the first frame update
    void Start()
    {
        randomchargeSation = 0;
        InvokeRepeating("ActiveChargeStation", 0, secondsActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActiveChargeStation() {
        chargeStationsList[previousChargeStation].SetActive(false);
        while (previousChargeStation == randomchargeSation) { 
            randomchargeSation = Random.Range(0, chargeStationsList.Count()); 
        }
        previousChargeStation = randomchargeSation;
        chargeStationsList[randomchargeSation].SetActive(true);
        Debug.Log("Lista número" + randomchargeSation);


    }
}
