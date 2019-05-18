using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{
    public float attackSpeed;
    public Transform firePoint;

    protected float _attackCooldown;

    public abstract void PerformAttack(Vector3 target, bool isHostile);
    public abstract void EndAttack();
}
