using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private static PlayerAttack _instance;

    public static PlayerAttack Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerAttack>();
                if (_instance == null)
                {
                    Debug.LogError("PlayerAttack �ν��Ͻ��� ã�� �� �����ϴ�.");
                }
            }
            return _instance;
        }
    }
    public float attackPower = 20f;  // �÷��̾��� ���ݷ�
    public float speed = 5f; // �÷��̾��� �ӵ�(�ٸ� ��ũ��Ʈ���� �������簡 �ϸ� ��)
    RigidbodyMove rigidbodyMove;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("���");
            rigidbodyMove.speed = speed * 2;
            // �������� �ӵ��� �ƴ� ���ӵ� * 2�� �� ������
        }
    }
    // �÷��̾�� ���� �浹���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // ���� ü���� �÷��̾��� ���ݷ¸�ŭ ���ҽ�Ŵ
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackPower * speed);
            }
        }
    }
}
