/*
 * Author: Loh Shau Ern Shaun
 * Date: 18/06/2024
 * Description: 
 * Handles the volume UI sliders */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    /// <summary>
    /// Link the Audio Mixer to the sliders for adjustment
    /// </summary>
    [SerializeField]
    private AudioMixer myMixer;

    /// <summary>
    /// References sliders
    /// </summary>
    public Slider musicSlider;
    public Slider sfxSlider;

    /// <summary>
    /// References sliders
    /// </summary>
    public float musicSliderValue = 0;
    public float sfxSliderValue = 0;

    /// <summary>
    /// Change Music volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the music volume </param>
    public void SetMusicVolume(float volume)
    {
        myMixer.SetFloat("Music", volume);
        if (volume <= -30)
        {
            myMixer.SetFloat("Music", -80);
        }
        PlayerPrefs.SetFloat("musicVol",volume);
    }

    /// <summary>
    /// Change SFX volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the sfx volume </param>
    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat("SFX", volume);
        if (volume <= -30)
        {
            myMixer.SetFloat("SFX", -80);
        }
        PlayerPrefs.SetFloat("sfxVol", volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSliderValue = PlayerPrefs.GetFloat("musicVol");
        myMixer.SetFloat("Music", musicSliderValue);
        musicSlider.value = musicSliderValue;

        sfxSliderValue = PlayerPrefs.GetFloat("sfxVol");
        myMixer.SetFloat("SFX", sfxSliderValue);
        sfxSlider.value = sfxSliderValue;
    }
}