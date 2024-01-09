using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolAble
{
    public float MoveSpeed = 45f;
    [SerializeField]
    private Transform Target;

    public bool HitParticle = false;

    Vector3 targetPos;

    private void Update()
    {
        targetPos = Target.transform.position;

        ChaseTarget();
    }

    private void ChaseTarget()
    {
        if(!PlayerMovement.PauseGame)
        {
            if (Target == null)
            {
                return;
            }

            Vector3 direction = (targetPos - transform.position).normalized;

            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }

        if (HitParticle)
        {
            ReleasedObject();
        }
    }

    private void ReleasedObject()
    {
        ReleaseObject();
        HitParticle = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReleaseObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Energy"))
        {
            ReleaseObject();
        }
    }
}
