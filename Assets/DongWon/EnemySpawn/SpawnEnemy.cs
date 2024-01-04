using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float PastWaveCount;

    public Vector2 spawnAreaCenter;         // 생성 범위의 중심
    public Vector2 spawnAreaSize;           // 생성 사이즈

    public Vector2 spawnPointAreaCenter;         // 생성 범위의 중심
    public Vector2 spawnPointAreaSize;      // 포인트 생성 사이즈

    public Vector2 exclusionAreaCenter;     // 제외 범위의 중심
    public Vector2 exclusionAreaSize;       // 제외 사이즈

    public Transform spawnCenter;           // 스폰 중심 오브젝트

    public GameObject targetObject;         // 프리팹의 목표 오브젝트

    WaveSystem waveSystem;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCommonEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(PastWaveCount != WaveSystem.WaveCounter)
        {
            for(float i = 0; i < WaveSystem.CommonEnemyCount; i++)
            {
                SpawnCommonEnemy();
            }
            
            for (float i = 0; i < WaveSystem.RedEnemyCount; i++)
            {
                SpawnRedEnemy();
            }

            for (float i = 0; i < WaveSystem.BlueEnemyCount; i++)
            {
                SpawnBlueEnemy();
            }
            
            PastWaveCount = WaveSystem.WaveCounter;
        }
    }

    public void SpawnCommonEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        do
        {
            spawnPosition = GetRandomSpawnPosition();
        } while (IsInsideExclusionArea(spawnPosition));

        var obj1 = ObjectPoolManager.instance.GetGo("CommonEnemy");
        obj1.transform.position = spawnPosition;
    }

    public void SpawnRedEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        do
        {
            spawnPosition = GetRandomSpawnPosition();
        } while (IsInsideExclusionArea(spawnPosition));

        var obj1 = ObjectPoolManager.instance.GetGo("RedEnemy");
        obj1.transform.position = spawnPosition;
    }

    public void SpawnBlueEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;
        do
        {
            spawnPosition = GetRandomSpawnPosition();
        } while (IsInsideExclusionArea(spawnPosition));

        var obj1 = ObjectPoolManager.instance.GetGo("BlueEnemy");
        obj1.transform.position = spawnPosition;
    }

    public Vector3 GetRandomSpawnPosition()
    {
        // 스폰 구역 내에서 랜덤한 위치를 생성
        Vector2 randomPosition = spawnAreaCenter + new Vector2
        (
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
        );
        return randomPosition;
    }
    public Vector3 GetRandomPointSpawnPosition()
    {
        Vector2 randomPosition = spawnPointAreaCenter + new Vector2
        (
            Random.Range(-spawnPointAreaSize.x / 2f, spawnPointAreaSize.x / 2f),
            Random.Range(-spawnPointAreaSize.y / 2f, spawnPointAreaSize.y / 2f)
        );
        return randomPosition;
    }

    private bool IsInsideExclusionArea(Vector3 position)
    {
        // 주어진 위치가 제외 영역 안에 있는지 확인
        return
        (
            position.x >= exclusionAreaCenter.x - exclusionAreaSize.x / 2f &&
            position.x <= exclusionAreaCenter.x + exclusionAreaSize.x / 2f &&
            position.y >= exclusionAreaCenter.y - exclusionAreaSize.y / 2f &&
            position.y <= exclusionAreaCenter.y + exclusionAreaSize.y / 2f
        );
    }

    private void OnDrawGizmos()
    {
        // 스폰 구역을 기즈모로 표시
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);

        // 제외할 범위를 기즈모로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionAreaCenter, exclusionAreaSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPointAreaCenter, spawnPointAreaSize);
    }
}
