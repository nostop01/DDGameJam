using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float MoveSpeed = 0; //�̵��ӵ�
    public static float MaxAcceleration = 30f; //�ִ� ���ӵ�
    public static float DefaultSpeed = 50f; //�⺻�ӵ�
    public static float Acceleration; //���ӵ�

    public static bool PauseGame = false;

    public float reamemberAccel; //�������� �� ���ӵ� ���
    public float currentEnemyHealth;
    public float AccelingTimer = 0f; //�������� Ÿ�̸�

    public AudioSource audioSource;
    public AudioClip clip;

    public bool Acceling = false; //�������ΰ�?

    public GameObject PausePanel;

    Camera Cam;
    Rigidbody2D rigid2D;
    Vector2 lastInputDirection;
    Vector3 CameraOriginalPos;
   [SerializeField] private Vector3 LastPos;

    private void Start()
    {
        PauseGame = false;
        MaxAcceleration = 30f;
        DefaultSpeed = 50f;
        rigid2D = GetComponent<Rigidbody2D>();
        DefaultSpeed = 50f;
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position;
        audioSource.clip = clip;
    }

    private void Update()
    {
        Pause();

        if (!PauseGame)
        {
            SetMoveSpeed();
            PlayerMove();

            if (Acceleration >= 10)
            {
                InstantaneousAccel();
            }

            ClampPlayerPosition();

            if (Acceling)
            {
                AccelingTimer += Time.deltaTime;
            }

            if (Acceleration <= 0)
            {
                Acceleration = 0;
            }
        }   

        RememberLastPos();
    }

    private void RememberLastPos()
    {
       
        if(PauseGame)
        {
            rigid2D.position = LastPos;
        }

        else if(!PauseGame)
        {
            LastPos = transform.position;
        }
    }

    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !PauseGame)
        {
            PauseGame = true;
            PausePanel.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && PauseGame)
        {
            PauseGame = false;
            PausePanel.SetActive(false);

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
            Acceleration += 0.1f;
        }

    }

    private void PlayerMove() //�÷��̾� ������
    {
        if(!Acceling)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // ī�޶�� �÷��̾�� ���� 2D ��鿡 �����Ƿ� Z ���� 0���� �����մϴ�.

            // �÷��̾��� ���� ��ġ���� ���콺 ��ġ�� ���ϴ� ���� ���͸� ����մϴ�.
            Vector2 moveDirection = (mousePosition - transform.position).normalized;

            // ����ڰ� �Է��� ���
            lastInputDirection = new Vector2(moveDirection.x, moveDirection.y);

            // �÷��̾ �ڵ����� �̵��ϵ��� Rigidbody2D�� velocity�� ����
            rigid2D.velocity = lastInputDirection * MoveSpeed;
        }
    }

    private void InstantaneousAccel() //���� ����
    {
        if (Input.GetMouseButtonDown(0) && AccelingTimer == 0)
        {
            Acceling = true;
            reamemberAccel = Acceleration;
            Acceleration *= 5;
            audioSource.Play();
        }

        rigid2D.velocity = lastInputDirection * MoveSpeed;

        if (AccelingTimer >= 0.3f)
        {
            Acceling = false;
            AccelingTimer = 0;

            Acceleration = reamemberAccel;
            Acceleration -= 10;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CommonEnemy"))
        {
            CommonEnemyStatus CommonEnemyStatus = collision.gameObject.GetComponent<CommonEnemyStatus>();

            if (CommonEnemyStatus.CommonEnemyHealth >= Acceleration)
            {
                CommonEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.5f;
            }

            else if (Acceleration > CommonEnemyStatus.CommonEnemyHealth)
            {
                CommonEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.25f;
            }

            StartCoroutine(CamShake(0.3f, 0.75f));
        }

        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            RedEnemyStatus RedEnemyStatus = collision.gameObject.GetComponent<RedEnemyStatus>();

            if (RedEnemyStatus.RedEnemyHealth >= Acceleration)
            {
                RedEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.5f;
            }

            else if (RedEnemyStatus.RedEnemyHealth < Acceleration)
            {
                RedEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.25f;
            }

            StartCoroutine(CamShake(0.3f, 0.75f));
        }

        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            BlueEnemyStatus BlueEnemyStatus = collision.gameObject.GetComponent<BlueEnemyStatus>();

            if (BlueEnemyStatus.BlueEnemyHealth >= Acceleration)
            {
                BlueEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.5f;
            }

            else if (BlueEnemyStatus.BlueEnemyHealth < Acceleration)
            {
                BlueEnemyStatus.TakeDamage(Acceleration);

                Acceleration = Acceleration / 1.25f;
            }

            StartCoroutine(CamShake(0.3f, 0.5f));
        }
    }
}
