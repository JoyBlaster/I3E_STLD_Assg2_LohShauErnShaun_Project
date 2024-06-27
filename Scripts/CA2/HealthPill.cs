using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPill : Collectible
{
    /// <summary>
    /// Link to player object
    /// </summary>
    public GameObject playerSettings;
    /// <summary>
    /// Link to max hp and current hp
    /// </summary>
    public PlayerHP maxHealth;

    /// <summary>
    /// Maximum health to add per upgrade
    /// </summary>
    public float healthManipulate = 50f;

    /// <summary>
    /// Show "health" type buff
    /// </summary>
    string buffType = "health";

    
    public override void BuffTaken()
    {
        // Call the original BuffTaken function from the base Collectible class.
        base.BuffTaken();
        /*
        // Add speed buff UI
        GameManager.instance.ShowBuff(buffType);
        */
        // Add to current health by float variable
        maxHealth.health += healthManipulate;
        // Add to maximum health by float variable
        maxHealth.healthMax += healthManipulate;
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
