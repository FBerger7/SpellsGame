using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public KeyCode fireKey;
    public Transform firePoint;
    private BaseSpell currentSpell;


    // Start is called before the first frame update
    void Start()
    {
        BasicAttack basicAttack;
        currentSpell = basicAttack;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpell.runUpdate();
        currentSpell._attackCooldown -= Time.deltaTime;
        if (Input.GetKey(fireKey))
        {
            currentSpell.PerformAttack();
        }
    }
}
