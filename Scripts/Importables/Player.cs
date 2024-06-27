/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * Contains functions related to the Player such as increasing score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    // Reference to player camera
    [SerializeField]
    Transform playerCamera;

    // Maximum raycast distance
    [SerializeField]
    float interactionDistance;

    public GameObject interactionText;

    private void Update()
    {
        // Start and end of line
        Debug.DrawLine(playerCamera.position,playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        // Raycast hit variable (holds raycast info if it hits anything)
        RaycastHit hitInfo;
        // Send raycast out every frame (position of camera, direction of rays, hitting rays variable, max raycast distance)
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            // Print out name of whatever ray hits
            Debug.Log(hitInfo.transform.name);
            // When detecting object with raycast, check if object has component "Interactable".
            // If "Interactable" component is found in object, save object as "currentInteractable"
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                // Display some interaction text
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                // If component not found, set "currentInteractable" to nothing
                // Also don't display interaction text
                currentInteractable = null;
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            // If player is looking at nothing, set "currentInteractable" to nothing
            // Also don't display interaction text
            currentInteractable = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    // Callback function for the Interact input action
    void OnInteract()
    {
        // Check if the current Interactable is null
        if(currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}
