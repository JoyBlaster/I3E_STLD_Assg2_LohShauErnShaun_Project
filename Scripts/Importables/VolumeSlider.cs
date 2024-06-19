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
    /// Variable to check if a GameManager component is alr running
    /// </summary>
    public static VolumeChanger instance;

    /// <summary>
    /// Link the Audio Mixer to the sliders for adjustment
    /// </summary>
    [SerializeField]
    private AudioMixer myMixer;

    /// <summary>
    /// Allows volume changes to save data across scenes
    /// </summary>
    private void Awake()
    {
        // If there is NO VolumeChanger component running yet
        if (instance == null)
        {
            // Carry out this
            instance = this;
            // Set game object to DontDestroyOnLoad
            DontDestroyOnLoad(gameObject);
        }
        // If GameManager ALREADY exists
        else if (instance != null && instance != this)
        {
            // Destroy this current newly made game object
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Change Music volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the music volume </param>
    public void SetMusicVolume(float volume)
    {
        myMixer.SetFloat("Music", volume);
    }

    /// <summary>
    /// Change SFX volume based on slider
    /// </summary>
    /// <param name="volume"> Value of the sfx volume </param>
    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat("SFX", volume);
    }
}