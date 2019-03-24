using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    protected const float ACTIVATION_COOLDOWN = 0.5f;

    public KeyCode fireKey;

    public KeyCode activationKey;

    public float attackSpeed;

    public Transform firePoint;

    public bool isActivated = false;

    protected float _activationCooldown = ACTIVATION_COOLDOWN;

    protected float _attackCooldown;

    public abstract void PerformAttack();

    protected void runUpdate()
    {
        float deltaTime = Time.deltaTime;

        _activationCooldown -= deltaTime;
        if (Input.GetKey(activationKey))
        {
            if (_activationCooldown <= 0)
            {
                _activationCooldown = ACTIVATION_COOLDOWN;
                isActivated = !isActivated;
            }
        }

        _attackCooldown -= deltaTime;
        if (isActivated && Input.GetKey(fireKey))
        {
            PerformAttack();
        }
    }

       
}
