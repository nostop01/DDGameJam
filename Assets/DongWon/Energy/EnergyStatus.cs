using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergyStatus : MonoBehaviour
{
    public static float EnergyHealth = 100f;
    public float GetDamage;

    public AudioSource audioSource;
    public AudioClip clip;

    private int Count;

    Score score;

    Camera Cam;
    Vector3 CameraOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        EnergyHealth = 100f;
        Count = 0;
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position;
        audioSource.clip = clip;
    }

    private void Update()
    {
        if(EnergyHealth <= 0)
        {
            HealthZero();
        }
    }

    private void CountIncrease()
    {
        Debug.Log("GetDamage :" + GetDamage);
        PlayerMovement.DefaultSpeed += GetDamage * 0.3f;
        PlayerMovement.MaxAcceleration += GetDamage * 0.4f;

        Debug.Log("DefaultSpeed :" + PlayerMovement.DefaultSpeed);
    }

    public void HealthZero()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("ResultScene");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CommonEnemy"))
        {
            GetDamage = CommonEnemyStatus.CommonEnemyAttack;
            CountIncrease();
            StartCoroutine(CamShake(0.3f, 0.75f));
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            GetDamage = RedEnemyStatus.RedEnemyAttack;
            CountIncrease();
            StartCoroutine(CamShake(0.3f, 0.75f));
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage = 2;
            CountIncrease();
            StartCoroutine(CamShake(0.3f, 0.5f));
            audioSource.Play();
        }
    }
}
