using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider fxslider;

    private void Start()
    {
        LoadVolume();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }
    public void SetFXVolume(float volume)
    {
        audioMixer.SetFloat("FX", Mathf.Log10(volume) * 20);
    }

    public void ApplyAudioSettings()
    {
        PlayerPrefs.SetFloat("musicvolume", musicslider.value);
        PlayerPrefs.SetFloat("fxvolume", fxslider.value);
    }

    public void ResetVolume()
    {
        PlayerPrefs.DeleteAll();
    }

    private void LoadVolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicvolume");
        fxslider.value = PlayerPrefs.GetFloat("fxvolume");
        ApplyAudioSettings();
    }
}
