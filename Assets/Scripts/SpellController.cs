using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private BaseSpell currentSpell;
    public KeyCode fireKey;

    // Start is called before the first frame update
    void Start()
    {
        currentSpell = new BasicAttack();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpell._attackCooldown -= Time.deltaTime;
        if (Input.GetKey(fireKey))
        {
            currentSpell.PerformAttack();
        }
    }
}
