/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Turret projectiles that do damage to player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    /// <summary>
    /// Variable for projectile damage
    /// </summary>
    public float damage;

    /// <summary>
    /// Bullet hits something
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // If hit player
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            // Do 10 dmg to player
            var playerObj = GameObject.FindGameObjectWithTag("HP bar");
            Debug.Log(playerObj);
            playerObj.GetComponent<PlayerHP>().TakeDamage(damage);
            // Destroy self after hitting player
            Destroy(gameObject);
        }
        // If hit obstacles
        else if (collision.gameObject.tag == "Obstacle")
        {
            // Destroy self when hitting obstacle
            Destroy(gameObject);
        }
        else 
        {
            // Do nothing
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Debug log shooting 
        Debug.Log("SHOTS FIRED SHOTS FIRED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
