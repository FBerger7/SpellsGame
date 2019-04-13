using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContinousSpell : BaseSpell
{
    private bool _isPerforming;

    // Update is called once per frame
    void Update()
    {
        if (!_isPerforming)
        {
            _attackCooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(_fireKey) && _attackCooldown <= 0)
        {
            _isPerforming = true;
        }
        if (_isPerforming)
        {
            PerformAttack(pointToLook);
        }
        if (Input.GetKeyUp(_fireKey) && _isPerforming)
        {
            _isPerforming = false;
            _attackCooldown = attackSpeed;
        }
    }
}
