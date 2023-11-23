using UnityEngine;
using System;

public class GameTimeController : MonoBehaviour
{
    public float gameMinutesPerRealMinute = 10f; // 1분에 몇 분이 흐를지 설정 (조절 가능)

    private float gameTimeElapsed = 0f; // 게임이 시작한 후의 누적 게임 시간

    void Start()
    {
        // 게임이 시작한 시간을 현재 시간으로 초기화
        DateTime currentTime = DateTime.Now;
        gameTimeElapsed = (float)(currentTime.Hour * 60 + currentTime.Minute) / gameMinutesPerRealMinute;
    }

    void Update()
    {
        // 게임 시간 업데이트
        gameTimeElapsed += Time.deltaTime / 60 * gameMinutesPerRealMinute; // 1분에 설정한 분만큼 더함

        // 게임 시간을 시, 분으로 변환
        int gameHours = Mathf.FloorToInt(gameTimeElapsed / 60);
        int gameMinutes = Mathf.FloorToInt(gameTimeElapsed % 60);

        // 게임 시간이 오전 6시부터 밤 11시 59분까지로 제한
        if (gameHours < 6 || (gameHours == 23 && gameMinutes > 59))
        {
            // 게임 시간을 6:00으로 설정
            gameHours = 6;
            gameMinutes = 0;
            gameTimeElapsed = gameHours * 60 + gameMinutes;
        }

        // 여기에서 게임 시간을 활용하여 게임 내에서 필요한 작업 수행
        // 예를 들면, 게임 시간에 따른 이벤트 발생이나 일정 작업 수행 등을 여기에 추가할 수 있습니다.

        // 콘솔에 현재 게임 시간 출력 (테스트용)
        Debug.Log("현재 게임 시간: " + gameHours.ToString("00") + ":" + gameMinutes.ToString("00"));
    }
}
