using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShield : MonoBehaviour
{
    public float lifeSpawn;
    public Transform firePoint;
    public OffensiveSpellsModel model;

    // Update is called once per frame
    void Update()
    {
        lifeSpawn -= Time.deltaTime;
        gameObject.transform.position = firePoint.position + new Vector3(0, 10.0f);
        if (lifeSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CastedSpell castedSpell = other.GetComponent<CastedSpell>();
        if (castedSpell != null)
        {
            if (castedSpell.isHostile)
            {
                model.AcknowledgeSpell(castedSpell.origin);
                Destroy(other.gameObject);
            }
        }
    }
}
