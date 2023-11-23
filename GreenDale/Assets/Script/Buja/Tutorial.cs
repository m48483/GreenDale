using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tutorial : MonoBehaviour
{
    public Flowchart flowchart; // ��ȭ�� �ִ� Fungus Flowchart�� �����մϴ�.

    // Start is called before the first frame update
    void Start()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");

        // �÷��̾� �̸� �����ϱ�
        Debug.Log(PlayerName);
        GameObject.Find("Variables").GetComponent<Flowchart>().SetStringVariable("PlayerName", PlayerName);
    }

    public void playGame()
    {
        // ��¥
        int day = flowchart.GetIntegerVariable("Day");
        day++;
        PlayerPrefs.SetInt("Day", day);

        PlayerPrefs.SetInt("Relationship", flowchart.GetIntegerVariable("Relationship"));
    }
}
