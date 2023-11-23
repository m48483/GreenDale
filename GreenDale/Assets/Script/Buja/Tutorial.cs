using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tutorial : MonoBehaviour
{
    public Flowchart flowchart; // 대화가 있는 Fungus Flowchart를 참조합니다.

    // Start is called before the first frame update
    void Start()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");

        // 플레이어 이름 저장하기
        Debug.Log(PlayerName);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("PlayerName", PlayerName);
    }

    public void playGame()
    {
        // 날짜
        int day = flowchart.GetIntegerVariable("Day");
        day++;
        PlayerPrefs.SetInt("Day", day);

        PlayerPrefs.SetInt("Relationship", flowchart.GetIntegerVariable("Relationship"));
    }
}
