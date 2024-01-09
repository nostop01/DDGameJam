using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        audioSource.clip = clip;
    }

    public void OnSFXSoundPlay()
    {
        audioSource.Play();
    }
}
