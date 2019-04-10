using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : BaseSpell
{
    public ParticleSystem GFX;

    //Zmienan definiująca odstep przed ponowynym użyciem FireBreath
    public float overheat;

    new void Update()
    {
        if (_isActivated)
        {
            _attackCooldown -= Time.deltaTime;
            if(_attackCooldown <= 0)
            {
                deactivate();
            }
        }
        else
        {
            if (_attackCooldown >= attackSpeed)
            {
                _attackCooldown = attackSpeed;
            }
            else
            {
                _attackCooldown += Time.deltaTime;
            }
        }

    }

    public override void PerformAttack()
    {
        if(_attackCooldown > overheat)
        {
            ParticleSystem newProjectile = Instantiate(GFX, firePoint.position, firePoint.rotation) as ParticleSystem;

            newProjectile.Play();
            activate();
        }
    }
}
