using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    GameObject chargeStation;
    ChargeStationSpawner chargeStationSpawnerScript;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        chargeStationSpawnerScript = GetComponent<ChargeStationSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        target = chargeStationSpawnerScript.getPositionStation();
        lookAt(target);
    }
    //invocar public Transform getSpawner de Script ChargeStationSpawner
    public void lookAt(Transform target) 
    {
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, Angle);
    }
}
