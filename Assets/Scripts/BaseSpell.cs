using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MouseTracker
{

    public KeyCode fireKey;

    public float attackSpeed;

    public Transform firePoint;

    public float _attackCooldown;

    public abstract void runUpdate();

    // Update is called once per frame
    //void Update()
    //{
    //    _attackCooldown -= Time.deltaTime;
    //    if (Input.GetKey(fireKey))
    //    {
    //        PerformAttack();
    //    }

    //}

    public abstract void PerformAttack();

       
}
