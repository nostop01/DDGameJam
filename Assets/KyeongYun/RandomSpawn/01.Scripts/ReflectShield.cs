using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReflectShield : MonoBehaviour
{
    public GameObject shieldCollider;

    private void Start()
    {
        shieldCollider.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            shieldCollider.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("¹Ð·Á³²!");
        }
    }
}
