using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private const float BASE_RUN_SPEED = 20.0f;
    private const float BASE_CHARGING_SPEED = 0.5f;
    private const float BASE_DRAINING_SPEED = 0.05f;
    private const float BASE_MAX_ENERGY = 100f;
    private const int EXP_TO_LEVEL_UP = 20;

    Rigidbody2D body;
    public List<Attack> attacks = new List<Attack>();
  
    float horizontal;
    float vertical;

    public float health = 100.0f;
    public float runSpeed = BASE_RUN_SPEED;
    private int exp = 0;
    private int level = 0;

    private float energy = BASE_MAX_ENERGY;
    private float maxEnergy = BASE_MAX_ENERGY;
    private bool isCharging = false;
    private float chargingSpeed = BASE_CHARGING_SPEED;
    private float drainingSpeed = BASE_DRAINING_SPEED;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        OnEmptyChargeDestroyPowerUps();
    }

    private void FixedUpdate()
    {
        SetBodyVelocity();
        Charge();
        Drain();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnEnemyCollision(collision);
        OnDustCollision(collision);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       OnChargingStationCollision(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        OnChargingStationCollisionExit(collision);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       OnChargingStationCollision(collision);
    }

    public void AddStatUpgrade(UpgradeType upgrade, float value)
    {
        switch (upgrade)
        {
            case UpgradeType.Health:
                health += value;
                break;
            case UpgradeType.Speed:
                runSpeed += value;
                break;
            case UpgradeType.Energy:
                maxEnergy += value;
                break;
            case UpgradeType.ChargeSpeed:
                chargingSpeed += value;
                break;
        }
    }

    public void AddStatDowngrade(DowngradeType type)
    {
        switch (type)
        {
            case DowngradeType.Draining:
                drainingSpeed += BASE_DRAINING_SPEED;
                break;
        }
    }

    public void AddAttackUpgrade(Attack attack)
    {
        Attack existingAttack = attacks.Find((a) => a.type == attack.type);
        if (existingAttack)
        {
            attack.Upgrade();
        }

        else
        {
            ActivateAttack(attack);
        }

        AddStatDowngrade(DowngradeType.Draining);
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
            SendMessageUpwards(GameControllerEvents.Death);
        }
    }

    private void AddExperience()
    {
        exp += 1;
        if (exp >= EXP_TO_LEVEL_UP)
        {
            exp = 0;
            level++;

            SendMessageUpwards(GameControllerEvents.LevelUp);
        } 
    }

    private void Charge()
    {
        if (isCharging && energy < maxEnergy)
        {
            energy += chargingSpeed;
        }
    }

    private void Drain()
    {
        if (!isCharging && attacks.Count > 0)
        {
            energy -= drainingSpeed;
        }
    }

    private void OnEmptyChargeDestroyPowerUps()
    {
        if (energy <= 0)
        {
            ResetStats();
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

    private void OnChargingStationCollision(Collider2D collision)
    {
        ChargingStation chargingStation = collision.gameObject.GetComponent<ChargingStation>();
        if (chargingStation == null)
        {
            return;
        }

        isCharging = true;
        Charge();
    }

    private void OnChargingStationCollisionExit(Collider2D collision)
    {
        ChargingStation chargingStation = collision.gameObject.GetComponent<ChargingStation>();
        if (chargingStation == null)
        {
            return;
        }

        isCharging = false;
    }

    private void ResetStats()
    {
        runSpeed = BASE_RUN_SPEED;
        chargingSpeed = BASE_CHARGING_SPEED;
        drainingSpeed = BASE_DRAINING_SPEED;
        DeactivateAttacks();
    }

    private void DeactivateAttacks()
    {
        Attack[] attackComponents = gameObject.GetComponentsInChildren<Attack>();
        foreach (Attack attackComponent in attackComponents)
        {
            attackComponent.gameObject.SetActive(false);
        }

        attacks.Clear();
    }

    private void ActivateAttack(Attack attack)
    {
        Attack[] attackComponents = gameObject.GetComponentsInChildren<Attack>();
        foreach (Attack attackComponent in attackComponents)
        {
            if (attackComponent.type != attack.type)
            {
                continue;
            }

            attackComponent.gameObject.SetActive(true);
            attacks.Add(attack);
        }
    }
}
