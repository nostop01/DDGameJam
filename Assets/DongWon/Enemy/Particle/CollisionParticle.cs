using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticle : MonoBehaviour
{
    public ParticleSystem PlayerCollisionParticle;
    public ParticleSystem EnergyCollisionParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayerCollisionParticles(Vector2 position)
    {
        // 충돌 지점에 파티클 생성
        ParticleSystem collisionParticles = Instantiate(PlayerCollisionParticle, position, Quaternion.identity);

        collisionParticles.Play();
    }

    private void SpawnEnergyCollisionParticles(Vector2 position)
    {
        // 충돌 지점에 파티클 생성
        ParticleSystem collisionParticles = Instantiate(EnergyCollisionParticle, position, Quaternion.identity);

        collisionParticles.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") // 부딪힌 오브젝트의 태그를 확인
        {
            Vector2 contactPoint = collision.GetContact(0).point; // 충돌 지점 정보 가져오기 (첫 번째 충돌 지점만 사용)

            // 충돌 지점에 파티클 시스템 실행
            SpawnPlayerCollisionParticles(contactPoint);
        }

        if (collision.gameObject.name == "Energy") 
        {
            Vector2 contactPoint = collision.GetContact(0).point; 


            SpawnEnergyCollisionParticles(contactPoint);
        }
    }
}
