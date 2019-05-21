using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
   // public float myDamage;

    public float maxHealth;

    public float CurrentHealth { get; private set; }

    public bool isHostile;
    public bool poisonImmune;
    public float poisonCooldown;
    public CharacterInterface characterInterface;

    [SerializeField]
    protected float _poisonTimer;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        _poisonTimer -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            if(characterInterface)
                characterInterface.SetHealthPoints((int)CurrentHealth);
            Die();
        }
        else
        {
            if (characterInterface)
                characterInterface.SetHealthPoints((int)CurrentHealth);
        }

    }

    public void ApplayPoison(float dmg)
    {
        if (_poisonTimer < 0)
        {
            TakeDamage(dmg);
            _poisonTimer = poisonCooldown;
        }
    }

    public virtual void Die()
    {
        //This method is meant to be overwrriten
        Debug.Log(transform.name + " died");

    }

}
