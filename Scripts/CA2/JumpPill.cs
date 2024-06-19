using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPill : Interactable
{
    // Code gets audio from Unity project itself.
    // Cannot use AudioSource due to object deleting itself
    [SerializeField]
    private AudioClip jumpAudio;

    // Jump height multiplier
    public static float jumpManipulate = 1.5f;
    // Link to player object
    public GameObject playerSettings;

    // Show "jump" type buff
    string buffType = "jump";

    // When object is interacted
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);
        // Confirm collection
        Debug.Log("Jump Up!");
        // Call jump height change function
        JumpChange();
    }

    void JumpChange()
    {
        // Start playing audio here (will not be interrupted by GameObject deletion)
        // (Which audio variable to play, location to play audio, volume)
        AudioSource.PlayClipAtPoint(jumpAudio, transform.position, 1f);
        /*
        // Add jump buff UI
        GameManager.instance.ShowBuff(buffType);
        */
        // Multiply jump height by float variable
        playerSettings.GetComponent<StarterAssets.FirstPersonController>().JumpHeight *= jumpManipulate;
        // Remove object after interacted with
        Destroy(gameObject);
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
