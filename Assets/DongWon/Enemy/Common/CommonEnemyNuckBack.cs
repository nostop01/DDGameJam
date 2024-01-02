using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyNuckBack : MonoBehaviour
{
    public float PlayerSpeed = 0;

    public Transform Target;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(CommonEnemyStatus.HitPlayer)
        {
            NuckBack();
        }
    }

    private void NuckBack()
    {
        PlayerSpeed = PlayerMovement.MoveSpeed;

        Vector2 direction = (Target.transform.position - transform.position).normalized;
        Vector2 bounceVector = PlayerSpeed / 2 * direction;

        rigid.AddForce(-bounceVector, ForceMode2D.Impulse);

    }

}
