using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSlime : InstantSpell
{
    public SlimeController slime;
    public GameObject enemyHealthContainer;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            Vector3 groundFirePoint = new Vector3(firePoint.position.x, 0, firePoint.position.z);
            SlimeController newSlime = Instantiate(slime, groundFirePoint, transform.rotation) as SlimeController;
            newSlime.name = "SpawnedSlime";
            newSlime.isHostile = true;
            newSlime.enemyHealthContainer = enemyHealthContainer;
        }
    }
}
