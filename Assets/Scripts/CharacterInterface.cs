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

    public void SetHealthPoints(int number) {
        healthPoints = number;
        if (healthPoints < 0)
            healthPoints = 0;
        if (healthPoints > 100)
            healthPoints = 100;
        healthPointsTexture.sprite = healthSprites[GetIndexOfSprite()];
        healthPointsText.text = "HP: " + healthPoints + "%";
    }

    public void SetHealingSpell(int number) {
        if (number > -1 && number < healingSpellSprites.Length)
            healingSpell = number;
        healingSpellTexture.sprite = healingSpellSprites[healingSpell];
    }

    public void SetMobileSpell(int number) {
        if (number > -1 && number < mobileSpellSprites.Length)
            mobileSpell = number;
        mobileSpellTexture.sprite = mobileSpellSprites[mobileSpell];
    }

    public void SetParrySpell(int number) {
        if (number > -1 && number < parrySpellSprites.Length)
            parrySpell = number;
        parrySpellTexture.sprite = parrySpellSprites[parrySpell];
    }

    public void SetMainSpellFirst(int number) {
        if (number > -1 && number < mainSpellSprites.Length)
            mainSpellFirst = number;
        mainSpellFirstTexture.sprite = mainSpellSprites[mainSpellFirst];
    }

    public void SetMainSpellSecond(int number) {
        if (number > -1 && number < mainSpellSprites.Length)
            mainSpellSecond = number;
        mainSpellSecondTexture.sprite = mainSpellSprites[mainSpellSecond];
    }

    public int GetHealthPoints() {
        return healthPoints;
    }

    public int GetHealingSpell() {
        return healingSpell;
    }

    public int GetMobileSpell() {
        return mobileSpell;
    }

    public int GetParrySpell() {
        return parrySpell;
    }

    public int GetMainSpellFirst() {
        return mainSpellFirst;
    }

    public int GetMainSpellSecond() {
        return mainSpellSecond;
    }

    private int GetIndexOfSprite() {
        int result = healthPoints/10;
        if (healthPoints % 10 != 0)
            result++;
        return result;
    }

    void Start()
    {
        SetHealthPoints(100);
        healthPointsText.text = "HP: " + healthPoints + "%";
        mainSpellFirst = 5;
        mainSpellSecond = 1;
        healingSpell = 0;
        parrySpell = 0;
        mobileSpell = 0;
        mainSpellFirstTexture.sprite = mainSpellSprites[mainSpellFirst];
        mainSpellSecondTexture.sprite = mainSpellSprites[mainSpellSecond];
        healingSpellTexture.sprite = healingSpellSprites[healingSpell];
        parrySpellTexture.sprite = parrySpellSprites[parrySpell];
        mobileSpellTexture.sprite = mobileSpellSprites[mobileSpell];
        healthPointsTexture.sprite = healthSprites[GetIndexOfSprite()];
    }
    
}
