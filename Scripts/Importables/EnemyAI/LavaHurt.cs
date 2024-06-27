using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaHurt : MonoBehaviour
{
    /// <summary>
    /// Reference player hp UI script
    /// </summary>
    public PlayerHP hpScript;

    /// <summary>
    /// Variable to determine enemy contact dps
    /// </summary>
    public float dps;

    void OnTriggerStay(Collider other)
    {
        // If collided with player objects
        if (other.gameObject.tag == "Player")
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
        
    }
}
