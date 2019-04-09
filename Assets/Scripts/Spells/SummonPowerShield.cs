using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPowerShield : BaseSpell
{
    public float shieldLifeSpan;

    public SummonedObject objectToSummon;

    public override void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            SummonedObject newSummonedObject = Instantiate(objectToSummon, transform.position, transform.rotation) as SummonedObject;
            newSummonedObject.lifeSpawn = shieldLifeSpan;
        }
    }
}
