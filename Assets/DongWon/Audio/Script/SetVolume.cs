using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider allSoundslider;
    public Slider bgmSoundslider;
    public Slider sfxSoundslider;

    private void Start()
    {
        allSoundslider.value = PlayerPrefs.GetFloat("AllSound");
        bgmSoundslider.value = PlayerPrefs.GetFloat("BGMSetting");
        sfxSoundslider.value = PlayerPrefs.GetFloat("SFXSetting");
    }

    public void SetMasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("AllSound", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("AllSound", sliderValue);
    }

    public void SetBGMVolume(float sliderValue)
    {
        audioMixer.SetFloat("BGMSound", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMSound", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        audioMixer.SetFloat("SFXSound", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXSound", sliderValue);
    }
}
