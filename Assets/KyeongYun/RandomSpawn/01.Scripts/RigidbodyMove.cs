using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    Rigidbody2D rb2D;
    float speed = 5f;
    float smoothTime = 0.3f;

    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 lastInputDirection = Vector2.zero;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputDirection.Normalize();

        if (inputDirection.magnitude > 0)
        {
            // 플레이어가 입력을 주면 입력 방향 저장
            lastInputDirection = inputDirection;
        }

        MoveCharacter(lastInputDirection);
    }

    void MoveCharacter(Vector2 direction)
    {
        // 이동 방향에 따라 속도를 부드럽게 조절
        Vector2 targetVelocity = direction * speed;
        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref currentVelocity, smoothTime);
    }
}
