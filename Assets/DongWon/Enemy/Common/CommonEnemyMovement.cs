using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMovement : MonoBehaviour
{
    public float MoveSpeed = 25f;
    public float Timer = 0;

    [SerializeField]
    private Transform Target;

    public bool HitPlayer = false;

    Vector3 targetPos;

    private void Start()
    {
        
    }

    private void Update()
    {
        targetPos = Target.transform.position;

        ChaseTarget();

        Timer += Time.deltaTime;

        if (Timer > 0.2f)
        {
            HitPlayer = false;
        }
    }

    private void ChaseTarget()
    {
        if (Target == null)
        {
            return;
        }

        if(!HitPlayer)
        {
            Vector3 direction = (targetPos - transform.position).normalized;

            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer = true;
        }
    }
}
