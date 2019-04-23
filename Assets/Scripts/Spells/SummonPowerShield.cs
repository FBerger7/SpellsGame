using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPowerShield : InstantSpell
{
    public float shieldLifeSpan;
    public PowerShield powerShield;
    public OffensiveSpellsModel model;

    public void PerformAttack(OffensiveSpellsModel model)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            PowerShield newPowerShield = Instantiate(powerShield, firePoint.position + new Vector3(0, 10.0f), transform.rotation) as PowerShield;
            newPowerShield.lifeSpawn = shieldLifeSpan;
            newPowerShield.firePoint = firePoint;
            newPowerShield.model = model;
        }
    }

    public override void PerformAttack(Vector3 target)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            PowerShield newPowerShield = Instantiate(powerShield, firePoint.position + new Vector3(0, 10.0f), transform.rotation) as PowerShield;
            newPowerShield.lifeSpawn = shieldLifeSpan;
            newPowerShield.firePoint = firePoint;
        }
    }
}
