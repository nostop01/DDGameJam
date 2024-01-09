using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBGMSetting : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
