using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : InstantSpell
{
    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            firePoint.GetComponentInParent<PlayerMovement>().Jump();
        }
    }
}
