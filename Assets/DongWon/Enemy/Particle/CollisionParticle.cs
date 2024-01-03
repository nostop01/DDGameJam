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
        // �浹 ������ ��ƼŬ ����
        ParticleSystem collisionParticles = Instantiate(PlayerCollisionParticle, position, Quaternion.identity);

        collisionParticles.Play();
    }

    private void SpawnEnergyCollisionParticles(Vector2 position)
    {
        // �浹 ������ ��ƼŬ ����
        ParticleSystem collisionParticles = Instantiate(EnergyCollisionParticle, position, Quaternion.identity);

        collisionParticles.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") // �ε��� ������Ʈ�� �±׸� Ȯ��
        {
            Vector2 contactPoint = collision.GetContact(0).point; // �浹 ���� ���� �������� (ù ��° �浹 ������ ���)

            // �浹 ������ ��ƼŬ �ý��� ����
            SpawnPlayerCollisionParticles(contactPoint);
        }

        if (collision.gameObject.name == "Energy") 
        {
            Vector2 contactPoint = collision.GetContact(0).point; 


            SpawnEnergyCollisionParticles(contactPoint);
        }
    }
}
