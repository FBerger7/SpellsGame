using UnityEngine;

public class BasicAttack : BaseSpell
{
    public Projectile projectile;
    //public KeyCode fireKey;
    public float projectileSpeed;
    //public float attackSpeed;
    public float projectileLifeSpawn;

    //public Transform firePoint;

    private float _attackCooldown;

    // Update is called once per frame
    void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (Input.GetKey(fireKey))
        {
            PerformAttack();
        }

    }

    //private void PerformAttack()
    //{
    //    if (_attackCooldown <= 0)
    //    {
    //        _attackCooldown = attackSpeed;
    //        Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as Projectile;
    //        newProjectile.speed = projectileSpeed;
    //        newProjectile.lifeSpwan = projectileLifeSpawn;
    //    }
    //}

    public override void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Projectile newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as Projectile;
            newProjectile.speed = projectileSpeed;
            newProjectile.lifeSpwan = projectileLifeSpawn;
        }
    }
}
