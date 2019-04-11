using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public int CurrentHealth { get; private set; }

    public int damage;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
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
