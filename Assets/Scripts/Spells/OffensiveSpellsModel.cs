using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpellsModel
{
    public const int BASIC_SPELL = 0;
    public const int SUMMON_WALL = 1;
    public const int FIRE_BREATH = 2;

    private SortedSet<int> _acknowledgedSpells;

    public OffensiveSpellsModel()
    {
        _acknowledgedSpells = new SortedSet<int>();
    }

    public void AcknowledgeSpell(int spellId)
    {
        if (!_acknowledgedSpells.Contains(spellId))
            _acknowledgedSpells.Add(spellId);
    }
}
