using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyNuckBack : MonoBehaviour
{
    public float PlayerSpeed = 0;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    public void NuckBack(Transform Target)
    {
        PlayerSpeed = PlayerMovement.MoveSpeed;

        Vector2 direction = (Target.transform.position - transform.position).normalized;
        Vector2 bounceVector = PlayerSpeed / 2 * direction;

        rigid.AddForce(-bounceVector, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            NuckBack(collision.transform);
        }
    }
}
