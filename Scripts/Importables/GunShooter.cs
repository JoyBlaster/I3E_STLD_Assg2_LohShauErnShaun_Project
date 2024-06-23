/*
 * Author: Loh Shau Ern Shaun
 * Date: 20/06/2024
 * Description: 
 * Firing with the weapon when active & not paused
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooter : MonoBehaviour
{
    /// <summary>
    /// Variables to set weapon stats
    /// </summary>
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 8f;

    /// <summary>
    /// References player camera
    /// </summary>
    public Camera fpsCam;
    /// <summary>
    /// References muzzle flash particles
    /// </summary>
    public ParticleSystem muzzleFlash;
    /// <summary>
    /// References bullet impact effect
    /// </summary>
    public GameObject impactFlash;
    /// <summary>
    /// Reference to pause menu UI
    /// </summary>
    public GameObject pauseMenu;
    /// <summary>
    /// Link to player hp bar UI
    /// </summary>
    public PlayerHP hpBar;

    /// <summary>
    /// Audio for picking up gun
    /// </summary>
    [SerializeField]
    private AudioSource shootAudio;

    /// <summary>
    /// Variable to keep track of intervals between firing weapon
    /// </summary>
    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If LMB is pressed / held and weapon not on cooldown
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            // Set variable of whether game is paused or not
            bool pauseState = pauseMenu.GetComponent<PauseMenu>().GameIsPaused;
            // Set variable of whether game is paused or not
            bool lifeState = hpBar.GameIsOver;
            // If game is not paused
            if (!pauseState && !lifeState)
            {
                // Reset cooldown interval between firing
                nextTimeToFire = Time.time + 1f / fireRate;
                // Carry out Shoot function
                Shoot();
            }
            // If game is paused
            else
            {
                // Debug log no shooting
                Debug.Log("No shooting while game is paused");
            }
        }
    }

    /// <summary>
    /// When gun is fired
    /// </summary>
    void Shoot()
    {
        // Play shooting effect from gun
        muzzleFlash.Play();
        // Play shooting sfx from gun
        shootAudio.Play();

        // Save object being looked at by camera as "hit"
        RaycastHit hit;
        // If hitting an object
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Send object name to debug log
            Debug.Log(hit.transform.name);
            // Set target as either an object with "Shootables" component or null
            Shootables target = hit.transform.GetComponent<Shootables>();
            // If target has component "Shootables"
            if (target != null)
            {
                // Do dmg to target object
                target.TakeDamage(damage);
            }
            // Create bullet impact on the hit spot
            GameObject impactGO = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
            // Remove the bullet impact effect after 2 seconds (reduces assets loaded)
            Destroy(impactGO, 2f);
        }
    }
}
