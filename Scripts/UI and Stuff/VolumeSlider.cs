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
    /// References volume sliders
    /// </summary>
    public Slider musicSlider;
    public Slider sfxSlider;

    /// <summary>
    /// References volume float variables
    /// </summary>
    public float musicSliderValue = 0;
    public float sfxSliderValue = 0;

    /// <summary>
    /// Change Music volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the music volume </param>
    public void SetMusicVolume(float volume)
    {
        // Set Music mixer to volume variable
        myMixer.SetFloat("Music", volume);
        // If volume is less than -30
        if (volume <= -30)
        {
            // Set to -80
            myMixer.SetFloat("Music", -80);
        }
        // Store music volume changes in PlayerPrefs
        PlayerPrefs.SetFloat("musicVol",volume);
    }

    /// <summary>
    /// Change SFX volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the sfx volume </param>
    public void SetSFXVolume(float volume)
    {
        // Set SFX mixer to volume variable
        myMixer.SetFloat("SFX", volume);
        // If volume is less than -30
        if (volume <= -30)
        {
            // Set to -80
            myMixer.SetFloat("SFX", -80);
        }
        // Store sfx volume changes in PlayerPrefs
        PlayerPrefs.SetFloat("sfxVol", volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get music volume according to PlayerPrefs on start
        musicSliderValue = PlayerPrefs.GetFloat("musicVol");
        // Set mixer volume to volume
        myMixer.SetFloat("Music", musicSliderValue);
        // Set slider to volume 
        musicSlider.value = musicSliderValue;

        // Get sfx volume according to PlayerPrefs on start
        sfxSliderValue = PlayerPrefs.GetFloat("sfxVol");
        // Set mixer volume to volume
        myMixer.SetFloat("SFX", sfxSliderValue);
        // Set slider to volume
        sfxSlider.value = sfxSliderValue;
    }
}