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
        target = null;
        chargeStationSpawnerScript = GetComponent<ChargeStationSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        lookAt(target);
    }
    //invocar public Transform getSpawner de Script ChargeStationSpawner
    private void lookAt(Transform target) 
    {
        if (target != null) 
        {
            Vector3 look = transform.InverseTransformPoint(target.transform.position);
            float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, Angle);
        }
        
    }

    public Transform setPointToLookAt(Transform transform) 
    {
        Debug.Log("TargetIndicator"+transform);
        this.target = transform;
        return transform;
    }
}
