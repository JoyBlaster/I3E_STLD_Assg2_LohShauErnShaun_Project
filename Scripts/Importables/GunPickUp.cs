/*
 * Author: Loh Shau Ern Shaun
 * Date: 19/06/2024
 * Description: 
 * Picking up the weapon through an interactable model.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunPickUp : Interactable
{
    /// <summary>
    /// Audio for picking up gun
    /// </summary>
    [SerializeField]
    private AudioSource clackAudio;

    /// <summary>
    /// Link object to gun model in player hand
    /// </summary>
    public GameObject showGun;

        /// <summary>
    /// Link object to gun model in player hand
    /// </summary>
    public bool pickUp;

    /// <summary>
    /// When gun model interacted with
    /// </summary>
    /// <param name="thePlayer"> Reference to player object </param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);
        // Confirm collection
        Debug.Log("Gun picked up");
        // Gun is being held
        pickUp = true;
        // Start playing audio here
        clackAudio.Play();
        // Carry out function of picking up gun
        PickUpGun();
    }

    /// <summary>
    /// When function for picking up gun is done
    /// </summary>
    public void PickUpGun()
    {
        // Set gun in player hand to visible
        showGun.SetActive(true);
        // Save info of gun being picked up
        GameManager.instance.GunPickedUp(true);
        // Destoying obj
        Debug.Log("Destorying");
        // Destroy the object
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.gunHeld == true)
        {
            Debug.Log("Gun alr picked up");
            PickUpGun();
        }
        else
        {
            Debug.Log("Gun not picked up yet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
