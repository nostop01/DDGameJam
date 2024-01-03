using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlueEnemyStatus : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public float BlueEnemyHealth = 50f;
    public static float BlueEnemyAttack = 0f;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthZero();
    }

    private void HealthZero()
    {
        if (BlueEnemyHealth <= 0)
        {
            //Pool.Release(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        BlueEnemyHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
