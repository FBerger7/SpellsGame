using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifeSpawn;

    // Update is called once per frame
    void Update()
    {
        lifeSpawn -= Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(lifeSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
