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

    public void MasterAudioControl()
    {
        float sound = allSoundslider.value;

        if(sound == - 40f)
        {
            audioMixer.SetFloat("MasterSound", -80f);
        }
        else
        {
            audioMixer.SetFloat("MasterSound", sound);
        }
    }

    public void BGMAudioControl()
    {
        float sound = bgmSoundslider.value;

        if (sound == -40f)
        {
            audioMixer.SetFloat("BGMSound", -80f);
        }
        else
        {
            audioMixer.SetFloat("BGMSound", sound);
        }
    }

    public void SFXAudioControl()
    {
        float sound = sfxSoundslider.value;

        if (sound == -40f)
        {
            audioMixer.SetFloat("SFXSound", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFXSound", sound);
        }
    }

    public void SetVolumeSetting()
    {
        PlayerPrefs.SetFloat("AllSound", allSoundslider.value);
        PlayerPrefs.SetFloat("BGMSetting", bgmSoundslider.value);
        PlayerPrefs.SetFloat("SFXSetting", sfxSoundslider.value);
    }
}
