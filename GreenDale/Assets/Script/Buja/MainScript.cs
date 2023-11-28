using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject continueBtn;

    int Day = 0;

    void Start()
    {
        Day = PlayerPrefs.GetInt("Day");

        if(Day >= 2)
        {
            continueBtn.SetActive(true);
        }
    }

    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("NewCharacter");
    }

    public void continueGame()
    {
        string weeklyTasksList = PlayerPrefs.GetString("weeklyTasksList");

        string[] stringArray = weeklyTasksList.Split(' ');

        string todo = "";

        if (Day % 7 == 1)
        {
            SceneManager.LoadScene("calenderScene");
        }
        else
        {
            switch (Day % 7)
            {
                case 1:
                    todo = stringArray[0];
                    break;
                case 2:
                    todo = stringArray[1];
                    break;
                case 3:
                    todo = stringArray[2];
                    break;
                case 4:
                    todo = stringArray[3];
                    break;
                case 5:
                    todo = stringArray[4];
                    break;
                case 6:
                    todo = stringArray[5];
                    break;
                case 7:
                    todo = stringArray[6];
                    break;
            }

            switch (todo)
            {
                case "1":   // ³ó»ç
                    SceneManager.LoadScene("FarmScene");
                    break;
                case "2":   //³¬½Ã
                    SceneManager.LoadScene("FishingScene");
                    break;
                case "3":
                    SceneManager.LoadScene("SquareScene");
                    break;
            }
        }
    }
    public void exitBtn()
    {
        Application.Quit();
    }
}
