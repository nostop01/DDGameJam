using UnityEngine;

public class Point : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TEST1");

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerMovement.DefaultSpeed += 0.5f;
            PlayerMovement.MaxAcceleration += 0.5f;
            //Pool.Release(this.gameobject);
        }
    }
}
