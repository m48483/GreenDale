using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System;

public class DiarySystem : MonoBehaviour
{
    public Button cancelBtn;
    public Button completedBtn;
    public Dropdown dropdown;

    public Text Date;

    private CalenderManager cm;

    private int dropdown_value = 0;
    public Flowchart flowchart;

    private int Day;
    private int Seasons;        // ���� 0 �� 1 ���� 2 ���� 3 �ܿ�

    public Text text;
    public SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GetComponent<SceneChange>();

        dropdown_value = 0;
        Day = PlayerPrefs.GetInt("Day");
        Seasons = PlayerPrefs.GetInt("Seasons");

        switch (Seasons)
        {
            case 0:
                Date.text = "�� "+ Day+"��";
                break;
            case 1:
                Date.text = "���� "+ Day + "��";
                break;
            case 2:
                Date.text = "���� "+ Day + "��";
                break;
            case 3:
                Date.text = "�ܿ� "+ Day + "��";
                break;
        }
    }
    
    public void SelectDropdown()
    {
        dropdown_value = dropdown.value;
    }

    public void OnClickCanceled()
    {
        flowchart.ExecuteBlock("CanceledBlock");
    }

    public void OnClickCompleted()
    {
        string todayTodo = isRight();

        int todo = 1;

        switch (todayTodo)
        {
            case "1":
                todo = 1;
                break;
            case "2":
                todo = 2;
                break;
        }
        
        if (todo == (dropdown_value+1))
        {
            flowchart.ExecuteBlock("rightBlock");
        }
        else
        {
            flowchart.ExecuteBlock("wrongBlock");
        }
    }

    public void OnClickNext()
    {
        string gn = text.text;
        if (gn == "�� ��")
        {
            if (Day <= 21)
            {
                Day++;
                Destroy(this);
            }
            else if (Day > 21)
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
            PlayerPrefs.SetInt("Day", Day);
            PlayerPrefs.SetInt("Seasons", Seasons);

            sceneChange.continueGame();
        }
    }

     public string isRight()
    {
        string weeklyTasksList = PlayerPrefs.GetString("weeklyTasksList");

        string[] stringArray = weeklyTasksList.Split(' ');

        string todayTodo = "";

        switch (Day % 7)
        {
            case 1:
                todayTodo = stringArray[0];
                break;
            case 2:
                todayTodo = stringArray[1];
                break;
            case 3:
                todayTodo = stringArray[2];
                break;
            case 4:
                todayTodo = stringArray[3];
                break;
            case 5:
                todayTodo = stringArray[4];
                break;
        }

        return todayTodo;
    }
}
