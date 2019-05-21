using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MouseTracker
{
    public KeyCode leftSpellKey;
    public KeyCode rightSpellKey;
    public KeyCode deffensiveSpellKey;
    public KeyCode mobileSpellKey;
    public KeyCode changeOffensiveSpellKey;
    public KeyCode changeMobileSpellKey;
    public CharacterInterface characterInterface;

    private OffensiveSpellsModel _model;
    private List<Tuple<int, int>> _spellQueue;
    private Dictionary<int, BaseSpell> _offensiveSpells;
    private Dictionary<int, BaseSpell> _mobileSpells;
    private SummonPowerShield _summonPowerShield;
    private int _currentOffensiveSpellsPair = 0;
    private int _currentMobileSpell = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
        _spellQueue = new List<Tuple<int, int>>();
        _model = new OffensiveSpellsModel();

        _summonPowerShield = gameObject.GetComponent<SummonPowerShield>();
        AddOffensiveSpells();
        AddMobileSpells();
        // inicjalizacja listy spelli tylko do testów, potem tego nie będzie
        // ------------------------------------------------------------------
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.PILLARRISE, OffensiveSpellsModel.FIRE_BREATH));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.FIRE_BREATH, OffensiveSpellsModel.BASIC_SPELL));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.BASIC_SPELL, OffensiveSpellsModel.SLIME_BOMB));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.RAILGUN, OffensiveSpellsModel.BASIC_SPELL));
        // ------------------------------------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouse();

        HandleSpellChange();

        HandleOffensiveSpells();

        HandleDeffensiveSpell();

        HandleMobileSpell();
    }

    private void HandleSpellChange()
    {
        if (Input.GetKeyDown(changeOffensiveSpellKey))
        {
            _currentOffensiveSpellsPair = (_currentOffensiveSpellsPair + 1) % _spellQueue.Count;
            characterInterface.SetMainSpellFirst(_spellQueue[_currentOffensiveSpellsPair].Item1);
            characterInterface.SetMainSpellSecond(_spellQueue[_currentOffensiveSpellsPair].Item2);
        }

        if (Input.GetKeyDown(changeMobileSpellKey))
        {
            _currentMobileSpell = (_currentMobileSpell + 1) % _mobileSpells.Count;
            characterInterface.SetMobileSpell(_currentMobileSpell);
        }
    }

    private void HandleOffensiveSpells()
    {
        if (Input.GetKey(leftSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentOffensiveSpellsPair].Item1].PerformAttack(pointToLook, false);
        }
        if (Input.GetKeyUp(leftSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentOffensiveSpellsPair].Item1].EndAttack();
        }

        if (Input.GetKey(rightSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentOffensiveSpellsPair].Item2].PerformAttack(pointToLook, false);
        }
        if (Input.GetKeyUp(leftSpellKey))
        {
            _offensiveSpells[_spellQueue[_currentOffensiveSpellsPair].Item2].EndAttack();
        }
    }

    private void HandleDeffensiveSpell()
    {
        if (Input.GetKey(deffensiveSpellKey))
        {
            _summonPowerShield.PerformAttack(_model);
        }
    }

    private void HandleMobileSpell()
    {
        if (Input.GetKey(mobileSpellKey))
        {
            _mobileSpells[_currentMobileSpell].PerformAttack(pointToLook, false);
        }

        if (Input.GetKeyUp(mobileSpellKey))
        {
            _mobileSpells[_currentMobileSpell].EndAttack();
        }
    }

    private void AddOffensiveSpells()
    {

        _offensiveSpells = new Dictionary<int, BaseSpell>();
        _offensiveSpells.Add(OffensiveSpellsModel.SLIME_BOMB, gameObject.GetComponent<SlimeBomb>());
        _offensiveSpells.Add(OffensiveSpellsModel.BASIC_SPELL, gameObject.GetComponent<BasicAttack>());
        _offensiveSpells.Add(OffensiveSpellsModel.SUMMON_WALL, gameObject.GetComponent<SummonWall>());
        _offensiveSpells.Add(OffensiveSpellsModel.FIRE_BREATH, gameObject.GetComponent<FireBreath>());
        _offensiveSpells.Add(OffensiveSpellsModel.RAILGUN, gameObject.GetComponent<Railgun>());
        _offensiveSpells.Add(OffensiveSpellsModel.PILLARRISE, gameObject.GetComponent<PillarRise>());
    }

    private void AddMobileSpells()
    {
        _mobileSpells = new Dictionary<int, BaseSpell>();
        _mobileSpells.Add(MobileSpellsModel.JUMP, gameObject.GetComponent<Jump>());
        _mobileSpells.Add(MobileSpellsModel.RUN, gameObject.GetComponent<Run>());
        _mobileSpells.Add(MobileSpellsModel.TELEPORT, gameObject.GetComponent<Teleport>());
    }
}
