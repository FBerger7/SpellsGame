using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInterface : MonoBehaviour
{
    private int healthPoints;

    private int healingSpell;

    private int mobileSpell;

    private int parrySpell;

    private int mainSpellFirst;

    private int mainSpellSecond;

    public void setHealthPoints(int number) {
        healthPoints = number;
    }

    public void setHealingSpell(int number) {
        healingSpell = number;
    }

    public void setMobileSpell(int number) {
        mobileSpell = number;
    }

    public void setParrySpell(int number) {
        parrySpell = number;
    }

    public void setMainSpellFirst(int number) {
        mainSpellFirst = number;
    }

    public void setMainSpellSecond(int number) {
        mainSpellSecond = number;
    }

    public int getHealthPoints() {
        return healthPoints;
    }

    public int getHealingSpell() {
        return healingSpell;
    }

    public int getMobileSpell() {
        return mobileSpell;
    }

    public int getParrySpell() {
        return parrySpell;
    }

    public int getMainSpellFirst() {
        return mainSpellFirst;
    }

    public int getMainSpellSecond() {
        return mainSpellSecond;
    }

    private void OnGUI()
    {
        print("HealthPoints = "+ healthPoints);
    }
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
