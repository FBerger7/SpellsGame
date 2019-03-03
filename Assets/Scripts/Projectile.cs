using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifeSpwan;

    // Update is called once per frame
    void Update()
    {
        lifeSpwan -= Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(lifeSpwan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
