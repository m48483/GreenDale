using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Farming : MonoBehaviour
{
    public Tilemap[] tilemaps; // 여러 개의 타일맵을 저장할 배열

    private int currentTilemapIndex = 0; // 현재 활성화된 타일맵의 인덱스

    void Update()
    {
        // 스페이스 바를 눌렀을 때 타일맵을 변경
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTilemap();
        }
    }

    void SwitchTilemap()
    {
        // 현재 활성화된 타일맵을 비활성화
        tilemaps[currentTilemapIndex].gameObject.SetActive(false);

        // 다음 타일맵의 인덱스 계산
        currentTilemapIndex = (currentTilemapIndex + 1) % tilemaps.Length;

        // 다음 타일맵을 활성화
        tilemaps[currentTilemapIndex].gameObject.SetActive(true);
    }
}
