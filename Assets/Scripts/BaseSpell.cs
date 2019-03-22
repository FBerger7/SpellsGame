using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{

    public KeyCode fireKey;

    public float attackSpeed;

    public Transform firePoint;

    protected float _attackCooldown;

    public abstract void PerformAttack();

       
}
