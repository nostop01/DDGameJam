using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainTabBestScore : MonoBehaviour
{
    public TMP_Text BestScore;

    public float BestScorefloat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BestScorefloat = PlayerPrefs.GetFloat("BestScore");
        BestScore.text = "최고 기록!\n" + TimeSpan.FromSeconds(BestScorefloat).ToString(@"mm\:ss");
    }
}
