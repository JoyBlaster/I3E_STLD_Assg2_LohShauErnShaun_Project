using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPill : Interactable
{
    // Code gets audio from Unity project itself.
    // Cannot use AudioSource due to object deleting itself
    [SerializeField]
    private AudioSource powerAudio;

    public GameObject powerJuice;

    // Speed multiplier
    public static float powerManipulate = 1.5f;
    // Link to player gun object
    public GunShooter gunSettings;

    // Show "power" type buff
    string buffType = "power";
    /// <summary>
    /// Number of times to upgrade
    /// </summary>
    private int buffCount = 1;
    /// <summary>
    /// Number of times to upgrade
    /// </summary>
    public static bool canBuff = true;

    // When object is interacted
    public override void Interact(Player thePlayer)
    {
        if (canBuff == true)
        {
            // Call the Interact function from the base Interactable class.
            base.Interact(thePlayer);
            // Confirm collection
            Debug.Log("Damage Up!");
            // Call speed change function
            PowerChange();
        }
    }

    void PowerChange()
    {
        // Start playing audio here (will not be interrupted by GameObject deletion)
        // (Which audio variable to play, location to play audio, volume)
        powerAudio.Play();
        /*
        // Add speed buff UI
        GameManager.instance.ShowBuff(buffType);
        */
        // Multiply damage speed by float variable
        gunSettings.damage *= powerManipulate;
        // Remove object after interacted with
        Destroy(powerJuice);
        if (buffCount == 0)
        {
            canBuff = false;
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
