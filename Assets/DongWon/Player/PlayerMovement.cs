using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float MoveSpeed = 0; //이동속도
    public static float MaxAcceleration = 30f; //최대 가속도
    public static float DefaultSpeed = 50f; //기본속도
    public static float Acceleration; //가속도
    public float AccelingTimer = 0f; //순간가속 타이머

    public bool Acceling = false; //가속중인가?

    Camera Cam;
    Rigidbody2D rigid2D;
    Vector2 lastInputDirection;
    Vector3 CameraOriginalPos;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        DefaultSpeed = 50f;
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position;
    }

    private void Update()
    {
        SetMoveSpeed();
        PlayerMove();
        InstantaneousAccel();
        ClampPlayerPosition();

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
            Acceleration += 0.025f;
        }

    }

    private void PlayerMove() //플레이어 움직임
    {
        if(!Acceling)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // 카메라와 플레이어는 같은 2D 평면에 있으므로 Z 값은 0으로 설정합니다.

            // 플레이어의 현재 위치에서 마우스 위치로 향하는 방향 벡터를 계산합니다.
            Vector2 moveDirection = (mousePosition - transform.position).normalized;

            // 사용자가 입력한 경우
            lastInputDirection = new Vector2(moveDirection.x, moveDirection.y);

            // 플레이어가 자동으로 이동하도록 Rigidbody2D의 velocity를 설정
            rigid2D.velocity = lastInputDirection * MoveSpeed;
        }

    }

    private void InstantaneousAccel() //순간 가속
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

    void ClampPlayerPosition()
    {
        Camera mainCamera = Camera.main;
        Vector3 minBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public IEnumerator CamShake(float duration, float magnitude)
    {
        float timer = 0;

        while (timer <= duration)
        {
            Cam.transform.localPosition = Random.insideUnitSphere * magnitude + CameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }

        Cam.transform.localPosition = CameraOriginalPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Point"))
        {
            DefaultSpeed += 0.5f;
        }

        if(collision.gameObject.CompareTag("CommonEnemy"))
        {
            CommonEnemyStatus CommonEnemyStatus = collision.gameObject.GetComponent<CommonEnemyStatus>();

            CommonEnemyStatus.TakeDamage(Acceleration);

            if(CommonEnemyStatus.CommonEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if(CommonEnemyStatus.CommonEnemyHealth < Acceleration)
            {
                Acceleration = CommonEnemyStatus.CommonEnemyHealth - Acceleration;
            }

            StartCoroutine(CamShake(0.5f, 1.25f));
        }

        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            RedEnemyStatus RedEnemyStatus = collision.gameObject.GetComponent<RedEnemyStatus>();

            RedEnemyStatus.TakeDamage(Acceleration);

            if (RedEnemyStatus.RedEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if (RedEnemyStatus.RedEnemyHealth < Acceleration)
            {
                Acceleration = RedEnemyStatus.RedEnemyHealth - Acceleration;
            }

            StartCoroutine(CamShake(0.5f, 1.5f));

        }

        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            BlueEnemyStatus BlueEnemyStatus = collision.gameObject.GetComponent<BlueEnemyStatus>();

            BlueEnemyStatus.TakeDamage(Acceleration);

            if (BlueEnemyStatus.BlueEnemyHealth >= Acceleration)
            {
                Acceleration = Acceleration / 2;
            }

            if (BlueEnemyStatus.BlueEnemyHealth < Acceleration)
            {
                Acceleration = BlueEnemyStatus.BlueEnemyHealth - Acceleration;
            }

            StartCoroutine(CamShake(0.5f, 1.25f));

        }
    }
}
