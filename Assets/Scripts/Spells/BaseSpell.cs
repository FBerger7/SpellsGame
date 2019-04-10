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
    [SerializeField]
    protected float _attackCooldown;

    //public abstract void PerformAttack();
    public abstract void PerformAttack();

    // Update is called once per frame
    protected void Update()
    {
        _attackCooldown -= Time.deltaTime;
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
