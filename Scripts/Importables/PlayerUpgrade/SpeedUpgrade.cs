/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Speed upgrade module that can be collected by player and boosts movement speed by 25%
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Collectible
{
    /// <summary>
    /// Link to player stats
    /// </summary>
    public GameObject playerSettings;
    /// <summary>
    /// Links to power upgrade 
    /// </summary>
    public PowerUpgrade powerTaken;
    /// <summary>
    /// Links to health upgrade 
    /// </summary>
    public HealthUpgrade healthTaken;
    /// <summary>
    /// Audio for maxxed out buff
    /// </summary>
    [SerializeField]
    private AudioSource maxAudio;

    /// <summary>
    /// Walk speed to add per upgrade
    /// </summary>
    public float walkManipulate = 1f;
    /// <summary>
    /// Run speed to add per upgrade
    /// </summary>
    public float runManipulate = 1.5f;

    /// <summary>
    /// Show "speed" type buff
    /// </summary>
    string buffType = "speed";

    /// <summary>
    /// Number of times to accept buff upgrades
    /// </summary>
    public int canBuff = 1;
    
    /// <summary>
    /// Player interacts with speed buff module
    /// </summary>
    public override void BuffTaken()
    {
        // Get current number of times spd was buffed
        int count = BuffManager.instance.currentSpd;
        // If buffed fewer than 3 times
        if (count < 3)
        {
            if (buffType == "speed")
            {
                // Call the original BuffTaken function from the base Collectible class.
                base.BuffTaken();
                // Add speed buff UI
                BuffManager.instance.ShowBuff(buffType);
                // Add to current health by float variable
                playerSettings.GetComponent<StarterAssets.FirstPersonController>().MoveSpeed += walkManipulate;
                // Add to maximum health by float variable
                playerSettings.GetComponent<StarterAssets.FirstPersonController>().SprintSpeed += runManipulate;
                // Lower number of times that player can buff
                canBuff -= 1;
            }
        }
        // If buffed more than 3 times
        else
        {
            Debug.Log("No more spd.");
            // Play maxxed out upgrade audio
            maxAudio.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Number of times buffed so far
        int count = BuffManager.instance.currentSpd;
        // Amount to increase walk spd by
        float buffStart1 = walkManipulate * count;
        // Amount to increase run spd by
        float buffStart2 = runManipulate * count;
        // Set damage to current buff lvl
        playerSettings.GetComponent<StarterAssets.FirstPersonController>().MoveSpeed = 4f + buffStart1;
        playerSettings.GetComponent<StarterAssets.FirstPersonController>().SprintSpeed = 6f + buffStart2;
    }

    // Update is called once per frame
    void Update()
    {
        // If power upgrade was taken
        int power = powerTaken.canBuff;
        // If health upgrade was taken
        int health = healthTaken.canBuff;
        // If any buff was taken
        if (canBuff == 0 || power == 0 || health == 0)
        {
            // Destroy script
            Destroy(this);
        }
    }
}
