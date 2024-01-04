using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public static float CommonEnemyCount = 0; //일반 적
    public static float RedEnemyCount = 0; //붉은 적
    public static float BlueEnemyCount = 0; //푸른 적
    public static float WaveCounter = 0; //현재 몇번째 웨이브인지 확인하기 위해 사용

    public static bool CanSpawnEnemy = false;

    public float WaveTimer = 0;  //4초마다 웨이브 나오는 거 확인용

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
