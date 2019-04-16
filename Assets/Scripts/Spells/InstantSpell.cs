using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantSpell : BaseSpell
{
    // Update is called once per frame
    void Update()
    {
        _attackCooldown -= Time.deltaTime;
    }
}
