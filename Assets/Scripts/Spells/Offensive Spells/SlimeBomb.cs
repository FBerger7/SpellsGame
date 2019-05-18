using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBomb : InstantSpell
{

    public GameObject projectile;
    public float hight = 20;

    private float _gravity;

    // Start is called before the first frame update
    void Start()
    {
        _gravity = Physics.gravity.y;
    }

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if(_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            GameObject newProjectile = Instantiate(projectile, firePoint.position, Quaternion.LookRotation(Vector3.up));
            newProjectile.GetComponent<Rigidbody>().velocity = CalculateLunchVelocity(target);
            newProjectile.GetComponent<SlimeBombProjectile>().isHostile = isHostile;
            newProjectile.GetComponent<SlimeBombProjectile>().origin = OffensiveSpellsModel.SLIME_BOMB;
        }
    }

    Vector3 CalculateLunchVelocity(Vector3 target)
    {
        float displacementY = target.y - firePoint.position.y;
        Vector3 displacementXZ = new Vector3(target.x - firePoint.position.x, 0, target.z - firePoint.position.z);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * _gravity * hight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * hight / _gravity) + Mathf.Sqrt(2*(displacementY - hight)/_gravity));

        return velocityXZ + velocityY;
    }

}
