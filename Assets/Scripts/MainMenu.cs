using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Rect GroupPosition;
    private string currentMenu = "main";
    public string line1;
    public string line2;
    public string line3;
    public string[] helpLines;
    public Texture helpButton;
    public Text blinkingText;
    private int startX = 10;
    private int startY = 10;
    private int secondBoxH = 1000;
    private int secondBoxW = 1000;
    private int labelOffset = 10;
    private int labelW = 1000;
    private int labelH = 50;
    private int buttonW = 500;
    private int buttonH = 100;
    private int buttonOffset = 20;
    private int infoW = 1000;
    private int infoH = 75;
    private int buttonHelpW = 80;
    private int buttonHelpH = 80;
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        if (currentMenu == "main")
        {
            style.fontSize = 68;
            style.normal.textColor = Color.white;
            GUI.BeginGroup(GroupPosition);
            GUI.Box(new Rect(startX, startY, Screen.width - 2 * startX, Screen.height - 2 * startY), "");

            GUI.Label(new Rect(Screen.width / 2 - infoW/2, 20, infoW, infoH), line1, style);
            GUI.Label(new Rect(Screen.width / 2 - infoW/2, 20 + infoH + 10, infoW, infoH), line2, style);
            GUI.Label(new Rect(Screen.width / 2 - 170, Screen.height / 2 - 75, 300, infoH), line3, style); //individual values
            if (GUI.Button(new Rect(Screen.width / 2 + 160, Screen.height / 2 - 80, buttonHelpW, buttonHelpH), helpButton)) //individual values
            {
                currentMenu = "help";
            }
            GUI.EndGroup();
            blinkingText.enabled = true;
        }
        if (currentMenu == "help")
        {
            style.fontSize = 19;
            style.normal.textColor = Color.white;
            GUI.BeginGroup(GroupPosition);
            GUI.Box(new Rect(Screen.width / 2 - secondBoxW /2, Screen.height / 2 - secondBoxH / 2, secondBoxW, secondBoxH), "");
            for (int i = 0; i < helpLines.Length; i++)
                GUI.Label(new Rect(Screen.width / 2 - labelW/2 + labelOffset, Screen.height / 2 - labelW/2 + (i + 1) * labelH, labelW - labelOffset*2, labelH), helpLines[i], style);
            if (GUI.Button(new Rect(Screen.width / 2 - buttonW/2, Screen.height - buttonH - buttonOffset, buttonW, buttonH), "POWRÓT"))
            {
                currentMenu = "main";
            }
            GUI.EndGroup();
            blinkingText.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && currentMenu == "main")
        {
            Application.LoadLevel(1);
        }
    }
}
