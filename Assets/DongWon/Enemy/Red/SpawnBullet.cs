using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public float Timer = 0;

    [SerializeField]
    private Transform bulletSpawnTrm;

    private Vector3 bulletSpawnVec;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!PlayerMovement.PauseGame)
        {
            Timer += Time.deltaTime;
            bulletSpawnVec = bulletSpawnTrm.position;

            if (Timer >= 2f)
            {
                SpawnTheBullet();
                Timer = 0f;
            }
        }        
    }

    private void SpawnTheBullet()
    {
        var bullet = ObjectPoolManager.instance.GetGo("Bullet");
        bullet.transform.position = bulletSpawnVec;
    }
}
