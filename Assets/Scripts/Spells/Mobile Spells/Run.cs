using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : ContinousSpell
{
    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            firePoint.GetComponent<PlayerMovement>().StartRunning();
            _isPerforming = true;
        }
    }

    public override void EndAttack()
    {
        if (_isPerforming)
        {
            firePoint.GetComponent<PlayerMovement>().StopRunning();
            _attackCooldown = attackSpeed;
            _duration = 0;
            _isPerforming = false;
        }
    }
}
