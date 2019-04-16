using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
   // public float myDamage;

    public float maxHealth;
    public float CurrentHealth { get; private set; }

   // public int damage;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        //This method is meant to be overwrriten
        Debug.Log(transform.name + " died");

    }

}
