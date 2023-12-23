using UnityEngine;
using UnityEngine.UI;
using System;
using Fungus;

public class GameTimeController : MonoBehaviour
{
    public Text clock;
    public Text date;
    public float gameMinutesPerRealMinute = 10f; // 1분에 몇 분이 흐를지 설정 (조절 가능)

    private float gameTimeElapsed = 0f; // 게임이 시작한 후의 누적 게임 시간

    public GameObject panel;
    Image img;

    int Day = 0;
    int Seasons = 0;

    public Flowchart flowchart;

    void Start()
    {
        // 게임이 시작한 시간을 현재 시간으로 초기화
        DateTime currentTime = DateTime.Now;
        gameTimeElapsed = (float)(currentTime.Hour * 60 + currentTime.Minute) / gameMinutesPerRealMinute;
        
        img = panel.GetComponent<Image>();

        Day = PlayerPrefs.GetInt("Day");
        Seasons = PlayerPrefs.GetInt("Seasons");

        switch (Seasons)
        {
            case 0:
                date.text = "봄 " + Day + "일";
                break;
            case 1:
                date.text = "여름 " + Day + "일";
                break;
            case 2:
                date.text = "가을 " + Day + "일";
                break;
            case 3:
                date.text = "겨울 "+ Day+"일";
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
        // 게임 시간 업데이트
        gameTimeElapsed += Time.deltaTime / 60 * (gameMinutesPerRealMinute / 10); // 1분에 설정한 분만큼 더함

        // 게임 시간을 시, 분으로 변환
        int gameHours = Mathf.FloorToInt(gameTimeElapsed / 60);
        int gameMinutes = (Mathf.FloorToInt(gameTimeElapsed % 60)) * 10;

        // 게임 시간이 오전 6시부터 밤 11시 59분까지로 제한
        if (gameHours < 6 || (gameHours == 23 && gameMinutes > 50))
        {
            // 게임 시간을 6:00으로 설정
            gameHours = 6;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }
        else if (gameMinutes >= 60){
            gameHours++;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }

        // 시간대별 맵 분위기 
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

        // 여기에서 게임 시간을 활용하여 게임 내에서 필요한 작업 수행
        // 예를 들면, 게임 시간에 따른 이벤트 발생이나 일정 작업 수행 등을 여기에 추가할 수 있습니다.

        clock.text = gameHours.ToString("00") + ":" + gameMinutes.ToString("00");
    }
}
