using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInterface : MonoBehaviour
{

    private int healthPoints;

    private int healingSpell;

    private int mobileSpell;

    private int parrySpell;

    private int mainSpellFirst;

    private int mainSpellSecond;

    public Image healthPointsTexture;

    public Text healthPointsText;

    public Sprite[] healthSprites;

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

    private int getIndexOfSprite() {
        int result = healthPoints/10;
        if (healthPoints % 10 != 0)
            result++;
        return result;
    }

    void Start()
    {
        setHealthPoints(100);
        healthPointsText.text = "HP: " + healthPoints + "%";
        healthPointsTexture.sprite = healthSprites[getIndexOfSprite()];
    }

    void Update()
    {
        //Press P to change the health points
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (healthPoints > 0)
                healthPoints--;
            healthPointsText.text = "HP:  " + healthPoints + "%";
            healthPointsTexture.sprite = healthSprites[getIndexOfSprite()];
        }
    }
    
}
