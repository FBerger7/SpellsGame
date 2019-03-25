using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    protected const float ACTIVATION_COOLDOWN = 0.5f;

    public KeyCode fireKey;
    public float attackSpeed;
    public Transform firePoint;

    protected bool _isActivated = false;
    protected float _activationCooldown = ACTIVATION_COOLDOWN;
    protected float _attackCooldown;

    public abstract void PerformAttack();

    // Update is called once per frame
    protected void Update()
    {
        float deltaTime = Time.deltaTime;

        _attackCooldown -= deltaTime;
        if (_isActivated && Input.GetKey(fireKey))
        {
            PerformAttack();
        }
    }

    public void deactivate()
    {
        _isActivated = false;
    }

    public void activate()
    {
        _isActivated = true;
    }
}
