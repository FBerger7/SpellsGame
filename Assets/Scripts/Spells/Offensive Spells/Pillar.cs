using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public bool isActive;
    public float riseDuration;
    public float lifeSpan;
    public float riseSpeed;
    public float force;
    public Vector3 direction;
    public float damage;
    public float delay;

    // Update is called once per frame
    void Update()
    {

        if (delay > 0)
            delay -= Time.deltaTime;
        else
        {
            if(isActive)
            {
                if (riseDuration <= 0)
                {
                    isActive = false;
                    this.GetComponent<Rigidbody>().useGravity = true;
                }
                else
                {
                    riseDuration -= Time.deltaTime;
                    gameObject.transform.Translate(new Vector3(0,0,riseSpeed));

                }
            }
            else
            {
                lifeSpan -= Time.deltaTime;
                if (lifeSpan <= 0)
                    Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isActive)
        {
            CharacterStats parent = collision.gameObject.GetComponentInParent<CharacterStats>();
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (parent != null)
            {
                parent.TakeDamage(damage);
            }
            if (rb !=null)
            {
                rb.AddForce(direction * force,ForceMode.VelocityChange);
                riseSpeed = 0.1f;
            }
        }
    }

    public void RisePillar()
    {
        isActive = true;
        this.GetComponent<Rigidbody>().useGravity = false;
    }
}
