using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject prefab1;              // 생성할 프리팹 1
    public GameObject prefab2;              // 생성할 프리팹 2
    public GameObject point;                // 생성할 프리팹 2

    public float spawnInterval1 = 2f;       // 생성 간격(sec) for prefab1
    public float spawnInterval2 = 3f;       // 생성 간격(sec) for prefab2
    public float pointInterval = 3f;       // 생성 간격(sec) for point

    public Transform spawnCenter;           // 스폰 중심 오브젝트

    public float spawnRadius1 = 5f;         // 스폰 반지름 for prefab1
    public float spawnRadius2 = 7f;         // 스폰 반지름 for prefab2
    public float spawnRadius3 = 7f;         // 스폰 반지름 for point

    public float exclusionRadius1 = 2f;     // 제외할 반지름 for prefab1
    public float exclusionRadius2 = 3f;     // 제외할 반지름 for prefab2
    public float exclusionRadius3 = 3f;     // 제외할 반지름 for point

    public GameObject targetObject;        // 프리팹의 목표 오브젝트

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // 두 프리팹에 대해 각각 생성
            var obj1 = ObjectPoolManager.instance.GetGo("Enemy1");
            obj1.GetComponent<Enemy1Movement>().targetObject = targetObject;

            var obj2 = ObjectPoolManager.instance.GetGo("Enemy2");
            obj2.GetComponent<Enemy2Movement>().targetObject = targetObject;

            // 포인트는 움직임이 없으므로 움직일 필요 X
            ObjectPoolManager.instance.GetGo("Point");

            yield return new WaitForSeconds(spawnInterval1);  // 첫번째 프리팹 생성 간격
            yield return new WaitForSeconds(spawnInterval2);  // 두번째 프리팹 생성 간격
            yield return new WaitForSeconds(pointInterval);   // 포인트 프리팹 생성 간격
        }
    }

    private Vector3 GetRandomSpawnPosition(float spawnRadius, float exclusionRadius)
    {
        Vector3 randomPosition = Vector3.zero;
        bool isWithinExclusion = true;

        while (isWithinExclusion)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float distance = Random.Range(0f, spawnRadius);
            randomPosition = spawnCenter.position + new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance, 0f);

            float distanceToCenter = Vector3.Distance(randomPosition, spawnCenter.position);
            isWithinExclusion = distanceToCenter < exclusionRadius;
        }

        return randomPosition;
    }
    private void OnDrawGizmos()
    {
        // 스폰 구역의 경계와 제외할 구역을 기즈모로 그린다. (prefab1)
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnCenter.position, spawnRadius1);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnCenter.position, exclusionRadius1);

        // 스폰 구역의 경계와 제외할 구역을 기즈모로 그린다. (prefab2)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnCenter.position, spawnRadius2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawnCenter.position, exclusionRadius2);

        // 목표 오브젝트를 기즈모로 표시
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(targetObject.transform.position, 0.5f);
    }
}
