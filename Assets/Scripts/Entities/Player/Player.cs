using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
  
    float horizontal;
    float vertical;

    public float health = 100.0f;
    public float runSpeed = 20.0f;
    public int baseDamage = 1;
    private int exp = 0;
    private int level = 0;

    private float energy = 100.0f;
    private float chargingSpeed = 0.5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        SetBodyVelocity();
        Charge();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnEnemyCollision(collision);
        OnDustCollision(collision);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        OnChargingStationCollision(collision);
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void SetBodyVelocity()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // GameOver;
        }
    }

    private void AddExperience()
    {
        exp += 1;
        if (exp >= 20)
        {
            exp = 0;
            level++;

            // LevelUp event
        } 
    }

    private void Charge()
    {
        energy += chargingSpeed;
    }

    private void OnEmptyChargeDestroyPowerUps()
    {
        if (energy <= 0)
        {
            // Set attacks array to empty
            // set base stats
        }
    }

    private void OnEnemyCollision(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        ApplyDamage(enemy.damage);
    }

    private void OnDustCollision(Collision2D collision)
    {
        Dust dust = collision.gameObject.GetComponent<Dust>();
        if (dust != null)
        {
            return;
        }

        AddExperience();
    }

    private void OnChargingStationCollision(Collision2D collision)
    {
        ChargingStation chargingStation = collision.gameObject.GetComponent<ChargingStation>();
        if (chargingStation == null)
        {
            return;
        }

        Charge();
    }
}
