using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlueEnemyStatus : PoolAble
{
    public float BlueEnemyHealth = 40f;
    public static float BlueEnemyAttack = 0f;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        BlueEnemyHealth = 50f;
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
            ReleaseObject();
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
