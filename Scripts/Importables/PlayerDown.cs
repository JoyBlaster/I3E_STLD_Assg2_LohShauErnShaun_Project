using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDown : MonoBehaviour
{
    /// <summary>
    /// Link to gameover screen UI object
    /// </summary>
    public GameObject goScreen;
    /// <summary>
    /// Link to reticle UI object
    /// </summary>
    public GameObject reticleUI;
    /// <summary>
    /// Link to following player camera object
    /// </summary>
    public GameObject playerCamera;

    /// <summary>
    /// Link to player hp bar UI
    /// </summary>
    public PlayerHP hpBar;

    public void GameOver()
    {
        goScreen.SetActive(true);
        // Hide reticle
        reticleUI.SetActive(false);
        // Turn off following camera object
        playerCamera.SetActive(false);
        // Stop flow of time
        Time.timeScale = 0f;
        // Show cursor
        Cursor.visible = true;
        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide gameover screen when starting game
        goScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GO Menu");
        bool koState = hpBar.GameIsOver;
        Debug.Log(koState);
        // If target has component "Shootables"
        if (koState == true)
        {
            goScreen.SetActive(true);
            GameOver();
        }
    }
}
