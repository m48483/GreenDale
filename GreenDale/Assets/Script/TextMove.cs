using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 2f; // 움직일 범위

    private Vector3 initialPosition;

    void Start()
    {
        // 초기 위치 저장
        initialPosition = transform.position;
    }

    void Update()
    {
        // 위아래로 반복 운동 계산
        float verticalMovement = Mathf.Sin(Time.time * speed) * amplitude;

        // 새로운 y 좌표 계산
        float newY = initialPosition.y + verticalMovement;

        // 새로운 위치 설정
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
