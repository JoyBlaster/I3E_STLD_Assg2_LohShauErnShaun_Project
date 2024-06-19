/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    /// <summary>
    /// Variable to check if a GameManager object is alr running
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Variable to store values for sfx and music volumes
    /// </summary>
    private int musicValue;
    private int sfxValue;

    /// <summary>
    /// If GameManager object not created yet, create object
    /// </summary>
    private void Awake()
    {
        // If there is NO GameManager object running yet
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
    /// Stores change in sfx volume
    /// </summary>
    /// <param name="SFX"> SFX volume variable </param>
    public void SFXChange(float SFX)
    {
        sfxValue = SFX;
    }

    /// <summary>
    /// Stores change in music volume
    /// </summary>
    /// <param name="music"> Music volume variable </param>
    public void MusicChange(float music)
    {
        musicValue = music;
    }

}
*/