using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    protected const float ACTIVATION_COOLDOWN = 0.5f;

    public float attackSpeed;
    public Transform firePoint;
    public bool isHostile;

    protected KeyCode _fireKey = KeyCode.None;
    protected float _attackCooldown;

    public abstract void PerformAttack(Vector3 target);

    public void setFireKey(KeyCode fireKey)
    {
        _fireKey = fireKey;
    }
}
