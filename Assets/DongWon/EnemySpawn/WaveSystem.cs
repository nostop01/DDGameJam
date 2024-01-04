using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public static float CommonEnemyCount = 0; //�Ϲ� ��
    public static float RedEnemyCount = 0; //���� ��
    public static float BlueEnemyCount = 0; //Ǫ�� ��
    public static float WaveCounter = 0; //���� ���° ���̺����� Ȯ���ϱ� ���� ���

    public static bool CanSpawnEnemy = false;

    public float WaveTimer = 0;  //4�ʸ��� ���̺� ������ �� Ȯ�ο�

    private void Start()
    {
        WaveTimer = 0f;
        WaveCounter = 0f;
        CommonEnemyCount = 1;
        RedEnemyCount = 0;
        BlueEnemyCount = 0;
    }

    private void Update()
    {
        WaveTimer += Time.deltaTime;

        if (WaveTimer >= 7f)
        {
            WaveTimer = 0f;
            WaveCount();
            SetEnemySpawnCount();
            CanSpawn();
        }
    }

    private void WaveCount()
    {
        WaveCounter++;
    }

    private void SetEnemySpawnCount()
    {
        if (WaveCounter % 3 == 0 && WaveCounter % 5 == 0)
        {
            RedEnemyCount++;
            BlueEnemyCount++;
        }

        else if (WaveCounter % 3 == 0)
        {
            RedEnemyCount++;
            CommonEnemyCount++;
        }

        else if (WaveCounter % 5 == 0)
        {
            BlueEnemyCount++;
        }
    }

    private void CanSpawn()
    {
        CanSpawnEnemy = true;
    }
}
