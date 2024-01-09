using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CharkParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();


        ParticleSystem.CollisionModule CollisionModule = particleSystem.collision;
        CollisionModule.enabled = true;

        audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnParticleCollision(GameObject other)
    {
        CommonEnemyNuckBack commonEnemyNuckBack = other.GetComponent<CommonEnemyNuckBack>();
        RedEnemyNuckBack redEnemyNuckBack = other.GetComponent<RedEnemyNuckBack>();
        BlueEnemyNuckBack blueEnemyNuckBack = other.GetComponent<BlueEnemyNuckBack>();
        Bullet bullet = other.GetComponent<Bullet>();

        if (commonEnemyNuckBack != null && commonEnemyNuckBack.gameObject.CompareTag("CommonEnemy"))
        {
            commonEnemyNuckBack.NuckBack(particleSystem.transform);

            CommonEnemyStatus commonEnemyStatus = other.GetComponent<CommonEnemyStatus>();
            if (commonEnemyStatus != null)
            {
                commonEnemyStatus.TakeDamage(PlayerMovement.MoveSpeed / 15f);
            }

            audioSource.Play();
        }

        else if (redEnemyNuckBack != null && redEnemyNuckBack.gameObject.CompareTag("RedEnemy"))
        {
            redEnemyNuckBack.NuckBack(particleSystem.transform);

            RedEnemyStatus redEnemyStatus = other.GetComponent<RedEnemyStatus>();
            if (redEnemyStatus != null)
            {
                redEnemyStatus.TakeDamage(PlayerMovement.MoveSpeed / 15f);
            }

            audioSource.Play();
        }

        else if (blueEnemyNuckBack != null && blueEnemyNuckBack.gameObject.CompareTag("BlueEnemy"))
        {
            blueEnemyNuckBack.NuckBack(particleSystem.transform);

            BlueEnemyStatus blueEnemyStatus = other.GetComponent<BlueEnemyStatus>();
            if (blueEnemyStatus != null)
            {
                blueEnemyStatus.TakeDamage(PlayerMovement.MoveSpeed / 15f);
            }

            audioSource.Play();
        }

        else if(bullet != null && bullet.gameObject.CompareTag("Bullet"))
        {
            bullet.HitParticle = true;
        }
    }
}
