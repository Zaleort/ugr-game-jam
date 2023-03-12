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

    GameObject arrow;

    Transform positionStation;
    GameObject actualStation;

    TargetIndicator targetIndicator;
     
    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("TargetIndicator");
        previousChargeStation = -1;
        randomchargeSation = -2;
        targetIndicator = arrow.GetComponent<TargetIndicator>();
        InvokeRepeating("ActiveChargeStation", 0, secondsActive);
    }

    private void ActiveChargeStation() {
        randomchargeSation = Random.Range(0, chargeStationsList.Count());

        if (previousChargeStation != randomchargeSation)
        {
            if (previousChargeStation > -1) {
                chargeStationsList[previousChargeStation].SetActive(false);
            }
            
            Debug.Log("Total =" + chargeStationsList.Count() + "Previous =" + previousChargeStation + "Actual =" + randomchargeSation);
            previousChargeStation = randomchargeSation;
            chargeStationsList[randomchargeSation].SetActive(true);
            actualStation = chargeStationsList[randomchargeSation];
            positionStation = actualStation.GetComponent<Transform>();
            targetIndicator.setPointToLookAt(positionStation);
        }
        else {
            ActiveChargeStation();
        }

       
        
    }
  
    

}
