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
                    Debug.LogError("PlayerAttack 인스턴스를 찾을 수 없습니다.");
                }
            }
            return _instance;
        }
    }
    public float attackPower = 20f;  // 플레이어의 공격력
    public float speed = 5f; // 플레이어의 속도(다른 스크립트에서 가져오든가 하면 됨)
    RigidbodyMove rigidbodyMove;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("대시");
            rigidbodyMove.speed = speed * 2;
            // 직접적인 속도가 아닌 가속도 * 2가 더 좋을듯
        }
    }
    // 플레이어와 적이 충돌했을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 적의 체력을 플레이어의 공격력만큼 감소시킴
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackPower * speed);
            }
        }
    }
}
