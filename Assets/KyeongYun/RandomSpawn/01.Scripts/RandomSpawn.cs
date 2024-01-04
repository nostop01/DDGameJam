using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject prefab1;              // 생성할 프리팹 1
    public GameObject prefab2;              // 생성할 프리팹 2
    public GameObject point;                // 생성할 프리팹 2

    public Vector2 spawnAreaCenter;         // 생성 범위의 중심
    public Vector2 spawnAreaSize;           // 생성 사이즈

    public Vector2 spawnPointAreaSize;      // 포인트 생성 사이즈

    public Vector2 exclusionAreaCenter;     // 제외 범위의 중심
    public Vector2 exclusionAreaSize;       // 제외 사이즈

    public float spawnInterval1 = 2f;       // 생성 간격(sec) for prefab1
    public float spawnInterval2 = 3f;       // 생성 간격(sec) for prefab2
    public float pointInterval = 3f;        // 생성 간격(sec) for point

    public Transform spawnCenter;           // 스폰 중심 오브젝트

    public GameObject targetObject;         // 프리팹의 목표 오브젝트

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            Vector3 spawnPosition = Vector3.zero;

            // 제외 영역 안에서는 생성하지 않도록 랜덤 위치를 선택
            do
            {
                spawnPosition = GetRandomSpawnPosition();
            } while (IsInsideExclusionArea(spawnPosition));

            // 두 프리팹에 대해 각각 생성
            var obj1 = ObjectPoolManager.instance.GetGo("Enemy1");
            obj1.GetComponent<Enemy1Movement>().targetObject = targetObject;
            obj1.transform.position = spawnPosition;

            var obj2 = ObjectPoolManager.instance.GetGo("Enemy2");
            obj2.GetComponent<Enemy2Movement>().targetObject = targetObject;
            obj2.transform.position = spawnPosition;

            // 포인트는 움직임이 없으므로 움직일 필요 없음
            var obj3 = ObjectPoolManager.instance.GetGo("Point");
            obj3.transform.position = GetRandomPointSpawnPosition();

            yield return new WaitForSeconds(spawnInterval1);  // 첫번째 프리팹 생성 간격
            yield return new WaitForSeconds(spawnInterval2);  // 두번째 프리팹 생성 간격
            yield return new WaitForSeconds(pointInterval);   // 포인트 프리팹 생성 간격
        }
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
        Vector2 randomPosition = spawnAreaCenter + new Vector2
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
        // 목표 오브젝트를 기즈모로 표시
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(targetObject.transform.position, 0.5f);

        // 스폰 구역을 기즈모로 표시
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);

        // 제외할 범위를 기즈모로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionAreaCenter, exclusionAreaSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnPointAreaSize);
    }
}
