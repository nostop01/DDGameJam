using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;

    public float CurrentScore;
    public int VisuleScore;

    public bool DuringGame = false;

    // Start is called before the first frame update
    void Start()
    {
        DuringGame = true;
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(DuringGame)
        {
            CurrentScore += Time.deltaTime;
        }

        VisuleScore = (int)CurrentScore;
        ScoreText.text = "Time: " + VisuleScore;

        if(EnergyStatus.EnergyHealth <= 0)
        {
            DuringGame = false;
        }
    }
}
