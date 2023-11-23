using UnityEngine;
using System;

public class GameTimeController : MonoBehaviour
{
    public float gameMinutesPerRealMinute = 10f; // 1�п� �� ���� �带�� ���� (���� ����)

    private float gameTimeElapsed = 0f; // ������ ������ ���� ���� ���� �ð�

    void Start()
    {
        // ������ ������ �ð��� ���� �ð����� �ʱ�ȭ
        DateTime currentTime = DateTime.Now;
        gameTimeElapsed = (float)(currentTime.Hour * 60 + currentTime.Minute) / gameMinutesPerRealMinute;
    }

    void Update()
    {
        // ���� �ð� ������Ʈ
        gameTimeElapsed += Time.deltaTime / 60 * gameMinutesPerRealMinute; // 1�п� ������ �и�ŭ ����

        // ���� �ð��� ��, ������ ��ȯ
        int gameHours = Mathf.FloorToInt(gameTimeElapsed / 60);
        int gameMinutes = Mathf.FloorToInt(gameTimeElapsed % 60);

        // ���� �ð��� ���� 6�ú��� �� 11�� 59�б����� ����
        if (gameHours < 6 || (gameHours == 23 && gameMinutes > 59))
        {
            // ���� �ð��� 6:00���� ����
            gameHours = 6;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }

        // ���⿡�� ���� �ð��� Ȱ���Ͽ� ���� ������ �ʿ��� �۾� ����
        // ���� ���, ���� �ð��� ���� �̺�Ʈ �߻��̳� ���� �۾� ���� ���� ���⿡ �߰��� �� �ֽ��ϴ�.

        // �ֿܼ� ���� ���� �ð� ��� (�׽�Ʈ��)
        Debug.Log("���� ���� �ð�: " + gameHours.ToString("00") + ":" + gameMinutes.ToString("00"));
    }
}
