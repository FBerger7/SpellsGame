using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarRise : InstantSpell
{
    public GameObject GFX;
    public ParticleSystem dust;
    public float height;
    public float riseDuration;
    public float riseSpeed;
    public float lifeSpan;
    public float force;
    public Vector3 direction;
    public float delay;

    public override void PerformAttack(Vector3 target, bool isHostile)
    {
        if(_attackCooldown <= 0)
        {
            ParticleSystem particles = Instantiate(dust, target+Vector3.up*0.1f, firePoint.rotation);
            _attackCooldown = attackSpeed;
            target.y+= height;
            GameObject newPillar = Instantiate(GFX, target, Quaternion.Euler(-90,0,0));
            newPillar.GetComponentInChildren<Pillar>().isActive = true;
            newPillar.GetComponentInChildren<Pillar>().lifeSpan = lifeSpan;
            newPillar.GetComponentInChildren<Pillar>().riseDuration = riseDuration;
            newPillar.GetComponentInChildren<Pillar>().riseSpeed = riseSpeed;
            newPillar.GetComponentInChildren<Pillar>().force = force;
            newPillar.GetComponentInChildren<Pillar>().direction = direction;
            newPillar.GetComponentInChildren<Pillar>().delay = delay;


        }
    }
}
