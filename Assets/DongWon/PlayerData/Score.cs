using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;

    public float CurrentScore;
    public float BestScore;
    public int VisuleScore;

    public bool DuringGame = false;

    // Start is called before the first frame update
    void Start()
    {
        BestScore =  PlayerPrefs.GetFloat("BestScore");
        DuringGame = true;
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovement.PauseGame)
        {
            if (DuringGame)
            {
                CurrentScore += Time.deltaTime;
            }
        }

        VisuleScore = (int)CurrentScore;
        ScoreText.text = TimeSpan.FromSeconds(CurrentScore).ToString(@"mm\:ss");

        if(EnergyStatus.EnergyHealth <= 0)
        {
            DuringGame = false;
            PlayerPrefs.SetFloat("CurrentScore", CurrentScore);
        }

        SetBestScore();
    }

    public void SetBestScore()
    {
        if(CurrentScore >= BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetFloat("BestScore", BestScore);
        }
    }
}
