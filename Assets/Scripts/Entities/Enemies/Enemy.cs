using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning

    public float health;
    public float damage;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        OnAttackCollision(collision);
    }

    private void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnAttackCollision(Collider2D collision)
    {
        Attack attack = collision.gameObject.GetComponent<Attack>();
        if (attack == null)
        {
            return;
        }

        ApplyDamage(attack.damage);
    }

    private void MoveToPlayer()
    {
        if (target == null)
        {
            return;
        }

        //rotate to look at the player
        Vector3 look = transform.InverseTransformPoint(target.transform.position);
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, Angle);

        //move towards the player
        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }

    private void SetTarget()
    {
        target = GameObject.Find("Player");
    }
}
