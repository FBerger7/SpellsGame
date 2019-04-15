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
        gameObject.transform.position = firePoint.position;
        if (lifeSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
