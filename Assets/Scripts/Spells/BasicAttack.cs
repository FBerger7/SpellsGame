using UnityEngine;

public class BasicAttack : InstantSpell
{
    public Projectile projectile;
    public float projectileSpeed;
    public float projectileLifeSpawn;

    public override void PerformAttack(Vector3 target)
    {
        Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as Projectile;
        newProjectile.speed = projectileSpeed;
        newProjectile.lifeSpawn = projectileLifeSpawn;
    }
}
