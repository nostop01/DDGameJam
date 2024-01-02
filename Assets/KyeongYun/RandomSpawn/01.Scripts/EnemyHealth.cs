using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // 적의 최대 체력
    private float currentHealth;    // 현재 체력

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // 적이 죽었을 때의 처리를 추가할 수 있음
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 적이 죽었을 때의 동작을 여기에 추가
        Destroy(gameObject);
    }
}
