using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyMovement : MonoBehaviour
{
    public float MoveSpeed = 30f;
    public float Timer = 0;

    public GameObject Target;

    public bool HitPlayer = false;

    private void Start()
    {

    }

    private void Update()
    {
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

        if (!HitPlayer)
        {
            Vector3 direction = (Target.transform.position - transform.position).normalized;

            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HitPlayer = true;
        }
    }
}
