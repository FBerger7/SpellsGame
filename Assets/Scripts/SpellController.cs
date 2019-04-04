using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private const float ACTIVATION_COOLDOWN = 0.5f;

    public const int BASIC_SPELL = 0;
    public const int SUMMON = 1;



    public KeyCode leftSpellKey;
    public KeyCode rightSpellKey;
    public KeyCode changeSpellKey;

    private List<Tuple<int, int>> _spellQueue;
    private int _currentPair;
    private List<BaseSpell> _offensiveSpells;
    private float _remainingActivationCooldown = ACTIVATION_COOLDOWN;


    // Może do tego wrócimy (nie usuwać jeszcze)
    //public KeyCode basicAttackActivationKey;
    //public KeyCode summonActivationKey;
    //private Dictionary<KeyCode, BaseSpell> spells;
    //private KeyCode _currentSpell;


    // Start is called before the first frame update
    void Start()
    {
        _spellQueue = new List<Tuple<int, int>>();
        _offensiveSpells = gameObject.GetComponent<OffensiveSpellsModel>().offensiveSpells;
        // inicjalizacja listy spelli tylko do testów, potem tego nie będzie
        // ------------------------------------------------------------------
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.BASIC_SPELL, OffensiveSpellsModel.SUMMON));
        _spellQueue.Add(new Tuple<int, int>(OffensiveSpellsModel.SUMMON, OffensiveSpellsModel.BASIC_SPELL));
        // ------------------------------------------------------------------
        _currentPair = 0;

        // Może do tego wrócimy (nie usuwać jeszcze)
        //_currentSpell = KeyCode.None;
        //spells = new Dictionary<KeyCode, BaseSpell>();
        //AddSpells();
    }

    // Update is called once per frame
    void Update()
    {
        _remainingActivationCooldown -= Time.deltaTime;

        if (Input.GetKey(changeSpellKey))
        {
            if (_remainingActivationCooldown <= 0)
            {
                _remainingActivationCooldown = ACTIVATION_COOLDOWN;
                _currentPair = (_currentPair + 1) % _spellQueue.Count;
            }
        }
        if (Input.GetKey(leftSpellKey))
        {
            _offensiveSpells[_spellQueue[0].Item1].PerformAttack();
        }
        if (Input.GetKey(rightSpellKey))
        {
            _offensiveSpells[_spellQueue[0].Item2].PerformAttack();
        }

        // Może do tego wrócimy (nie usuwać jeszcze)
        //if (Input.GetKey(basicAttackActivationKey))
        //{
        //    ManageSpells(basicAttackActivationKey);
        //}
        //if (Input.GetKey(summonActivationKey))
        //{
        //    ManageSpells(summonActivationKey);
        //}
    }

    // Może do tego wrócimy (nie usuwać jeszcze)
    //private void AddSpells()
    //{
    //    spells.Add(basicAttackActivationKey, gameObject.GetComponent<BasicAttack>());
    //    spells.Add(summonActivationKey, gameObject.GetComponent<Summon>());
    //}


    //Może do tego wrócimy(nie usuwać jeszcze)
    //private void ManageSpells(KeyCode chosenSpell)
    //{
    //    if (_remainingActivationCooldown <= 0)
    //    {
    //        _remainingActivationCooldown = ACTIVATION_COOLDOWN;
    //        if (_currentSpell == chosenSpell)
    //        {
    //            spells[_currentSpell].deactivate();
    //            _currentSpell = KeyCode.None;
    //            return;
    //        }
    //        if (_currentSpell != KeyCode.None)
    //        {
    //            spells[_currentSpell].deactivate();
    //        }
    //        spells[chosenSpell].activate();
    //        _currentSpell = chosenSpell;
    //    }
    //}
}
