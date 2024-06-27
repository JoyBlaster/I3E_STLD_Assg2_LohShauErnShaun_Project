/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Health upgrade module that can be collected by player and boosts hp by 50%
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Collectible
{
    /// <summary>
    /// Link to max hp and current hp
    /// </summary>
    public GameObject maxHealth;
    /// <summary>
    /// Links to power upgrade 
    /// </summary>
    public PowerUpgrade powerTaken;
    /// <summary>
    /// Links to health upgrade 
    /// </summary>
    public SpeedUpgrade speedTaken;
    /// <summary>
    /// Audio for maxxed out buff
    /// </summary>
    [SerializeField]
    private AudioSource maxAudio;

    /// <summary>
    /// Maximum health to add per upgrade
    /// </summary>
    public float healthManipulate = 50f;

    /// <summary>
    /// Show "health" type buff
    /// </summary>
    string buffType = "health";

    /// <summary>
    /// Number of times to accept buff upgrades
    /// </summary>
    public int canBuff = 1;

    /// <summary>
    /// Player interacts with the health buff module
    /// </summary>
    public override void BuffTaken()
    {
        // Get current number of times hp was buffed
        int count = BuffManager.instance.currentHp;
        // If buffed fewer than 3 times
        if (count < 3)
        {
            if (buffType == "health")
            {
                // Call the original BuffTaken function from the base Collectible class.
                base.BuffTaken();
                // Add health buff UI
                BuffManager.instance.ShowBuff(buffType);
                // Add to current health by float variable
                maxHealth.GetComponent<PlayerHP>().health += healthManipulate;
                // Add to maximum health by float variable
                maxHealth.GetComponent<PlayerHP>().healthMax += healthManipulate;
                // Lower number of times that player can buff
                canBuff -= 1;
            }
        }
        // If buffed more than 3 times
        else 
        {
            Debug.Log("No more hp.");
            // Play maxxed out upgrade audio
            maxAudio.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Number of times buffed so far
        int count = BuffManager.instance.currentHp;
        // Amount to increase hp by
        float buffStart = healthManipulate * count;
        // Set damage to current buff lvl
        maxHealth.GetComponent<PlayerHP>().health += buffStart;
        maxHealth.GetComponent<PlayerHP>().healthMax += buffStart;
    }

    // Update is called once per frame
    void Update()
    {
        // If power upgrade was taken
        int power = powerTaken.canBuff;
        // If speed upgrade was taken
        int speed = speedTaken.canBuff;
        //If any buff was taken
        if (canBuff == 0 || power == 0 || speed == 0)
        {
            // Destroy script
            Destroy(this);
        }
    }
}
