using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrap : MonoBehaviour
{
    /// <summary>
    /// Reference to lava warning object
    /// </summary>
    public GameObject lavaPrepare;
    /// <summary>
    /// Reference to lava object
    /// </summary>
    public GameObject lavaHazard;

    /// <summary>
    /// Audio for lava warning
    /// </summary>
    [SerializeField]
    private AudioSource lavaWarn;

    /// <summary>
    /// Variable to keep track of intervals between firing weapon
    /// </summary>
    private float lavaCooldown = 4f;
    private float lavaWarning = 6f;
    private float lavaActive = 6.5f;

    /// <summary>
    /// Keeps the current time in cycle
    /// </summary>
    private float currentTime;
    /// <summary>
    /// Boolean to determine whether sound can be played in cycle
    /// </summary>
    private bool playSound = true;

    // Start is called before the first frame update
    void Start()
    {
        lavaPrepare.SetActive(false);
        lavaHazard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Increase time by frame
        currentTime += Time.deltaTime;
        // When 4 second cooldown passed
        if (currentTime >= lavaCooldown && currentTime < lavaWarning)
        {
            // Show lava warning
            lavaPrepare.SetActive(true);
            if (playSound)
            {
                // Play warning audio
                lavaWarn.Play();
            }
            playSound = false;
            
        }
        // After showing 2 second warning
        else if (currentTime >= lavaWarning && currentTime < lavaActive)
        {
            // Hide warning object
            lavaPrepare.SetActive(false);
            // Activate lava object
            lavaHazard.SetActive(true);
        }
        // After activating lava hazard for 0.5 seconds
        else if (currentTime >= lavaActive)
        {
            // Hide lava hazard object
            lavaHazard.SetActive(false);
            // Reset timer cycle
            currentTime = 0;
            // Reset play sound variable
            playSound = true;
        }
    }
}
