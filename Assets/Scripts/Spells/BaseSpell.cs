using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    protected const float ACTIVATION_COOLDOWN = 0.5f;

    public float attackSpeed;
    public Transform firePoint;

    protected bool _isActivated = false;
    protected float _activationCooldown = ACTIVATION_COOLDOWN;
    protected float _attackCooldown;

    public abstract void PerformAttack(Vector3 target);

    // Update is called once per frame
    protected void Update()
    {
        _attackCooldown -= Time.deltaTime;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }

    public void Activate()
    {
        _isActivated = true;
    }
}
