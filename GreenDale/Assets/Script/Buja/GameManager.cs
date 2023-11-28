using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Day;
    private int Seasons;        // ���� 0 �� 1 ���� 2 ���� 3 �ܿ�
    public bool Encyclopedia;   // ����
    //public bool[] EncyclopediasList;    // ���� ���(���� ���� ��... ���ϰ� ���ؾ� ��)
    public string EncyclopediasList;    // ���� ���(�ӽ÷� string ��� �迭 �������� �˾ƺ��� ��)
    public string Inventory;    // ������ �ڵ� �ʿ���

    public int Farming; // ��罺��
    public int Fishing; // ���ý���
    public int Money;   // ��ȭ

    // Dontdestroyed�� ������ ����� ������(��¥�� ����ɶ�����)
    // ������ ������Ʈ�� �����ǰ� ��� ��������� ������ ����

    // ���� 1���� ��ũ��Ʈ ���� �ۼ� ���
    void Start()
    {

    }

    public void nnn()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");
        Day = PlayerPrefs.GetInt("Day");
        Seasons = PlayerPrefs.GetInt("Seasons");

        // PlayerPrefs�� boolean �Ұ� f==0 t==1
        if (PlayerPrefs.GetInt("Encyclopedia") == 1)
        {
            Encyclopedia = true;
        }
        else if (PlayerPrefs.GetInt("Encyclopedia") == 0)
        {
            Encyclopedia = false;
        }

        /*
        // ��� ������� ex "0 0 0 1 1 ..." ���·� ���� (���� ���� ���� ����)
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

        // �ӽ� ��� ��
        EncyclopediasList = PlayerPrefs.GetString("EncyclopediasList");
        Inventory = PlayerPrefs.GetString("Inventory");

        Farming = PlayerPrefs.GetInt("Farming");
        Fishing = PlayerPrefs.GetInt("Fishing");
        Money = PlayerPrefs.GetInt("Money");

        // �÷��̾� �̸� �����ϱ�
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
