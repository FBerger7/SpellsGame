using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private const float ACTIVATION_COOLDOWN = 0.5f;

    public KeyCode basicAttackActivationKey;
    public KeyCode summonActivationKey;

    private KeyCode _leftSpellKey;
    private KeyCode _rightSpellKey;


    private Dictionary<KeyCode, BaseSpell> spells;
    private float _remainingActivationCooldown = ACTIVATION_COOLDOWN;
    private KeyCode _currentSpell;
    private OffensiveSpellsModel offensiveSpells;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpell = KeyCode.None;
        spells = new Dictionary<KeyCode, BaseSpell>();
        AddSpells();
    }

    // Update is called once per frame
    void Update()
    {
        _remainingActivationCooldown -= Time.deltaTime;
        if (Input.GetKey(basicAttackActivationKey))
        {
            ManageSpells(basicAttackActivationKey);
        }

        if (Input.GetKey(summonActivationKey))
        {
            ManageSpells(summonActivationKey);
        }
    }

    private void AddSpells()
    {
        spells.Add(basicAttackActivationKey, gameObject.GetComponent<BasicAttack>());
        spells.Add(summonActivationKey, gameObject.GetComponent<Summon>());
    }

    private void ManageSpells(KeyCode chosenSpell)
    {
        if (_remainingActivationCooldown <= 0)
        {
            _remainingActivationCooldown = ACTIVATION_COOLDOWN;
            if (_currentSpell == chosenSpell)
            {
                spells[_currentSpell].deactivate();
                _currentSpell = KeyCode.None;
                return;
            }
            if (_currentSpell != KeyCode.None)
            {
                spells[_currentSpell].deactivate();
            }
            spells[chosenSpell].activate();
            _currentSpell = chosenSpell;
        }
    }
}
