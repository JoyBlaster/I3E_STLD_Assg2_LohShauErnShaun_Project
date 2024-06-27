/*
 * Author: Loh Shau Ern Shaun
 * Date: 21/06/2024
 * Description: 
 * Object can be shot by and destroyed by player weapon
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shootables : MonoBehaviour
{
    /// <summary>
    /// Shootable object hp
    /// </summary>
    [SerializeField]
    private float health = 50f;
    /// <summary>
    /// Link to enemy health bar UI
    /// </summary>
    public Slider healthBar;

    /// <summary>
    /// Reference to entire enemy object
    /// </summary>
    public GameObject enemyObj;

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
