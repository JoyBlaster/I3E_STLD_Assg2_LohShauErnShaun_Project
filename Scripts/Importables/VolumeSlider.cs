using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField]
    private AudioMixer myMixer;

    public void SetMusicVolume(float volume)
    {
        myMixer.SetFloat("Music", volume);
    }
    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat("SFX", volume);
    }
}
