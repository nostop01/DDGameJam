using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject prefab1;              // ������ ������ 1
    public GameObject prefab2;              // ������ ������ 2
    public GameObject point;                // ������ ������ 2

    public Vector2 spawnAreaCenter;         // ���� ������ �߽�
    public Vector2 spawnAreaSize;           // ���� ������

    public Vector2 spawnPointAreaSize;      // ����Ʈ ���� ������

    public Vector2 exclusionAreaCenter;     // ���� ������ �߽�
    public Vector2 exclusionAreaSize;       // ���� ������

    public float spawnInterval1 = 2f;       // ���� ����(sec) for prefab1
    public float spawnInterval2 = 3f;       // ���� ����(sec) for prefab2
    public float pointInterval = 3f;        // ���� ����(sec) for point

    public Transform spawnCenter;           // ���� �߽� ������Ʈ

    public GameObject targetObject;         // �������� ��ǥ ������Ʈ

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            Vector3 spawnPosition = Vector3.zero;

            // ���� ���� �ȿ����� �������� �ʵ��� ���� ��ġ�� ����
            do
            {
                spawnPosition = GetRandomSpawnPosition();
            } while (IsInsideExclusionArea(spawnPosition));

            // �� �����տ� ���� ���� ����
            var obj1 = ObjectPoolManager.instance.GetGo("Enemy1");
            obj1.GetComponent<Enemy1Movement>().targetObject = targetObject;
            obj1.transform.position = spawnPosition;

            var obj2 = ObjectPoolManager.instance.GetGo("Enemy2");
            obj2.GetComponent<Enemy2Movement>().targetObject = targetObject;
            obj2.transform.position = spawnPosition;

            // ����Ʈ�� �������� �����Ƿ� ������ �ʿ� ����
            var obj3 = ObjectPoolManager.instance.GetGo("Point");
            obj3.transform.position = GetRandomPointSpawnPosition();

            yield return new WaitForSeconds(spawnInterval1);  // ù��° ������ ���� ����
            yield return new WaitForSeconds(spawnInterval2);  // �ι�° ������ ���� ����
            yield return new WaitForSeconds(pointInterval);   // ����Ʈ ������ ���� ����
        }
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
        Vector2 randomPosition = spawnAreaCenter + new Vector2
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
        // ��ǥ ������Ʈ�� ������ ǥ��
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(targetObject.transform.position, 0.5f);

        // ���� ������ ������ ǥ��
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);

        // ������ ������ ������ ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionAreaCenter, exclusionAreaSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnPointAreaSize);
    }
}
