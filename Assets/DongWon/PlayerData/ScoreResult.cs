using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    public TMP_Text CurrentScore;
    public TMP_Text BestScore;

    public float currentScore;
    public float bestScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("CurrentScore");
        bestScore = PlayerPrefs.GetFloat("BestScore");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = "버틴 시간 - " + TimeSpan.FromSeconds(currentScore).ToString(@"mm\:ss");
        BestScore.text = "최고 기록 - " + TimeSpan.FromSeconds(bestScore).ToString(@"mm\:ss");
    }
}
