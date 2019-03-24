using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : BaseSpell
{
    public GameObject objectToSummon;

    // Update is called once per frame
    public void Update()
    {
        runUpdate();
    }

    public override void PerformAttack()
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            GameObject newGameObject = Instantiate(objectToSummon, transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0)) as GameObject;
        }
    }
}
