using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    protected const float ACTIVATION_COOLDOWN = 0.5f;

    public float attackSpeed;
    public Transform firePoint;

    protected KeyCode _fireKey;
    protected float _attackCooldown;
    //protected bool _isActivated = false;
    //protected float _activationCooldown = ACTIVATION_COOLDOWN;

    public abstract void PerformAttack(Vector3 target);

    public void setFireKey(KeyCode fireKey)
    {
        _fireKey = fireKey;
    }

    //// Update is called once per frame
    //protected void Update()
    //{
    //    _attackCooldown -= Time.deltaTime;
    //}

    //public void Deactivate()
    //{
    //    _isActivated = false;
    //}

    //public void Activate()
    //{
    //    _isActivated = true;
    //}
}
