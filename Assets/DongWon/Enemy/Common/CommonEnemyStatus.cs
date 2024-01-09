using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CommonEnemyStatus : PoolAble
{
    public float CommonEnemyHealth = 30f;
    public static float CommonEnemyAttack = 3f;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        CommonEnemyHealth = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        HealthZero();
    }

    private void HealthZero()
    {
        if(CommonEnemyHealth <= 0)
        {
            ReleaseObject();
        }
    }

    public void TakeDamage(float damage)
    {
        CommonEnemyHealth -= damage;
    }

    private void SuccessAttack()
    {
        ReleaseObject();

        EnergyStatus.EnergyHealth = EnergyStatus.EnergyHealth - CommonEnemyAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Energy"))
        {
            SuccessAttack();
        }
    }
}
