using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPill : Interactable
{
    // Code gets audio from Unity project itself.
    // Cannot use AudioSource due to object deleting itself
    [SerializeField]
    private AudioClip speedAudio;

    // Speed multiplier
    public static float speedManipulate = 1.5f;
    // Link to player object
    public GameObject playerSettings;

    // Show "speed" type buff
    string buffType = "speed";

    // When object is interacted
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);
        // Confirm collection
        Debug.Log("Speed Up!");
        // Call speed change function
        SpeedChange();
    }
    
    void SpeedChange()
    {
        // Start playing audio here (will not be interrupted by GameObject deletion)
        // (Which audio variable to play, location to play audio, volume)
        AudioSource.PlayClipAtPoint(speedAudio, transform.position, 1f);
        // Add speed buff UI
        GameManager.instance.ShowBuff(buffType);
        // Multiply walking and running speed by float variable
        playerSettings.GetComponent<StarterAssets.FirstPersonController>().MoveSpeed *= speedManipulate;
        playerSettings.GetComponent<StarterAssets.FirstPersonController>().SprintSpeed *= speedManipulate;
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
