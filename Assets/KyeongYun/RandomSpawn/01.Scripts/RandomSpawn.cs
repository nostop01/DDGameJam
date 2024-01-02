using System.Collections;
using UnityEngine;

public class DualPrefabSpawn : MonoBehaviour
{
    public GameObject prefab1;              // ������ ������ 1
    public GameObject prefab2;              // ������ ������ 2
    public float spawnInterval1 = 2f;       // ���� ����(sec) for prefab1
    public float spawnInterval2 = 3f;       // ���� ����(sec) for prefab2
    public Transform spawnCenter;           // ���� �߽� ������Ʈ
    public float spawnRadius1 = 5f;         // ���� ������ for prefab1
    public float spawnRadius2 = 7f;         // ���� ������ for prefab2
    public float exclusionRadius1 = 2f;     // ������ ������ for prefab1
    public float exclusionRadius2 = 3f;     // ������ ������ for prefab2
    public GameObject targetObject;        // �������� ��ǥ ������Ʈ

    private void Start()
    {
        StartCoroutine(SpawnAndMoveObjects());
    }

    private IEnumerator SpawnAndMoveObjects()
    {
        while (true)
        {
            // �� �����տ� ���� ���� ����
            var obj1 = ObjectPoolManager.instance.GetGo("Enemy1");
            obj1.GetComponent<Enemy1Movement>().targetObject = targetObject;
            

            var obj2 = ObjectPoolManager.instance.GetGo("Enemy2");
            obj2.GetComponent<Enemy2Movement>().targetObject = targetObject;

            yield return new WaitForSeconds(spawnInterval1);  // ù ��° ������ ���� ����
            yield return new WaitForSeconds(spawnInterval2);  // �� ��° ������ ���� ����
        }
    }

    public Vector3 GetRandomSpawnPosition(float spawnRadius, float exclusionRadius)
    {
        // �� ���ο��� ������ ��ġ�� ����
        Vector3 randomPosition = Vector3.zero;
        bool isWithinExclusion = true;

        // ���� ���� �ȿ� �����ǵ��� Ȯ��
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
        // ���� ������ ���� ������ ������ ������ �׸���. (prefab1)
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnCenter.position, spawnRadius1);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnCenter.position, exclusionRadius1);

        // ���� ������ ���� ������ ������ ������ �׸���. (prefab2)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spawnCenter.position, spawnRadius2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawnCenter.position, exclusionRadius2);

        // ��ǥ ������Ʈ�� ������ ǥ��
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(targetObject.transform.position, 0.5f);
    }
}