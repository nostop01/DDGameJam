using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CommonEnemyStatus : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public float CommonEnemyHealth = 40f;
    public static float CommonEnemyAttack = 5f;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
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
            //Pool.Release(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        CommonEnemyHealth -= damage;
    }

    private void SuccessAttack()
    {
        EnergyStatus.EnergyHealth = EnergyStatus.EnergyHealth - CommonEnemyAttack;

        Destroy(gameObject);

        //Pool.Release(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Energy")
        {
            SuccessAttack();
        }
    }
}
