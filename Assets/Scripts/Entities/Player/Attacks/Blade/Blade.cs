using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
    }
}
