using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyMovement : MonoBehaviour
{
    public float MoveSpeed = 30f;

    public Transform Target;

    private void Start()
    {

    }

    private void Update()
    {
        ChaseTarget();
    }

    private void ChaseTarget()
    {
        if (Target == null)
        {
            return;
        }

        if (!RedEnemyStatus.HitPlayer)
        {
            Vector3 direction = (Target.position - transform.position).normalized;

            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }

    }
}
