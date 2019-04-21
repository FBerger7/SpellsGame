using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MobileSpell
{
    void Start()
    {
        SetCamera();
    }

    public override void PerformAttack(Vector3 target)
    {
        if (_attackCooldown <= 0)
        {
            _attackCooldown = attackSpeed;
            TrackMouse();
            firePoint.position = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
        }
    }
}
