using UnityEngine;
using UnityEngine.UI;

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
    public GameObject enemyHealthContainer;
    private PlayerAnimation _playerAnimation;
    private Animator _anim;

    [SerializeField]
    protected float _poisonTimer;
    protected string characterName;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        _playerAnimation = new PlayerAnimation();
        _anim = GetComponentInChildren<Animator>();
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
            enemyHealthContainer.SetActive(false);
            Die();
        }
        else
        {
            if (characterInterface)
                characterInterface.SetHealthPoints((int)CurrentHealth);
            else if(enemyHealthContainer)
            {
                enemyHealthContainer.SetActive(true);
                Slider enemyHealthBar = (Slider)enemyHealthContainer.GetComponentInChildren(typeof(Slider));
                enemyHealthBar.value = CurrentHealth / maxHealth;
                Text enemyNameText = (Text)enemyHealthContainer.GetComponentInChildren(typeof(Text));
                enemyNameText.text = characterName;
            }   
        }

    }

    public void Heal(float healValue)
    {
        if (CurrentHealth != maxHealth)
        {
            CurrentHealth += healValue;
            Debug.Log(transform.name + healValue + " healed.");
            if (CurrentHealth > maxHealth)
                CurrentHealth = maxHealth;
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
        if(transform.name == "Player")
            _playerAnimation.DieAnimation(ref _anim);
        Debug.Log(transform.name + " died");

    }

}
