/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Plays the ending cutscene and shows congratulatory msg.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    /// <summary>
    /// Reference the end screen
    /// </summary>
    public GameObject endScreen;

    /// <summary>
    /// Reference cutscene
    /// </summary>
    public Animator cutscene;

    // Start is called before the first frame update
    void Start()
    {
        // Hide end screen
        endScreen.SetActive(false);
        Debug.Log("hidden end screen");
        // Play cutscene animation
        StartCoroutine(PlayAnim());
    }

    /// <summary>
    /// Play animation
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAnim()
    {
        // Start animation
        cutscene.SetTrigger("Play");
        // Wait for 7 seconds
        yield return new WaitForSeconds(6f);
        // Show end screen after animation
        endScreen.SetActive(true);
        Debug.Log("showing end screen");
        // Show cursor
        Cursor.visible = true;
        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
