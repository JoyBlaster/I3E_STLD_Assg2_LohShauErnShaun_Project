/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Ogre Man boss behaviour. Object will chase player when detected and deal dmg to player, spawns enemies every 20% threshold
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OgreManBehaviour : MonoBehaviour
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
    /// Reference boss shootables hp script
    /// </summary>
    public BossShootables hpRemaining;

    /// <summary>
    /// Reference player object
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Reference enemy object
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// Reference Brawler Clone enemy
    /// </summary>
    public GameObject enemySpawn;
    /// <summary>
    /// Reference spawner1 object
    /// </summary>
    public GameObject spawner1;
    /// <summary>
    /// Reference spawner2 object
    /// </summary>
    public GameObject spawner2;
    /// <summary>
    /// Reference spawner3 object
    /// </summary>
    public GameObject spawner3;

    /// <summary>
    /// Ogre Boss max hp
    /// </summary>
    private float maxHp = 400f;
    /// <summary>
    /// Threshold for boss hp to spawn clones
    /// </summary>
    private float threshold2 = 300f;
    private float threshold3 = 200f;
    private float threshold4 = 100f;

    /// <summary>
    /// Boolean of threshold boss hp
    /// </summary>
    private bool underthreshold2 = false;
    private bool underthreshold3 = false;
    private bool underthreshold4 = false;

    /// <summary>
    /// Boolean to stop spawning clones
    /// </summary>
    private bool stopSummoning2 = false;
    private bool stopSummoning3 = false;
    private bool stopSummoning4 = false;

    /// <summary>
    /// References Enemy Detection component
    /// </summary>
    public EnemyDetection detectionStatus;
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

    /// <summary>
    /// Spawn Brawler clones in 3 positions
    /// </summary>
    void ThresholdReached()
    {
        if (underthreshold2 && !stopSummoning2)
        {
            Debug.Log("300 call");
            CallBackup();
            stopSummoning2 = true;
        }
        else if (underthreshold3 && !stopSummoning3)
        {
            Debug.Log("200 call");
            CallBackup();
            stopSummoning3 = true;
        }
        else if (underthreshold4 && !stopSummoning4)
        {
            Debug.Log("100 call");
            CallBackup();
            stopSummoning4 = true;
        }
    }

    void CallBackup()
    {
        //Spawn Brawler clone at each spawner location
        Instantiate(enemySpawn, spawner1.transform.position, Quaternion.identity).SetActive(true);
        Instantiate(enemySpawn, spawner2.transform.position, Quaternion.identity).SetActive(true);
        Instantiate(enemySpawn, spawner3.transform.position, Quaternion.identity).SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Variable that checks if player is detected
        bool detected = detectionStatus.detected;
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

        // Get variable of boss hp
        float currentHP = hpRemaining.GetComponent<BossShootables>().health;
        Debug.Log(currentHP);
        // If hp under 300 hp
        if (currentHP <= threshold2 && currentHP > threshold3)
        {
            Debug.Log("under 300");
            underthreshold2 = true;
            // Spawn brawlers
            ThresholdReached();
        }
        // If hp under 200 hp
        else if (currentHP <= threshold3 && currentHP > threshold4)
        {
            Debug.Log("under 200");
            underthreshold3 = true;
            // Spawn brawlers
            ThresholdReached();
        }
        // If hp under 100 hp
        else if (currentHP <= threshold4)
        {
            Debug.Log("under 100");
            underthreshold4 = true;
            // Spawn brawlers
            ThresholdReached();
        }
    }
}
