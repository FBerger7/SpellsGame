using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpellsModel : MonoBehaviour
{
    public const int BASIC_SPELL = 0;
    public const int SUMMON = 1;

    public List<BaseSpell> offensiveSpells;

    // Start is called before the first frame update
    void Start()
    {
        offensiveSpells = new List<BaseSpell>();
        offensiveSpells.Add(gameObject.GetComponent<BasicAttack>());
        offensiveSpells.Add(gameObject.GetComponent<Summon>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
