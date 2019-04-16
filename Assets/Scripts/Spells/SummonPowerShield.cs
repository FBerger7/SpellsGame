using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPowerShield : InstantSpell
{
    public float shieldLifeSpan;
    public PowerShield powerShield;

    public override void PerformAttack(Vector3 target)
    {
        PowerShield newPowerShield = Instantiate(powerShield, firePoint.position + new Vector3(0, 10.0f), transform.rotation) as PowerShield;
        newPowerShield.lifeSpawn = shieldLifeSpan;
        newPowerShield.firePoint = firePoint;
        
    }
}
