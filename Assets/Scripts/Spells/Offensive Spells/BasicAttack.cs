using UnityEngine;

public class BasicAttack : InstantSpell
{
    public Projectile projectile;
    public float projectileSpeed;
    public float projectileLifeSpawn;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Projectile newProjectile = Instantiate(projectile, firePoint.position, Quaternion.LookRotation((target - firePoint.position).normalized)) as Projectile;
            newProjectile.speed = projectileSpeed;
            newProjectile.lifeSpawn = projectileLifeSpawn;
            newProjectile.isHostile = isHostile;
            newProjectile.origin = OffensiveSpellsModel.BASIC_SPELL;
        }
    }
}
