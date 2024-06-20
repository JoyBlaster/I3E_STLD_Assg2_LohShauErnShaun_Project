/*
 * Author: Loh Shau Ern Shaun
 * Date: 18/06/2024
 * Description: 
 * Pauses the game and shows the pause menu UI */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Set game as paused variable to false
    /// </summary>
    public bool GameIsPaused = false;

    /// <summary>
    /// Audio for pausing game
    /// </summary>
    [SerializeField]
    private AudioSource pauseAudio;

    /// <summary>
    /// Link to pause menu UI object
    /// </summary>
    public GameObject pauseMenuUI;
    /// <summary>
    /// Link to reticle UI object
    /// </summary>
    public GameObject reticleUI;

    /// <summary>
    /// Link to following player camera object
    /// </summary>
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Hide pause menu when starting game
        pauseMenuUI.SetActive(false);
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        // When player presses the ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if game is alr paused
            if (GameIsPaused)
            {
                // Resume the game
                Resume();
            }
            else
            {
                // Play pause sfx
                pauseAudio.Play();
                // Pause the game
                Pause();
            }
        }
    }

    /// <summary>
    /// Continue the game
    /// </summary>
    public void Resume()
    {
        // Set pause menu to hidden
        pauseMenuUI.SetActive(false);
        // Show reticle
        reticleUI.SetActive(true);
        // Continue flow of time
        Time.timeScale = 1f;
        // Turn off following camera object
        playerCamera.SetActive(true);
        // Hide cursor
        Cursor.visible = true;
        // Lock the cursor to first person
        Cursor.lockState = CursorLockMode.Locked;
        // Set game is paused to false
        GameIsPaused = false; 
    }

    /// <summary>
    /// Set game to paused
    /// </summary>
    public void Pause()
    {
        // Set pause menu to active
        pauseMenuUI.SetActive(true);
        // Hide reticle
        reticleUI.SetActive(false);
        // Stop flow of time
        Time.timeScale = 0f;
        // Turn off following camera object
        playerCamera.SetActive(false);
        // Show cursor
        Cursor.visible = true;
        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        // Set game is paused to true
        GameIsPaused = true;
    }

    /// <summary>
    /// Return to title screen
    /// </summary>
    public void MenuSwitch()
    {
        // Removing gun from player when going back to main menu
        GameManager.instance.GunPickedUp(false);
        // Send player back to main menu scene
        SceneManager.LoadScene(0);
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