/*
 * Author: Loh Shau Ern Shaun
 * Date: 18/06/2024
 * Description: 
 * Handles the menu UI button sounds, starting the game, and closing the application.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Variable for audio ButtonSFX
    /// </summary>
    [SerializeField]
    private AudioSource buttonSelect;

    /// <summary>
    /// When game is started
    /// </summary>
    public void PlayGame()
    {   
        // Load the next game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// When button is pressed
    /// </summary>
    public void ButtonSelect()
    {
        // Play buttonSFX sound
        buttonSelect.Play();
    }

    /// <summary>
    /// Close the application
    /// </summary>
    public void QuitGame()
    {
        // Quit application
        Application.Quit();
    }
}
