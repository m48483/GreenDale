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
    private float inactiveButtonAlpha = 0.5f; // 비활성화된 버튼의 투명도
    public CanvasGroup buttonCanvasGroup; // 버튼의 CanvasGroup 컴포넌트를 여기에 할당
    public Flowchart flowchart; // 대화가 있는 Fungus Flowchart를 참조합니다.

    GameManager gameManager;

    void Start()
    {
        int Day = PlayerPrefs.GetInt("Day");
        int Seasons = PlayerPrefs.GetInt("Seasons");

        switch (Seasons)
        {
            case 0:
                thisSeason.text = "봄";
                break;
            case 1:
                thisSeason.text = "여름";
                break;
            case 2:
                thisSeason.text = "가을";
                break;
            case 3:
                thisSeason.text = "겨울";
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

        weeklyTasks = new int[5]; // 주간 할 일 배열 초기화
        for (int i = Day; i < Day + 5; i++)
        {
            int dayIndex = i; // 버튼 인덱스를 저장하여 클로저에서 사용

            // 각 버튼에 대한 클릭 이벤트 리스너 추가
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
        // 클릭한 버튼의 인덱스로 할 일 배열에 값을 저장
        int currentValue = weeklyTasks[dayIndex];
        weeklyTasks[dayIndex] = (currentValue % 2) + 1; // 1 또는 2를 번갈아 저장

        Debug.Log("Day " + (dayIndex + 1) + ": Task " + weeklyTasks[dayIndex]);

        // 클릭한 버튼에 대한 추가 작업 수행
        if (weeklyTasks[dayIndex] == 1)
        {
            // weeklyTasks[dayIndex] 값이 1이면 버튼의 텍스트를 "농사"로 변경
            DaysBtn[dayIndex].GetComponentInChildren<Text>().text = "농사";
        }
        else if (weeklyTasks[dayIndex] == 2)
        {
            DaysBtn[dayIndex].GetComponentInChildren<Text>().text = "낚시";
        }
    }
    void SetButtonAlpha(int buttonIndex, float alpha)
    {
        // 버튼의 CanvasGroup을 가져오거나 없으면 추가
        CanvasGroup buttonCanvasGroup = DaysBtn[buttonIndex].GetComponent<CanvasGroup>();
        if (buttonCanvasGroup == null)
        {
            buttonCanvasGroup = DaysBtn[buttonIndex].gameObject.AddComponent<CanvasGroup>();
        }

        // 버튼의 투명도를 설정
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
