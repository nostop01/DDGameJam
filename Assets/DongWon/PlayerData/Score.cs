using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float CurrentScore;

    public bool DuringGame = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(DuringGame)
        {
            CurrentScore += Time.deltaTime;
        }
    }
}
