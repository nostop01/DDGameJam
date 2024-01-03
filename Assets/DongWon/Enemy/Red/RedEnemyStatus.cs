using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class RedEnemyStatus : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public float RedEnemyHealth = 30f;
    public static float RedEnemyAttack = 7f;

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
        if (RedEnemyHealth <= 0)
        {
            //Pool.Release(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        RedEnemyHealth -= damage;
    }

    private void SuccessAttack()
    {
        EnergyStatus.EnergyHealth = EnergyStatus.EnergyHealth - RedEnemyAttack;

        Destroy(gameObject);

        //Pool.Release(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Energy")
        {
            SuccessAttack();
        }
    }
}