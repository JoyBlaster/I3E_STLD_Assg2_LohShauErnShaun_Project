using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSelect;

    public void PlayGame()
    {
        buttonSelect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        buttonSelect.Play();
    }

    public void OpenControls()
    {
        buttonSelect.Play();
    }

    public void OpenCredits()
    {
        buttonSelect.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
