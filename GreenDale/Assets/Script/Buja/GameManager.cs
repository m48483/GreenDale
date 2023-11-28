using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Day;
    private int Seasons;        // 계절 0 봄 1 여름 2 가을 3 겨울
    public bool Encyclopedia;   // 도감
    //public bool[] EncyclopediasList;    // 도감 목록(추후 개수 등... 상세하게 정해야 함)
    public string EncyclopediasList;    // 도감 목록(임시로 string 사용 배열 가능한지 알아봐야 함)
    public string Inventory;    // 아이템 코드 필요함

    public int Farming; // 농사스텟
    public int Fishing; // 낚시스탯
    public int Money;   // 재화

    // Dontdestroyed로 게임이 저장될 때마다(날짜가 변경될때마다)
    // 기존의 오브젝트가 삭제되고 사로 만들어지는 식으로 진행

    // 봄의 1일은 스크립트 새로 작성 요망
    void Start()
    {

    }

    public void nnn()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");
        Day = PlayerPrefs.GetInt("Day");
        Seasons = PlayerPrefs.GetInt("Seasons");

        // PlayerPrefs는 boolean 불가 f==0 t==1
        if (PlayerPrefs.GetInt("Encyclopedia") == 1)
        {
            Encyclopedia = true;
        }
        else if (PlayerPrefs.GetInt("Encyclopedia") == 0)
        {
            Encyclopedia = false;
        }

        /*
        // 목록 순서대로 ex "0 0 0 1 1 ..." 형태로 저장 (저장 공간 낭비 방지)
        string[] EncyclopediasList_str = PlayerPrefs.GetString("EncyclopediasList").Split(' ');
        for (int i = 0; i < EncyclopediasList.Length; i++)
        {
            if (EncyclopediasList_str[i] == "1")
            {
                EncyclopediasList[i] = true;
            }
            else if (EncyclopediasList_str[i] == "0")
            {
                EncyclopediasList[i] = false;
            }
        }
        */

        // 임시 사용 중
        EncyclopediasList = PlayerPrefs.GetString("EncyclopediasList");
        Inventory = PlayerPrefs.GetString("Inventory");

        Farming = PlayerPrefs.GetInt("Farming");
        Fishing = PlayerPrefs.GetInt("Fishing");
        Money = PlayerPrefs.GetInt("Money");

        // 플레이어 이름 저장하기
        Debug.Log(PlayerName);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("PlayerName", PlayerName);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetIntegerVariable("Day", Day);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetBooleanVariable("Encyclopedia", Encyclopedia);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("EncyclopediasList", EncyclopediasList);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("Inventory", Inventory);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetIntegerVariable("Farming", Farming);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetIntegerVariable("Fishing", Fishing);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetIntegerVariable("Money", Money);
    }

    public void nextDay()
    {
        if (Day <= 21)
        {
            Day++;
            Destroy(this);
        }
        else if(Day > 21)
        {
            Day = 1;
            if (Seasons <= 3)
            {
                Seasons++;
            }
            else if (Seasons > 3)
            {
                Seasons = 0;
            }
        }
        PlayerPrefs.SetInt("Day",Day);
        PlayerPrefs.SetInt("Seasons", Seasons);
    }
}
