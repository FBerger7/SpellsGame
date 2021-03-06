﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonWall : InstantSpell
{
    public float wallLifeSpan;

    public SummonedObject objectToSummon;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            SummonedObject newSummonedObject = Instantiate(objectToSummon, transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0)) as SummonedObject;
            newSummonedObject.lifeSpawn = wallLifeSpan;
        }
    }
}
