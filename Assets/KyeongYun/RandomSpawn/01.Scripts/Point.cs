using UnityEngine;

public class Point : MonoBehaviour
{
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = PlayerAttack.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TEST1");

        if (collision.CompareTag("Player"))
        {
            playerAttack.attackPower++;
            Destroy(gameObject);
        }
    }
}
