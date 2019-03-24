using UnityEngine;

public class BasicAttack : BaseSpell
{
    public Projectile projectile;
    public float projectileSpeed;
    public float projectileLifeSpawn;

    // Update is called once per frame
    public void Update()
    {
        runUpdate();     
    }

    public override void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as Projectile;
            newProjectile.speed = projectileSpeed;
            newProjectile.lifeSpawn = projectileLifeSpawn;
        }
    }
}
