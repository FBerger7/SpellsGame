using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    public float attackSpeed;
    public Transform firePoint;
    public bool isHostile;

    protected float _attackCooldown;

    public abstract void PerformAttack(Vector3 target);
    public abstract void EndAttack();
}
