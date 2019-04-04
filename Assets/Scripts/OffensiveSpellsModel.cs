using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveSpellsModel : MonoBehaviour
{
    public const int BASIC_SPELL = 0;
    public const int SUMMON = 1;

    public List<BaseSpell> offesiveSpells;

    // Start is called before the first frame update
    void Start()
    {
        offesiveSpells = new List<BaseSpell>();
        offesiveSpells.Add(gameObject.GetComponent<BasicAttack>());
        offesiveSpells.Add(gameObject.GetComponent<Summon>());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
