using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticle : MonoBehaviour
{
    public ParticleSystem PlayerCollisionParticle;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �ε��� ������Ʈ�� �±׸� Ȯ��
        {
            Debug.Log("PlayerHit");

            Vector2 contactPoint = collision.transform.position; // �浹 ���� ���� �������� (ù ��° �浹 ������ ���)

            // �浹 ������ ��ƼŬ �ý��� ����
            SpawnPlayerCollisionParticles(contactPoint);
        }
    }
}
