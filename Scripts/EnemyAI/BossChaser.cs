/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Enemy chasing ai for bosses
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossChaser : MonoBehaviour
{
    /// <summary>
    /// Reference AI pathfinding
    /// </summary>
    public NavMeshAgent enemyChase;

    /// <summary>
    /// Reference player hp UI script
    /// </summary>
    public PlayerHP hpScript;

    /// <summary>
    /// Reference player object
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Reference enemy object
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// References Enemy Detection component
    /// </summary>
    public BossDetect detectionStatus;
    /// <summary>
    /// Variable to determine enemy contact dps
    /// </summary>
    public float dps;

    /// <summary>
    /// While in contact with enemy objects
    /// </summary>
    /// <param name="collision"> Object collided with </param>
    void OnCollisionEnter(Collision collision)
    {
        // If collided with player objects
        if (collision.gameObject.tag == "Player")
        {
            // Carry out TakeDamage function
            hpScript.TakeDamage(dps);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool detected = detectionStatus.detected;
        // Debug log whether player has been detected
        Debug.Log(detected);
        // If player has been detected
        if (detected == true)
        {
            // Set enemy to start chasing player
            enemyChase.SetDestination(player.transform.position);
        }
        // If player not detected
        else
        {
            // Don't move
            enemyChase.SetDestination(enemy.transform.position);
        }
    }
}
