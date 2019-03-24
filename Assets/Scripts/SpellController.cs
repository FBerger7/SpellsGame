using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private const int BASIC_ATTACK = 0;
    private const int SUMMON = 1;
    private const float ACTIVATION_COOLDOWN = 0.5f;

    public KeyCode basicAttackActivationKey;
    public KeyCode summonActivationKey;

    private List<BaseSpell> spells;
    private Dictionary<int, KeyCode> spellKeyCodes;
    private float _remainingActivationCooldown = ACTIVATION_COOLDOWN;
    private int _currentSpell;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpell = -1;
        spells = new List<BaseSpell>();
        spellKeyCodes = new Dictionary<int, KeyCode>();
        addSpells();
    }

    // Update is called once per frame
    void Update()
    {
        _remainingActivationCooldown -= Time.deltaTime;
        if (Input.GetKey(spellKeyCodes[BASIC_ATTACK]))
        {
            manageSpells(BASIC_ATTACK);
        }

        if (Input.GetKey(spellKeyCodes[SUMMON]))
        {
            manageSpells(SUMMON);
        }
    }

    private void addSpells()
    {
        spells.Add(gameObject.GetComponent<BasicAttack>());
        spells.Add(gameObject.GetComponent<Summon>());

        spellKeyCodes.Add(BASIC_ATTACK, basicAttackActivationKey);
        spellKeyCodes.Add(SUMMON, summonActivationKey);
    }

    private void manageSpells(int chosenSpell)
    {
        if (_remainingActivationCooldown <= 0)
        {
            _remainingActivationCooldown = ACTIVATION_COOLDOWN;
            if (_currentSpell == chosenSpell)
            {
                spells[_currentSpell].deactivate();
                _currentSpell = -1;
                return;
            }
            if (_currentSpell != -1)
            {
                spells[_currentSpell].deactivate();
            }
            spells[chosenSpell].activate();
            _currentSpell = chosenSpell;
        }
    }
}
