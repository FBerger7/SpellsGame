using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MouseTracker
{
    private const float SPELL_CHANGE_COOLDOWN = 0.5f;

    public KeyCode leftSpellKey;
    public KeyCode rightSpellKey;
    public KeyCode deffensiveSpellKey;
    public KeyCode changeSpellKey;

    private List<Tuple<int, int>> _spellQueue;
    private Dictionary<int, BaseSpell> _offensiveSpells;
    private SummonPowerShield _summonPowerShield;
    private int _currentPair = 0;
    private float _remainingPairChangeCooldown = SPELL_CHANGE_COOLDOWN;

    // Start is called before the first frame update
    void Start()
    {
        _spellQueue = new List<Tuple<int, int>>();
        _summonPowerShield = gameObject.GetComponent<SummonPowerShield>();
        AddOffensiveSpells();
        // inicjalizacja listy spelli tylko do testów, potem tego nie będzie
        // ------------------------------------------------------------------
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.BASIC_SPELL, OffensiveSpellsModel.SUMMON_WALL));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.SUMMON_WALL, OffensiveSpellsModel.BASIC_SPELL));
        // ------------------------------------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        _remainingPairChangeCooldown -= Time.deltaTime;

        if (Input.GetKey(changeSpellKey))
        {
            if (_remainingPairChangeCooldown <= 0)
            {
                _remainingPairChangeCooldown = SPELL_CHANGE_COOLDOWN;
                _currentPair = (_currentPair + 1) % _spellQueue.Count;
            }
        }
        if (Input.GetKey(leftSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentPair].Item1].PerformAttack(pointToLook);
        }
        if (Input.GetKey(rightSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentPair].Item2].PerformAttack(pointToLook);
        }
        if (Input.GetKey(deffensiveSpellKey))
        {
            _summonPowerShield.PerformAttack(pointToLook);
        }
    }

    private void AddOffensiveSpells()
    {
        _offensiveSpells = new Dictionary<int, BaseSpell>();
        _offensiveSpells.Add(OffensiveSpellsModel.BASIC_SPELL, gameObject.GetComponent<BasicAttack>());
        _offensiveSpells.Add(OffensiveSpellsModel.SUMMON_WALL, gameObject.GetComponent<SummonWall>());
    }
}
