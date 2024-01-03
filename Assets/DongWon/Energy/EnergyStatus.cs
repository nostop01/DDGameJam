using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStatus : MonoBehaviour
{
    public static float EnergyHealth = 100f;
    public float GetDamage;

    private int Count;

    Camera Cam;
    Vector3 CameraOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        EnergyHealth = 100f;
        Count = 0;
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position;
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

    public IEnumerator CamShake(float duration, float magnitude)
    {
        float timer = 0;

        while (timer <= duration)
        {
            Cam.transform.localPosition = Random.insideUnitSphere * magnitude + CameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }

        Cam.transform.localPosition = CameraOriginalPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CommonEnemy")
        {
            GetDamage = CommonEnemyStatus.CommonEnemyAttack;
            CountIncrease();
            StartCoroutine(CamShake(0.5f, 1.5f));
        }

        if (collision.gameObject.name == "RedEnemy")
        {
            GetDamage = RedEnemyStatus.RedEnemyAttack;
            CountIncrease();
            StartCoroutine(CamShake(0.5f, 2.0f));
        }
    }
}
