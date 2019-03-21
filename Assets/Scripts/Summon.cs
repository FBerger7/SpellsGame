using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : BaseSpell
{
    public GameObject objectToSummon;
    //public KeyCode fireKey;
    //public float attackSpeed;

    //public Transform firePoint;

    private float _attackCooldown;

    // Update is called once per frame
    public override void runUpdate()
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
    //        Vector3 vector3 = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
    //        GameObject newGameObject = Instantiate(objectToSummon, transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0)) as GameObject;
    //    }
    //}

    public override void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Vector3 vector3 = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
            GameObject newGameObject = Instantiate(objectToSummon, transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0)) as GameObject;
        }
    }
}
