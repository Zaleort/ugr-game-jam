using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody2D rb;

    private float health;
    public float damage;

    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //rotate to look at the player ja
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnAttackCollision(Collision2D collision)
    {
        //
    }
}
