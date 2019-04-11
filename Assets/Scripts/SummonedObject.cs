using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedObject : MonoBehaviour
{
    public float lifeSpawn;

    // Update is called once per frame
    void Update()
    {
        lifeSpawn -= Time.deltaTime;
        if (lifeSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
