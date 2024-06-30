/*
 * Author: Loh Shau Ern Shaun
 * Date: 26/06/2024
 * Description: 
 * Handles game over menu UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    /// <summary>
    /// Link to gameover screen UI
    /// </summary>
    public PlayerDown goScreen;

    /// <summary>
    /// Restart the current level
    /// </summary>
    public void Restart()
    {
        // Obtain current player scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Send player back to main menu scene
        SceneManager.LoadScene(currentSceneName);
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
