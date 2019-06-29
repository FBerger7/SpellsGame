using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : InstantSpell
{
    public ParticleSystem GFX;

    [SerializeField]
    private bool _isActive;

    //Zmienan definiująca odstep przed ponowynym użyciem FireBreath
    public float overheat;

    private void Update()
    {
        if (_isActive)
        {
            _attackCooldown -= Time.deltaTime;
            if(_attackCooldown <= 0)
            {
                _isActive = false;
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

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if(_attackCooldown > overheat)
        {
            ParticleSystem newProjectile = Instantiate(GFX, firePoint.position, Quaternion.LookRotation((target - firePoint.position).normalized)) as ParticleSystem;
            newProjectile.GetComponent<FireBreathProjectile>().isHostile = isHostile;
            newProjectile.GetComponent<FireBreathProjectile>().origin = OffensiveSpellsModel.FIRE_BREATH;
            newProjectile.Play();
            _isActive = true;
        }
    }
}
