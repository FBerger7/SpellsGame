using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MouseTracker
{
    public Projectile projectile;
    public KeyCode fireKey;
    public float projectileSpeed;
    public float attackSpeed;
    public float projectileLifeSpawn;

    public Transform firePoint;

    private float _attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _attackCooldown -= Time.deltaTime;
        if (Input.GetKey(fireKey))
        {
            PerformAttack();
        }
    }

    // Update is called once per frame
    private void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Projectile newProjectile = Instantiate(projectile, pointToLook, firePoint.rotation) as Projectile;
        }
    }
}
