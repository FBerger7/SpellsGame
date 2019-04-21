using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MobileSpell
{
    public float jumpForce;

    public override void PerformAttack(Vector3 target)
    {
        firePoint.GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
    }
}
