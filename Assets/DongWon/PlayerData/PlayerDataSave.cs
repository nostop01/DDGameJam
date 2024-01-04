using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    public float PlayerBestScore = 0;
    public float PlayerScore = 0;

    Score score;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore = score.CurrentScore;

        if (PlayerBestScore < PlayerScore)
        {
            PlayerBestScore = PlayerScore;
        }
    }
    
    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
