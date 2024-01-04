using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharkParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public AudioSource audioSource;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        ParticleSystem.CollisionModule collisionModule = particleSystem.collision;
        collisionModule.enabled = true;
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

        if (commonEnemyNuckBack != null && commonEnemyNuckBack.gameObject.CompareTag("CommonEnemy"))
        {
            commonEnemyNuckBack.NuckBack(particleSystem.transform);

            CommonEnemyStatus commonEnemyStatus = other.GetComponent<CommonEnemyStatus>();
            if (commonEnemyStatus != null)
            {
                commonEnemyStatus.TakeDamage(5f);
            }

            audioSource.clip = clip;

            audioSource.Play();
        }
        else if (redEnemyNuckBack != null && redEnemyNuckBack.gameObject.CompareTag("RedEnemy"))
        {
            redEnemyNuckBack.NuckBack(particleSystem.transform);

            RedEnemyStatus redEnemyStatus = other.GetComponent<RedEnemyStatus>();
            if (redEnemyStatus != null)
            {
                redEnemyStatus.TakeDamage(5f);
            }
            audioSource.clip = clip;

            audioSource.Play();
        }
        else if (blueEnemyNuckBack != null && blueEnemyNuckBack.gameObject.CompareTag("BlueEnemy"))
        {
            blueEnemyNuckBack.NuckBack(particleSystem.transform);

            BlueEnemyStatus blueEnemyStatus = other.GetComponent<BlueEnemyStatus>();
            if (blueEnemyStatus != null)
            {
                blueEnemyStatus.TakeDamage(5f);
            }
            audioSource.clip = clip;

            audioSource.Play();
        }
    }
}
