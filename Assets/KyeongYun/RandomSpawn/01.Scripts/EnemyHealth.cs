using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // ���� �ִ� ü��
    private float currentHealth;    // ���� ü��
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // ���� �׾��� ���� ó���� �߰��� �� ����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ���� �׾��� ���� ������ ���⿡ �߰�
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ShaderController shaderController = collision.gameObject.GetComponent<ShaderController>();

            shaderController.ShaderOn();
        }
    }
}
