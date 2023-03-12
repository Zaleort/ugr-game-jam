using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private const float BASE_RUN_SPEED = 2.5f;
    private const float BASE_CHARGING_SPEED = 0.25f;
    private const float BASE_DRAINING_SPEED = 0.015f;
    private const float BASE_MAX_ENERGY = 100f;
    public const int EXP_TO_LEVEL_UP = 5;

    Rigidbody2D body;
    public List<Attack> attacks = new List<Attack>();
    public HealthBar healthBar;
    public EnergyBar energyBar;
    public ExperienceBar experienceBar;
  
    float horizontal;
    float vertical;

    public float health = 100.0f;
    public float runSpeed = BASE_RUN_SPEED;
    public int experience = 0;
    private int level = 0;

    public float energy = BASE_MAX_ENERGY;
    public float maxEnergy = BASE_MAX_ENERGY;
    private bool isCharging = false;
    private float chargingSpeed = BASE_CHARGING_SPEED;
    private float drainingSpeed = BASE_DRAINING_SPEED;

    private float invulnerabilityTime = 0.15f;
    private float timeToNextDamage = 0f;

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
        OnDustCollision(collision);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        OnEnemyCollision(collision);
        OnChargingStationCollision(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        OnChargingStationCollisionExit(collision);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnemyCollision(collision);
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

    public void AddStatDowngrade(DowngradeType type, float value)
    {
        switch (type)
        {
            case DowngradeType.Draining:
                drainingSpeed += value;
                break;
        }
    }

    public void AddAttackUpgrade(Attack attack)
    {
        Attack existingAttack = attacks.Find(a => a.type == attack.type);
        if (existingAttack)
        {
            existingAttack.Upgrade();
        }

        else
        {
            ActivateAttack(attack);
        }

        AddStatDowngrade(DowngradeType.Draining, BASE_DRAINING_SPEED);
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // Izq
        if (horizontal < 0 && vertical == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        // Der
        else if (horizontal > 0 && vertical == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        // Up
        else if (horizontal == 0 && vertical < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }


        // Down
        else if (horizontal == 0 && vertical > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Top / izq
        if (horizontal < 0 && vertical < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }

        // Bot / izq
        else if (horizontal < 0 && vertical > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        // Top / der
        else if (horizontal > 0 && vertical < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -135);
        }

        // Bot / der
        else if (horizontal > 0 && vertical > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
    }

    private void SetBodyVelocity()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void ApplyDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar();
        if (health <= 0)
        {
            SendMessageUpwards(GameControllerEvents.Death);
        }
    }

    private void AddExperience()
    {
        experience += 1;
        if (experience >= EXP_TO_LEVEL_UP)
        {
            experience = 0;
            level++;

            SendMessageUpwards(GameControllerEvents.LevelUp, level);
        }

        experienceBar.UpdateExperienceBar();
    }

    private void Charge()
    {
        if (isCharging && energy < maxEnergy)
        {
            energy += chargingSpeed;
            energyBar.UpdateEnergyBar();
        }
    }

    private void Drain()
    {
        if (!isCharging)
        {
            energy -= drainingSpeed;
            energyBar.UpdateEnergyBar();
        }
    }

    private void OnEmptyChargeDestroyPowerUps()
    {
        if (energy <= 0)
        {
            ResetStats();
        }
    }

    private void OnEnemyCollision(Collider2D collision)
    {
        if (!CheckIfShouldReceiveDamage())
        {
            return;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy == null)
        {
            return;
        }

        ApplyDamage(enemy.damage);
    }

    private void OnDustCollision(Collision2D collision)
    {
        Dust dust = collision.gameObject.GetComponent<Dust>();
        if (dust == null)
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
        level = 0;
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
        Attack[] attackComponents = gameObject.GetComponentsInChildren<Attack>(true);
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

    private bool CheckIfShouldReceiveDamage()
    {
        if (timeToNextDamage <= Time.time)
        {
            timeToNextDamage = Time.time + invulnerabilityTime;
            return true;
        }

        return false;
    }
}
