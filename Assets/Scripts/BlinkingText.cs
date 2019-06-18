using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    private bool isUp = true;
    private float actual;
    private Color color;
    public float timerAlpha;


    void Start()
    {
        actual = 1.0f;
        color = this.GetComponent<Text>().color;
    }

    private void FixedUpdate()
    {
        if (isUp == true)
        {
            actual += Time.deltaTime * timerAlpha / 100.0f;
            if (actual > 1.0f)
            {
                actual = 1.0f;
                isUp = false;
            }
        }
        else
        {
            actual -= Time.deltaTime * timerAlpha / 100.0f;
            if (actual < 0.0f)
            {
                actual = 0.0f;
                isUp = true;
            }
        }
        this.GetComponent<Text>().color = new Color(color.r, color.g, color.b, actual);
    }
}
