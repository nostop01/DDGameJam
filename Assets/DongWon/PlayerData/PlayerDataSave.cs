using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    public float PlayerBestScore;
    public float PlayerScore;
    public float SFXSetting;
    public float BGMSetting;

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

    public void DataSave()
    {
        PlayerPrefs.SetFloat("BestScore", PlayerBestScore);
        PlayerPrefs.SetFloat("SFXSetting", SFXSetting);
        PlayerPrefs.SetFloat("BGMSetting", BGMSetting);
    }
    
    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void DataLoad()
    {
        PlayerBestScore = PlayerPrefs.GetFloat("BestScore");
        SFXSetting = PlayerPrefs.GetFloat("SFXSetting");
        BGMSetting = PlayerPrefs.GetFloat("BGMSetting");
    }


}
