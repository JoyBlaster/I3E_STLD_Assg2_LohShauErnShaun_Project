using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
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
            playerObj.GetComponent<PlayerHP>().TakeDamage(10f);
            // Destroy self after hitting player
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            // Destroy self when hitting obstacle
            Destroy(gameObject);
        }
        else 
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SHOTS FIRED SHOTS FIRED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
