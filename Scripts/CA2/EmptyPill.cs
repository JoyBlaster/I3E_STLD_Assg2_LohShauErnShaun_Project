using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPill : Interactable
{
    // Code gets audio from Unity project itself.
    // Cannot use AudioSource due to object deleting itself
    [SerializeField]
    private AudioClip emptyAudio;
    
    // When object is interacted
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);
        // Confirm collection
        Debug.Log("Empty Pill!");
        // Start playing audio here (will not be interrupted by GameObject deletion)
        // (Which audio variable to play, location to play audio, volume)
        AudioSource.PlayClipAtPoint(emptyAudio, transform.position, 1f);
        // Destroys game object
        Destroy(gameObject);
    }
}
