using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class RedEnemyStatus : PoolAble
{
    public float RedEnemyHealth = 30f;
    public static float RedEnemyAttack = 7f;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        RedEnemyHealth = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        HealthZero();
    }

    private void HealthZero()
    {
        if (RedEnemyHealth <= 0)
        {
            //ReleaseObject();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        RedEnemyHealth -= damage;
    }

    private void SuccessAttack()
    {
        EnergyStatus.EnergyHealth = EnergyStatus.EnergyHealth - RedEnemyAttack;

        ReleaseObject();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Energy"))
        {
            SuccessAttack();
        }
    }
}