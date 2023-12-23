using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Farming : MonoBehaviour
{
    public Tilemap[] tilemaps; // ���� ���� Ÿ�ϸ��� ������ �迭

    private int currentTilemapIndex = 0; // ���� Ȱ��ȭ�� Ÿ�ϸ��� �ε���

    void Update()
    {
        // �����̽� �ٸ� ������ �� Ÿ�ϸ��� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTilemap();
        }
    }

    void SwitchTilemap()
    {
        // ���� Ȱ��ȭ�� Ÿ�ϸ��� ��Ȱ��ȭ
        tilemaps[currentTilemapIndex].gameObject.SetActive(false);

        // ���� Ÿ�ϸ��� �ε��� ���
        currentTilemapIndex = (currentTilemapIndex + 1) % tilemaps.Length;

        // ���� Ÿ�ϸ��� Ȱ��ȭ
        tilemaps[currentTilemapIndex].gameObject.SetActive(true);
    }
}
