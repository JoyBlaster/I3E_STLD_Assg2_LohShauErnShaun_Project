/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Object is a boss that can be shot by and destroyed by player weapon, and will remove force field when defeated
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossShootables : MonoBehaviour
{
    /// <summary>
    /// Shootable object hp
    /// </summary>
    public float health = 350f;
    /// <summary>
    /// Link to enemy health bar UI
    /// </summary>
    public Slider healthBar;

    /// <summary>
    /// Reference to entire enemy object
    /// </summary>
    public GameObject enemyObj;
    /// <summary>
    /// Reference to force field object
    /// </summary>
    public GameObject forceField;

    /// <summary>
    /// Audio for damaging enemy
    /// </summary>
    [SerializeField]
    private AudioSource hitAudio;
    /// <summary>
    /// Audio for defeating enemy
    /// </summary>
    [SerializeField]
    private AudioSource killAudio;

    /// <summary>
    /// When taking dmg
    /// </summary>
    /// <param name="dmg"> Amount of dmg done per bullet</param>
    public void TakeDamage(float dmg)
    {
        // Subtract dmg from hp
        health -= dmg;
        // Debug log enemy remaining hp
        Debug.Log(health);
        // Play hit audio
        hitAudio.Play();
        // If enemy hp is 0 or less
        if (health <= 0)
        {
            // Carry out Death function
            Death();
        }
    }

    /// <summary>
    /// When enemy is defeated
    /// </summary>
    void Death()
    {
        // Play defeated audio
        killAudio.Play();
        // Destroy force field object
        Destroy(forceField);
        // Destroy entire enemy object
        Destroy(enemyObj);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Constantly update enemy hp bar to current hp value
        healthBar.value = health;
    }
}
