using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantSpell : BaseSpell
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (Input.GetKey(_fireKey) && _attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            PerformAttack(pointToLook);
        }
    }

    //public void Deactivate()
    //{
    //    _isActivated = false;
    //}

    //public void Activate()
    //{
    //    _isActivated = true;
    //}
}
