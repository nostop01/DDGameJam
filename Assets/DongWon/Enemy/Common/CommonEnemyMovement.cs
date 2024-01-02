using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMovement : MonoBehaviour
{
    public float MoveSpeed = 25f;

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

        if(!CommonEnemyStatus.HitPlayer)
        {
            Vector3 direction = (Target.position - transform.position).normalized;

            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }

    }
}
