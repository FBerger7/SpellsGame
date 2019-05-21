using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBomb : InstantSpell
{

    public GameObject projectile;
    public float hight = 20;

    public float gravity= -100;

    private float tmpHeigtht;

    private void Start()
    {
        tmpHeigtht = hight;
    }

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if(_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            GameObject newProjectile = Instantiate(projectile, firePoint.position, Quaternion.LookRotation(Vector3.up));
            tmpHeigtht += this.gameObject.transform.position.y;
            newProjectile.GetComponent<Rigidbody>().velocity = CalculateLunchVelocity(target);
            newProjectile.GetComponent<SlimeBombProjectile>().isHostile = isHostile;
            newProjectile.GetComponent<SlimeBombProjectile>().origin = OffensiveSpellsModel.SLIME_BOMB;
        }
    }

    Vector3 CalculateLunchVelocity(Vector3 target)
    {
        float displacementY = target.y - firePoint.position.y;
        Vector3 displacementXZ = new Vector3(target.x - firePoint.position.x, 0, target.z - firePoint.position.z);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * gravity * tmpHeigtht);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * tmpHeigtht / gravity) + Mathf.Sqrt(2*(displacementY - tmpHeigtht)/gravity));
        tmpHeigtht = hight;

        return velocityXZ + velocityY;
    }

}
