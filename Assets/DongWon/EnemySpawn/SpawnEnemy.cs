using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float PastWaveCount;

    public Vector2 spawnAreaCenter;         // ���� ������ �߽�
    public Vector2 spawnAreaSize;           // ���� ������

    public Vector2 spawnPointAreaCenter;         // ���� ������ �߽�
    public Vector2 spawnPointAreaSize;      // ����Ʈ ���� ������

    public Vector2 exclusionAreaCenter;     // ���� ������ �߽�
    public Vector2 exclusionAreaSize;       // ���� ������

    public Transform spawnCenter;           // ���� �߽� ������Ʈ

    public GameObject targetObject;         // �������� ��ǥ ������Ʈ

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
        // ���� ���� ������ ������ ��ġ�� ����
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
        // �־��� ��ġ�� ���� ���� �ȿ� �ִ��� Ȯ��
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
        // ���� ������ ������ ǥ��
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);

        // ������ ������ ������ ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionAreaCenter, exclusionAreaSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPointAreaCenter, spawnPointAreaSize);
    }
}
