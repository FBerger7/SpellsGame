using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBombProjectile : CastedSpell
{
    public float damage;

    public GameObject poisonCloud;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterStats parent = other.GetComponentInParent<CharacterStats>();
        if (parent != null && this.isHostile != parent.isHostile)
        {
            parent.TakeDamage(damage);
        }

        if (!other.GetComponent<PowerShield>() && other.tag!="Particles")
        {
            Instantiate(poisonCloud, transform.position,Quaternion.Inverse(Quaternion.Euler(90,0,0)));
            Destroy(gameObject);
        }
    }
}
