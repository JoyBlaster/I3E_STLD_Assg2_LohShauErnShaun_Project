/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Detecing player for boss, spawns a forcefield when player is detected to close player into an arena
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetect : MonoBehaviour
{
    /// <summary>
    /// Reference enemy noticed UI
    /// </summary>
    public GameObject enemyNoticed;
    /// <summary>
    /// Audio for enemy detecting player
    /// </summary>
    [SerializeField]
    private AudioSource detectAudio;
    /// <summary>
    /// Reference to forcefield
    /// </summary>
    public GameObject closeArena;

    /// <summary>
    /// Variable for if player has been detected
    /// </summary>
    public bool detected = false;
    /// <summary>
    /// Variable for starting timer for UI popup
    /// </summary>
    private bool startCount = false;

    /// <summary>
    /// Variable for how long to make the timer
    /// </summary>
    private float endTime = 3f;
    /// <summary>
    /// Variable to store the current time in timer
    /// </summary>
    private float currentTime = 0f;

    /// <summary>
    /// When entering enemy detection radius
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // If player object entered radius
        if (other.gameObject.tag == "Player")
        {
            // Set detected to true
            detected = true;
            // Play the detected sfx
            detectAudio.Play();
            // Start the timer
            startCount = true;
            // Show the enemy noticed UI
            enemyNoticed.SetActive(true);
            // Show the arena forcefield
            closeArena.SetActive(true);
            // Disable the sphere collider
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide the enemy noticed UI
        enemyNoticed.SetActive(false);
        // Hide the arena forcefield
        closeArena.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer is started
        if (startCount == true)
        {
            // Clock the current time
            currentTime += Time.deltaTime;
            // If timer is up
            if (currentTime >= endTime)
            {
                // Hide the enemy noticed UI
                enemyNoticed.SetActive(false);
            }
        }
    }
}
