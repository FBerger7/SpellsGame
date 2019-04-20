using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MouseTracker
{
    private const float SPELL_CHANGE_COOLDOWN = 0.5f;

    public KeyCode leftSpellKey;
    public KeyCode rightSpellKey;
    public KeyCode deffensiveSpellKey;
    public KeyCode mobileSpellKey;
    public KeyCode changeSpellKey;

    private OffensiveSpellsModel model;
    private List<Tuple<int, int>> _spellQueue;
    private Dictionary<int, OffensiveSpell> _offensiveSpells;
    private Dictionary<int, MobileSpell> _mobileSpells;
    private SummonPowerShield _summonPowerShield;
    private int _currentPair = 0;
    private float _remainingPairChangeCooldown = SPELL_CHANGE_COOLDOWN;
    

    // Start is called before the first frame update
    void Start()
    {
        _spellQueue = new List<Tuple<int, int>>();
        model = new OffensiveSpellsModel();

        _summonPowerShield = gameObject.GetComponent<SummonPowerShield>();
        AddOffensiveSpells();
        AddMobileSpells();
        // inicjalizacja listy spelli tylko do testów, potem tego nie będzie
        // ------------------------------------------------------------------
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.FIRE_BREATH, OffensiveSpellsModel.BASIC_SPELL));
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
            _summonPowerShield.PerformAttack(model);
        }
        if (Input.GetKey(mobileSpellKey))
        {
            gameObject.GetComponent<Teleport>().PerformAttack(pointToLook);
        }
    }

    private void AddOffensiveSpells()
    {
        _offensiveSpells = new Dictionary<int, OffensiveSpell>();
        _offensiveSpells.Add(OffensiveSpellsModel.BASIC_SPELL, gameObject.GetComponent<BasicAttack>());
        _offensiveSpells.Add(OffensiveSpellsModel.SUMMON_WALL, gameObject.GetComponent<SummonWall>());
        _offensiveSpells.Add(OffensiveSpellsModel.FIRE_BREATH, gameObject.GetComponent<FireBreath>());
    }

    private void AddMobileSpells()
    {
        _mobileSpells = new Dictionary<int, MobileSpell>();
        _mobileSpells.Add(MobileSpellsModel.TELEPORT, gameObject.GetComponent<Teleport>());
    }
}
