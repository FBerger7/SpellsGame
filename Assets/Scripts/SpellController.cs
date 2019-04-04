using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private const float ACTIVATION_COOLDOWN = 0.5f;

    public const int BASIC_SPELL = 0;
    public const int SUMMON = 1;

    public List<BaseSpell> offensiveSpells;

    public KeyCode basicAttackActivationKey;
    public KeyCode summonActivationKey;

    public KeyCode leftSpellKey;
    public KeyCode rightSpellKey;
    public KeyCode changeSpellKey;

    private List<Tuple<int, int>> _spellQueue;
    private int _currentPair;

    private Dictionary<KeyCode, BaseSpell> spells;
    private float _remainingActivationCooldown = ACTIVATION_COOLDOWN;
    private KeyCode _currentSpell;
    //private OffensiveSpellsModel offensiveSpells;

    // Start is called before the first frame update
    void Start()
    {
        offensiveSpells = new List<BaseSpell>();
        offensiveSpells.Add(gameObject.GetComponent<BasicAttack>());
        offensiveSpells.Add(gameObject.GetComponent<Summon>());
        _spellQueue = new List<Tuple<int, int>>();
        //offensiveSpells = gameObject.GetComponent<OffensiveSpellsModel>();
        // inicjalizacja listy spelli tylko do testów, potem tego nie będzie
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.BASIC_SPELL, OffensiveSpellsModel.SUMMON));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.SUMMON, OffensiveSpellsModel.BASIC_SPELL));
        //
        _currentPair = 0;
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
        if (Input.GetKey(leftSpellKey))
        {
            offensiveSpells[_spellQueue[0].Item1].PerformAttack();
            //_spellQueue[0].Item1.PerformAttack();
        }
        if (Input.GetKey(rightSpellKey))
        {
            offensiveSpells[_spellQueue[0].Item2].PerformAttack();
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
