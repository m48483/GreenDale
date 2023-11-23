using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Nickname : MonoBehaviour
{
    public Button playBtn;
    public InputField nameInputField;
    public string playerName;

    public Flowchart flowchart; // ¥Î»≠∞° ¿÷¥¬ Fungus Flowchart∏¶ ¬¸¡∂«’¥œ¥Ÿ.


    private void OnNameInputChanged()
    {
        playerName = nameInputField.text;

        if (IsNameValid(playerName))
        {
            flowchart.ExecuteBlock("ValidNameBlock");
        }
        else
        {
            flowchart.ExecuteBlock("InvalidNameBlock");
        }
    }
    public void OnClickYes()
    {

        string n = flowchart.GetStringVariable("PlayerName");
        Debug.Log(n);
        PlayerPrefs.SetString("PlayerName", flowchart.GetStringVariable("PlayerName"));
    }

    private bool IsNameValid(string name)
    {
        // ¿Ã∏ß¿Ã 2~6 ±€¿⁄¿« «—±€∑Œ ±∏º∫µ«æÓ ¿÷¥¬¡ˆ »Æ¿Œ
        return System.Text.RegularExpressions.Regex.IsMatch(name, "^[∞°-∆R]{2,6}$");
    }

    public void playBtnOnClick()
    {
        OnNameInputChanged();
    }
}
