using UnityEngine;
using UnityEngine.Pool;

public class Enemy2Movement : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public GameObject targetObject; // ������ 2�� ��ǥ ������Ʈ
    public float movementSpeed = 5f; // �̵� �ӵ�

    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (targetObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, movementSpeed * Time.deltaTime);
        }
    }
    private void DestroyObject()
    {
        Pool.Release(this.gameObject);
    }
}
