using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : InstantSpell
{
    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            firePoint.position = new Vector3(target.x, target.y, target.z);
        }
    }
}
