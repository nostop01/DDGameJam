using UnityEngine;
using UnityEngine.Pool;

public class Enemy1Movement : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public GameObject targetObject; // 프리팹 1의 목표 오브젝트
    public float movementSpeed = 3f; // 이동 속도

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
