using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleContinousSpell : ContinousSpell
{
    public Projectile projectile;
    public float projectileSpeed;
    public float projectileLifeSpawn;

    private void Start()
    {
        _fireKey = KeyCode.Alpha1;
    }

    // Update is called once per frame
    void Update()
    {
        runUpdate();
        if (_isPerforming)
            PerformAttack(pointToLook);
    }

    public override void PerformAttack(Vector3 target)
    {
        Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as Projectile;
        newProjectile.speed = projectileSpeed;
        newProjectile.lifeSpawn = projectileLifeSpawn;
        newProjectile.origin = OffensiveSpellsModel.BASIC_SPELL;
    }
}
