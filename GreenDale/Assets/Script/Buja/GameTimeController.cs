using UnityEngine;
using UnityEngine.UI;
using System;
using Fungus;

public class GameTimeController : MonoBehaviour
{
    public Text clock;
    public Text date;
    public float gameMinutesPerRealMinute = 10f; // 1�п� �� ���� �带�� ���� (���� ����)

    private float gameTimeElapsed = 0f; // ������ ������ ���� ���� ���� �ð�

    public GameObject panel;
    Image img;

    int Day = 0;
    int Seasons = 0;

    public Flowchart flowchart;

    void Start()
    {
        // ������ ������ �ð��� ���� �ð����� �ʱ�ȭ
        DateTime currentTime = DateTime.Now;
        gameTimeElapsed = (float)(currentTime.Hour * 60 + currentTime.Minute) / gameMinutesPerRealMinute;
        
        img = panel.GetComponent<Image>();

        Day = PlayerPrefs.GetInt("Day");
        Seasons = PlayerPrefs.GetInt("Seasons");

        switch (Seasons)
        {
            case 0:
                date.text = "�� " + Day + "��";
                break;
            case 1:
                date.text = "���� " + Day + "��";
                break;
            case 2:
                date.text = "���� " + Day + "��";
                break;
            case 3:
                date.text = "�ܿ� "+ Day+"��";
                break;
        }
    }

    public void oooooooo()
    {
        gameMinutesPerRealMinute = 30000f;
    }
    public void nnnnnnnnnnnnnnnnnn()
    {
        flowchart.ExecuteBlock("save");
    }
    public void MMM()
    {
        PlayerPrefs.SetInt("Day", 5);
    }
    void Update()
    {
        // ���� �ð� ������Ʈ
        gameTimeElapsed += Time.deltaTime / 60 * (gameMinutesPerRealMinute / 10); // 1�п� ������ �и�ŭ ����

        // ���� �ð��� ��, ������ ��ȯ
        int gameHours = Mathf.FloorToInt(gameTimeElapsed / 60);
        int gameMinutes = (Mathf.FloorToInt(gameTimeElapsed % 60)) * 10;

        // ���� �ð��� ���� 6�ú��� �� 11�� 59�б����� ����
        if (gameHours < 6 || (gameHours == 23 && gameMinutes > 50))
        {
            // ���� �ð��� 6:00���� ����
            gameHours = 6;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }
        else if (gameMinutes >= 60){
            gameHours++;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }

        // �ð��뺰 �� ������ 
        if (gameHours >= 18 && gameHours < 22)
        {
            img.color = new Color(255 / 255f, 98 / 255f, 0 / 56f, 56 / 255f);
        }
        else if (gameHours >= 22 && gameHours < 24)
        {
            img.color = new Color(0 / 255f, 0 / 255f, 0 / 56f, 110 / 255f);
        }
        else
        {
            img.color = new Color(255 / 255f, 0 / 255f, 0 / 56f, 0 / 255f);
        }

        // ���⿡�� ���� �ð��� Ȱ���Ͽ� ���� ������ �ʿ��� �۾� ����
        // ���� ���, ���� �ð��� ���� �̺�Ʈ �߻��̳� ���� �۾� ���� ���� ���⿡ �߰��� �� �ֽ��ϴ�.

        clock.text = gameHours.ToString("00") + ":" + gameMinutes.ToString("00");
    }
}
