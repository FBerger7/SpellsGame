using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunParticle : CastedSpell
{
    public float damage;
    private void OnParticleCollision(GameObject other)
    {
        CharacterStats parent = other.GetComponentInParent<CharacterStats>();
        if (parent != null && this.isHostile != parent.isHostile)
            parent.TakeDamage(damage);
        if (other.GetComponent<PowerShield>())
            Destroy(gameObject);
    }
}
