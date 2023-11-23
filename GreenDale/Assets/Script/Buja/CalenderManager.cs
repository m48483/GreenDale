using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CalenderManager : MonoBehaviour
{
    int week = 0;
    public Text thisSeason;
    public Button complete;
    public Button[] DaysBtn;
    private int[] weeklyTasks;
    private float inactiveButtonAlpha = 0.5f; // ��Ȱ��ȭ�� ��ư�� ����
    public CanvasGroup buttonCanvasGroup; // ��ư�� CanvasGroup ������Ʈ�� ���⿡ �Ҵ�
    public Flowchart flowchart; // ��ȭ�� �ִ� Fungus Flowchart�� �����մϴ�.

    GameManager gameManager;

    void Start()
    {
        int Day = PlayerPrefs.GetInt("Day");
        int Seasons = PlayerPrefs.GetInt("Seasons");

        switch (Seasons)
        {
            case 0:
                thisSeason.text = "��";
                break;
            case 1:
                thisSeason.text = "����";
                break;
            case 2:
                thisSeason.text = "����";
                break;
            case 3:
                thisSeason.text = "�ܿ�";
                break;
        }

        switch (Day)
        {
            case 1:
                week = 1;
                break;
            case 2:
                week = 2;
                break;
            case 3:
                week = 2;
                break;
        }

        weeklyTasks = new int[5]; // �ְ� �� �� �迭 �ʱ�ȭ
        for (int i = Day; i < Day + 5; i++)
        {
            int dayIndex = i; // ��ư �ε����� �����Ͽ� Ŭ�������� ���

            // �� ��ư�� ���� Ŭ�� �̺�Ʈ ������ �߰�
            DaysBtn[i].onClick.AddListener(() => OnButtonClick(dayIndex));
        }

        for (int i= 0; i < DaysBtn.Length; i++)
        {
            if (i < Day || i >= Day + 5)
            {
                SetButtonAlpha(i, 0.5f);
            }
        }
    }

    void OnButtonClick(int dayIndex)
    {
        // Ŭ���� ��ư�� �ε����� �� �� �迭�� ���� ����
        int currentValue = weeklyTasks[dayIndex];
        weeklyTasks[dayIndex] = (currentValue % 2) + 1; // 1 �Ǵ� 2�� ������ ����

        Debug.Log("Day " + (dayIndex + 1) + ": Task " + weeklyTasks[dayIndex]);

        // Ŭ���� ��ư�� ���� �߰� �۾� ����
        if (weeklyTasks[dayIndex] == 1)
        {
            // weeklyTasks[dayIndex] ���� 1�̸� ��ư�� �ؽ�Ʈ�� "���"�� ����
            DaysBtn[dayIndex].GetComponentInChildren<Text>().text = "���";
        }
        else if (weeklyTasks[dayIndex] == 2)
        {
            DaysBtn[dayIndex].GetComponentInChildren<Text>().text = "����";
        }
    }
    void SetButtonAlpha(int buttonIndex, float alpha)
    {
        // ��ư�� CanvasGroup�� �������ų� ������ �߰�
        CanvasGroup buttonCanvasGroup = DaysBtn[buttonIndex].GetComponent<CanvasGroup>();
        if (buttonCanvasGroup == null)
        {
            buttonCanvasGroup = DaysBtn[buttonIndex].gameObject.AddComponent<CanvasGroup>();
        }

        // ��ư�� ������ ����
        buttonCanvasGroup.alpha = alpha;
    }
    public void onClickComplete()
    {
        string weeklyTasksList = "";
        for(int i=0; i < weeklyTasks.Length; i++)
        {
            weeklyTasksList += weeklyTasks[i] + " ";
        }

        if (weeklyTasksList.Contains('0'))
        {
            int randomIndex = Random.Range(1, 4);

            flowchart.ExecuteBlock("DontZeroBlock"+ randomIndex);
        }
        else
        {
            PlayerPrefs.SetString("weeklyTasksList", weeklyTasksList);
            Debug.Log(weeklyTasksList);
            //gameManager.nextDay();
        }
    }
}
