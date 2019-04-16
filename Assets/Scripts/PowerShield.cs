using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShield : MonoBehaviour
{
    public float lifeSpawn;
    public Transform firePoint;

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
        if (other.GetComponent<CastedSpell>())
            if (other.GetComponent<CastedSpell>().isHostile)
                Destroy(other.gameObject);
    }
}
