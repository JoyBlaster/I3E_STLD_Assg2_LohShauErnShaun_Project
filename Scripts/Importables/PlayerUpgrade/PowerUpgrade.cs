/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Power upgrade module that can be collected by player and boosts dmg by 50%
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpgrade : Collectible
{
    /// <summary>
    /// Link to weapon object
    /// </summary>
    public GameObject gunPower;
    /// <summary>
    /// Links to power upgrade 
    /// </summary>
    public SpeedUpgrade speedTaken;
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
    /// Get current number of times dmg was buffed
    /// </summary>
    private float powerManipulate = 5f;
    
    /// <summary>
    /// Show "power" type buff
    /// </summary>
    string buffType = "power";

    /// <summary>
    /// Number of times to accept buff upgrades
    /// </summary>
    public int canBuff = 1;

    /// <summary>
    /// Player interacts with the dmg buff module
    /// </summary>
    public override void BuffTaken()
    {
        int count = BuffManager.instance.currentDmg;
        Debug.Log(count);
        // If buffed fewer than 3 times
        if (count < 3)
        {
            // When buff type is power
            if (buffType == "power")
            {
                Debug.Log("power up");
                // Call the original BuffTaken function from the base Collectible class.
                base.BuffTaken();
                // Add power buff UI
                BuffManager.instance.ShowBuff(buffType);
                // Add to damage by float variable
                gunPower.GetComponent<GunShooter>().damage = 10f + powerManipulate;
                // Lower number of times that player can buff
                canBuff -= 1;
            }
        }
        // If buffed more than 3 times
        else
        {
            Debug.Log("No more dmg.");
            // Play maxxed out upgrade audio
            maxAudio.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Number of times buffed so far
        int count = BuffManager.instance.currentDmg;
        // Amount to increase dmg by
        float buffStart = powerManipulate * count;
        // Set damage to current buff lvl
        gunPower.GetComponent<GunShooter>().damage += buffStart;
    }

    // Update is called once per frame
    void Update()
    {
        // If speed upgrade is taken
        int speed = speedTaken.canBuff;
        // If health upgrade is taken
        int health = healthTaken.canBuff;
        // If any buff was taken
        if (canBuff == 0 || speed == 0 || health == 0)
        {
            // Destroy script   
            Destroy(this);
        }
    }
}
