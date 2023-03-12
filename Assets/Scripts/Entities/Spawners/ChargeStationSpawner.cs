using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChargeStationSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> chargeStationsList = new List<GameObject>();

    [Header("How many seconds is the station activated")]
    public int secondsActive=5;
    int previousChargeStation;
    int randomchargeSation;

    Transform positionStation;
    GameObject actualStation;
     
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
        if (previousChargeStation > -1) {
            chargeStationsList[previousChargeStation].SetActive(false);
        }
       
        while (previousChargeStation != randomchargeSation) 
        { 
            randomchargeSation = Random.Range(0, chargeStationsList.Count()); 
        }
        previousChargeStation = randomchargeSation;
        chargeStationsList[randomchargeSation].SetActive(true);
        actualStation = chargeStationsList[randomchargeSation];
        positionStation = actualStation.GetComponent<Transform>();
    }
  
    public Transform getPositionStation(){
        return positionStation;
    }

}
