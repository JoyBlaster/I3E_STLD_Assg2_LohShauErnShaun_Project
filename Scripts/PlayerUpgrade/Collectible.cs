/*
 * Author: Loh Shau Ern Shaun
 * Date: 25/06/2024
 * Description: 
 * Object is an upgrade module that can be collected by player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    /// <summary>
    /// Link the emissive power juice object
    /// </summary>
    public GameObject powerJuice;

    /// <summary>
    /// Audio for collecting buff
    /// </summary>
    [SerializeField]
    private AudioSource collectAudio;

    // When object is interacted
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);
        // Confirm collection
        Debug.Log("Buff Up!");
        // Call speed change function
        BuffTaken();
    }

    public virtual void BuffTaken()
    {
        // Play collecting buff sfx
        collectAudio.Play();
        // Remove power juice object
        Destroy(powerJuice);
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
