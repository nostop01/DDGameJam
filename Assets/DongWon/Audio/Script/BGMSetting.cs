using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMSetting : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SetAudioClipForScene(currentSceneName);
    }

    private void SetAudioClipForScene(string SceneName)
    {
        if(SceneName == "StartScene")
        {
            audioSource.clip = clip[0];
            audioSource.Play();
        }

        else if(SceneName == "PlayScene" || SceneName == "ResultScene")
        {
            audioSource.clip = clip[1];
            audioSource.Play();
        }
    }
}
