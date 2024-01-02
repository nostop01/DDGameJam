using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStatus : MonoBehaviour
{
    public static float EnergyHealth = 100f;
    public float GetDamage;

    private int Count;

    // Start is called before the first frame update
    void Start()
    {
        EnergyHealth = 100f;
        Count = 0;
    }

    private void Update()
    {
        
    }

    private void CountIncrease()
    {
        for(float i = 0; i < GetDamage; i++)
        {
            Count++;
        }

        PlayerMovement.DefaultSpeed += Count * 0.5f;
        PlayerMovement.MaxAcceleration += Count * 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CommonEnemy")
        {
            GetDamage = CommonEnemyStatus.CommonEnemyAttack;
            CountIncrease();
        }

        if (collision.gameObject.name == "RedEnemy")
        {
            GetDamage = RedEnemyStatus.RedEnemyAttack;
            CountIncrease();
        }
    }
}
