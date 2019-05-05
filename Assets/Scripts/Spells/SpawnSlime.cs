using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : InstantSpell
{
    public SlimeController slime;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            SlimeController newSlime = Instantiate(slime, transform.position, transform.rotation) as SlimeController;
        }
    }
}
