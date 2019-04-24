using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContinousSpell : BaseSpell
{
    public float maxDuration;

    protected bool _isPerforming;
    protected float _duration = 0;

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
            _attackCooldown -= Time.deltaTime;
        }

    }
}
