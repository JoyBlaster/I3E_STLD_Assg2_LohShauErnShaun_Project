/*
 * Author: Loh Shau Ern Shaun
 * Date: 19/06/2024
 * Description: 
 * Stores various data across different scenes */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Variable to check if a GameManager object is alr running
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Variable to check if gun has been picked up before
    /// </summary>
    public bool gunHeld;

    /// <summary>
    /// Allows volume changes to save data across scenes
    /// </summary>
    private void Awake()
    {
        // If there is NO GameManager component running yet
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
    /// Variable to handle picking up the gun
    /// </summary>
    /// <param name="pickUp"> Boolean for picking up weapon </param>
    public void GunPickedUp(bool pickUp) 
    {
        // When picked up variable is true
        if (pickUp)
        {
            Debug.Log("Gun is alr picked up");
            // Set gunHeld variable to true
            gunHeld = true;
        }
        else if (!pickUp)
        {
            Debug.Log("Gun is not picked up yet");
            gunHeld = false;
        }
        else
        {
            Debug.Log("Gun is not picked up");
        }
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