using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 600) * Time.deltaTime);
    }
}
