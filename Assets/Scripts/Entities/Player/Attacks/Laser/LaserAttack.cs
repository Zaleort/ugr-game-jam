using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : Attack
{
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider2D>();
    }
    public override void DoAttack()
    {
        if (!CheckIfShouldAttack())
        {
            _collider.enabled = true;
            return;
        }

        GetNextAttackTime();
        _collider.enabled = false;
    }

    public override void Upgrade()
    {
        damage += 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward, 360 * Time.deltaTime, Space.World);
        DoAttack();
    }
}
