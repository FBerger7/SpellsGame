using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplayPoison : MonoBehaviour
{
    public float poisonDMG;
    private void OnTriggerStay(Collider other)
    {
        CharacterStats parent = other.GetComponentInParent<CharacterStats>();
        if (parent != null && !parent.poisonImmune)
        {
            parent.ApplayPoison(poisonDMG);
        }
    }
}
