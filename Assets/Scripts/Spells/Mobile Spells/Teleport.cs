using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : InstantSpell
{
    public float maxRange;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0 && Vector3.Distance(firePoint.position, target) <= maxRange)
        {
            _attackCooldown = attackSpeed;
            firePoint.position = new Vector3(target.x, target.y, target.z);
        }
    }
}
