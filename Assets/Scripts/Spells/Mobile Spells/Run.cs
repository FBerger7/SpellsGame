using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MobileSpell
{
    public float maxDuration;

    private bool _isPerforming;
    private float _duration = 0;

    void Update()
    {
        if (_isPerforming)
        {
            _duration += Time.deltaTime;
            if (_duration >= maxDuration)
            {
                EndAttack();
            }
        }
        else
        {
            runUpdate();
        }

    }

    public override void PerformAttack(Vector3 target)
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
