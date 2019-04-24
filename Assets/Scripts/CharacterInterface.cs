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

    public Image mainSpellFirstTexture;

    public Image mainSpellSecondTexture;

    public Image healingSpellTexture;

    public Image parrySpellTexture;

    public Image mobileSpellTexture;

    public Text healthPointsText;

    public Sprite[] healthSprites;

    public Sprite[] mainSpellSprites;

    public Sprite[] healingSpellSprites;

    public Sprite[] mobileSpellSprites;

    public Sprite[] parrySpellSprites;

    public void setHealthPoints(int number) {
        if (number > -1 && number < 101)
            healthPoints = number;
        healthPointsTexture.sprite = healthSprites[getIndexOfSprite()];
        healthPointsText.text = "HP: " + healthPoints + "%";
    }

    public void setHealingSpell(int number) {
        if (number > -1 && number < healingSpellSprites.Length)
            healingSpell = number;
        healingSpellTexture.sprite = healingSpellSprites[healingSpell];
    }

    public void setMobileSpell(int number) {
        if (number > -1 && number < mobileSpellSprites.Length)
            mobileSpell = number;
        mobileSpellTexture.sprite = mobileSpellSprites[mobileSpell];
    }

    public void setParrySpell(int number) {
        if (number > -1 && number < parrySpellSprites.Length)
            parrySpell = number;
        parrySpellTexture.sprite = parrySpellSprites[parrySpell];
    }

    public void setMainSpellFirst(int number) {
        if (number > -1 && number < mainSpellSprites.Length)
            mainSpellFirst = number;
        mainSpellFirstTexture.sprite = mainSpellSprites[mainSpellFirst];
    }

    public void setMainSpellSecond(int number) {
        if (number > -1 && number < mainSpellSprites.Length)
            mainSpellSecond = number;
        mainSpellSecondTexture.sprite = mainSpellSprites[mainSpellSecond];
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
        mainSpellFirst = 0;
        mainSpellSecond = 1;
        healingSpell = 0;
        parrySpell = 0;
        mobileSpell = 0;
        mainSpellFirstTexture.sprite = mainSpellSprites[mainSpellFirst];
        mainSpellSecondTexture.sprite = mainSpellSprites[mainSpellSecond];
        healingSpellTexture.sprite = healingSpellSprites[healingSpell];
        parrySpellTexture.sprite = parrySpellSprites[parrySpell];
        mobileSpellTexture.sprite = mobileSpellSprites[mobileSpell];
        healthPointsTexture.sprite = healthSprites[getIndexOfSprite()];
    }

    void Update()
    {
        //Press P to change the health points
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (healthPoints > 0)
                healthPoints--;
            healthPointsText.text = "HP:  " + healthPoints + "%";
            healthPointsTexture.sprite = healthSprites[getIndexOfSprite()];
        }

        //Press L to change the main spells
        if (Input.GetKeyDown(KeyCode.L))
        {
            mainSpellFirst++;
            mainSpellSecond++;
            if (mainSpellFirst == mainSpellSprites.Length)
                mainSpellFirst = 0;
            if (mainSpellSecond == mainSpellSprites.Length)
                mainSpellSecond = 0;
            mainSpellFirstTexture.sprite = mainSpellSprites[mainSpellFirst];
            mainSpellSecondTexture.sprite = mainSpellSprites[mainSpellSecond];
        }

        //Press P to change the parry spells
        if (Input.GetKeyDown(KeyCode.P))
        {
            parrySpell++;
            if (parrySpell == parrySpellSprites.Length)
                parrySpell = 0;
            parrySpellTexture.sprite = parrySpellSprites[parrySpell];
        }

        //Press K to change the mobile spells
        if (Input.GetKeyDown(KeyCode.K))
        {
            mobileSpell++;
            if (mobileSpell == mobileSpellSprites.Length)
                mobileSpell = 0;
            mobileSpellTexture.sprite = mobileSpellSprites[mobileSpell];
        }

        //Press O to change the healing spells
        if (Input.GetKeyDown(KeyCode.O))
        {
            healingSpell++;
            if (healingSpell == healingSpellSprites.Length)
                healingSpell = 0;
            healingSpellTexture.sprite = healingSpellSprites[healingSpell];
        }
    }
    
}
