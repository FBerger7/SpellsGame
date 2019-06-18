using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railgun : InstantSpell
{
    public ParticleSystem GFX;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if(_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            ParticleSystem newParticle = Instantiate(GFX, firePoint.position, firePoint.rotation) as ParticleSystem;
            newParticle.GetComponent<RailgunParticle>().isHostile = isHostile;
            newParticle.GetComponent<RailgunParticle>().origin = OffensiveSpellsModel.RAILGUN;
            newParticle.Play();
        }
    }
}
