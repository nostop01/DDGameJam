using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    float waveTime = 3;
    float countdown = 2;
    int currentWave = 1;
    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            StartCoroutine(WaveStart());
        }
    }

    IEnumerator WaveStart()
    {
        for (int i = 0; i < currentWave; i++)
        {
            yield return new WaitForSeconds(1f);  // 적 사이의 딜레이
        }

        currentWave++;
    }
}