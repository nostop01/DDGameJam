using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float MoveSpeed = 0; //�̵��ӵ�
    public static float MaxAcceleration = 30f; //�ִ� ���ӵ�
    public static float DefaultSpeed = 50f; //�⺻�ӵ�
    public static float Acceleration; //���ӵ�
    public float AccelingTimer = 0f; //�������� Ÿ�̸�

    public bool Acceling = false; //�������ΰ�?


    Rigidbody2D rigid2D;
    Vector2 lastInputDirection;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        DefaultSpeed = 50f;
    }

    private void Update()
    {
        SetMoveSpeed();
        PlayerMove();
        InstantaneousAccel();

        if (Acceling)
        {
            AccelingTimer += Time.deltaTime;
        }
    }

    private void SetMoveSpeed()
    {
        MoveSpeed = DefaultSpeed + Acceleration;

        if (Acceleration >= MaxAcceleration && !Acceling)
        {
            Acceleration = MaxAcceleration;
        }

        else if(Acceleration <= MaxAcceleration && !Acceling)
        {
            Acceleration += 0.05f;
        }

    }

    private void PlayerMove() //�÷��̾� ������
    {
        if(!Acceling)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                // ����ڰ� �Է��� ���
                lastInputDirection = new Vector2(horizontalInput, verticalInput).normalized;
            }

            // �÷��̾ �ڵ����� �̵��ϵ��� Rigidbody2D�� velocity�� ����
            rigid2D.velocity = lastInputDirection * MoveSpeed;
        }

    }

    private void InstantaneousAccel() //���� ����
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && AccelingTimer == 0)
        {
            Acceling = true;
            Acceleration *= 5;
        }

        rigid2D.velocity = lastInputDirection * MoveSpeed;

        if (AccelingTimer >= 0.3f)
        {
            Acceling = false;
            AccelingTimer = 0;

            Acceleration = MaxAcceleration;
            Acceleration -= MaxAcceleration / 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Point")
        {
            DefaultSpeed += 0.5f;
        }

        if(collision.gameObject.name == "CommonEnemy")
        {
            CommonEnemyStatus.CommonEnemyHealth -= Acceleration;

            if(CommonEnemyStatus.CommonEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if(CommonEnemyStatus.CommonEnemyHealth < Acceleration)
            {
                Acceleration = CommonEnemyStatus.CommonEnemyHealth - Acceleration;
            }
            
        }

        if (collision.gameObject.name == "RedEnemy")
        {
            RedEnemyStatus.RedEnemyHealth -= Acceleration;

            if (RedEnemyStatus.RedEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if (RedEnemyStatus.RedEnemyHealth < Acceleration)
            {
                Acceleration = RedEnemyStatus.RedEnemyHealth - Acceleration;
            }

        }

        if (collision.gameObject.name == "BlueEnemy")
        {
            BlueEnemyStatus.BlueEnemyHealth -= Acceleration;

            if (BlueEnemyStatus.BlueEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if (BlueEnemyStatus.BlueEnemyHealth < Acceleration)
            {
                Acceleration = BlueEnemyStatus.BlueEnemyHealth - Acceleration;
            }

        }
    }
}
