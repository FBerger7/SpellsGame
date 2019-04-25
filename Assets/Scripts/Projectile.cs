using UnityEngine;

public class Projectile : CastedSpell
{
    public float speed;

    public float damage;

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
        CharacterStats parent = other.GetComponentInParent<CharacterStats>();
        if (parent != null && this.isHostile != parent.isHostile)
          parent.TakeDamage(damage);
        
        if (!other.GetComponent<PowerShield>() && other.tag != "Particles")
            Destroy(gameObject);
    }
}
