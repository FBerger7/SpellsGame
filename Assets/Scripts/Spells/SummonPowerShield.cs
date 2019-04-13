using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPowerShield : InstantSpell
{
    public float shieldLifeSpan;
    public SummonedObject objectToSummon;

    public override void PerformAttack(Vector3 target)
    {
        SummonedObject newSummonedObject = Instantiate(objectToSummon, transform.position, transform.rotation) as SummonedObject;
        newSummonedObject.lifeSpawn = shieldLifeSpan;
    }
}
