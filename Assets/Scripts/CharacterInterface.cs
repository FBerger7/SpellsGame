using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInterface : MonoBehaviour
{
    private int index = 0;

    private int healthPoints;

    private int healingSpell;

    private int mobileSpell;

    private int parrySpell;

    private int mainSpellFirst;

    private int mainSpellSecond;

    public Image healthPointsTexture;

    public Sprite[] healthSprites = new Sprite[4];

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
        //healthPointsTexture.sprite = healthSprites[index];
    }

    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKeyDown(KeyCode.P))
        {
            healthPointsTexture.sprite = healthSprites[index];
            index++;
            if (index == 4)
                index = 0;
        }
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
