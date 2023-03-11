using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Attack
{
    public override void Upgrade()
    {
        damage += 0.02f;
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, transform.parent.forward, 125 * Time.deltaTime);
    }
}
