using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CommonEnemyStatus : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public static float CommonEnemyHealth = 40f;
    public static float CommonEnemyAttack = 5f;

    public static bool HitPlayer = false;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HitPlayer)
        {
            Timer += Time.deltaTime;

            if (Timer >= 0.05f)
            {
                HitPlayer = false;
                Timer = 0f;
            }
        }

        HealthZero();
    }

    private void HealthZero()
    {
        if(CommonEnemyHealth <= 0)
        {
            //Pool.Release(this.gameObject);
            Destroy(gameObject);
        }
    }

    private void SuccessAttack()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HitPlayer = true;
        }

        if (collision.gameObject.name == "Energy")
        {
            EnergyStatus.EnergyHealth = EnergyStatus.EnergyHealth - CommonEnemyAttack;

            Destroy(gameObject);

            //Pool.Release(this.gameObject);
        }
    }
}
