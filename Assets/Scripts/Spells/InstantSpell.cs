using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantSpell : BaseSpell
{
    private void Update()
    {
        _attackCooldown -= Time.deltaTime;
    }

    public override void EndAttack()
    {

    }
}
