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

    public Flowchart flowchart; // 대화가 있는 Fungus Flowchart를 참조합니다.


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
        // 이름이 2~6 글자의 한글로 구성되어 있는지 확인
        return System.Text.RegularExpressions.Regex.IsMatch(name, "^[가-힣]{2,6}$");
    }

    public void playBtnOnClick()
    {
        OnNameInputChanged();
    }
}
