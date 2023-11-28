using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public float radius = 0.5f;
    public float speed = 2f;

    private float angle = 0f;

    void Update()
    {
        // 각도를 라디안으로 변환
        float radians = angle * Mathf.Deg2Rad;

        // 원의 중심 좌표
        Vector3 center = transform.position;

        // 새로운 위치 계산
        float x = center.x + radius * Mathf.Cos(radians);
        float y = center.y + radius * Mathf.Sin(radians);

        // 새로운 위치 설정
        transform.position = new Vector3(x, y, center.z);

        // 다음 프레임을 위해 각도 업데이트
        angle += speed * Time.deltaTime;

        // 각도가 360도를 넘으면 초기화
        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}
