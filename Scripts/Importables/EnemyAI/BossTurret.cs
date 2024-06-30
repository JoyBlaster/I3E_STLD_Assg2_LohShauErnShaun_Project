using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    /// <summary>
    /// Referecne player object
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Reference player hp UI script
    /// </summary>
    public PlayerHP hpScript;
    /// <summary>
    /// Reference enemy turret head
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// Reference turret projectile object
    /// </summary>
    public GameObject projectile;
    /// <summary>
    /// Reference enemy turret gun spawner
    /// </summary>
    public GameObject spawner;
    /// <summary>
    /// References turret flash particles
    /// </summary>
    public ParticleSystem turretFlash;

    /// <summary>
    /// Audio for turret shooting
    /// </summary>
    [SerializeField]
    private AudioSource turretAudio;

    /// <summary>
    /// Speed of turret projectile
    /// </summary>
    public float bulletSpeed = 50f;
    /// <summary>
    /// Turret rate of fire
    /// </summary>
    public float fireRate = 1f;
    /// <summary>
    /// Damage of each bullet
    /// </summary>
    public float bullDamage = 10f;

    /// <summary>
    /// Variable to keep track of intervals between firing weapon
    /// </summary>
    private float nextTimeToFire = 0f;

    /// <summary>
    /// References Enemy Detection component
    /// </summary>
    public BossDetect detectionStatus;

    private void Shoot()
    {
        // Get player position from turret
        Vector3 relativePos = player.transform.position - transform.position;
        // Get player direction from turret
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        // Turn to face player
        transform.rotation = rotation;
        // Shoot at every interval
        if (Time.time >= nextTimeToFire)
        {
            // Play audio for turret shooting
            turretAudio.Play();
            // Reset cooldown interval between firing
            nextTimeToFire = Time.time + 1f / fireRate;
            // Play turrret flash effect
            turretFlash.Play();
            // Create projectile object
            GameObject bulletClone = Instantiate(projectile, spawner.transform.position, rotation);
            // Set dmg of each shot to bullDamage variable
            bulletClone.GetComponent<TurretBullet>().damage = bullDamage;
            // Set player position as direction
            Vector3 shootForth = relativePos;
            // Set bullet direction
            shootForth *= bulletSpeed;
            // Apply force to bullet
            bulletClone.GetComponent<Rigidbody>().AddForce(shootForth);
            // Remove the turret bullets after 2 seconds (reduces assets loaded)
            Destroy(bulletClone, 4f);
        }
    }

    /// <summary>
    /// While in contact with enemy turret
    /// </summary>
    /// <param name="collision"> Object collided with </param>
    void OnCollisionEnter(Collision collision)
    {
        // If collided with player objects
        if (collision.gameObject.tag == "Player")
        {
            // Carry out TakeDamage function
            hpScript.TakeDamage(1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool detected = detectionStatus.detected;
        // Debug log whether player has been detected
        Debug.Log(detected);
        // If player has been detected
        if (detected == true)
        {
            // Debug log
            Debug.Log("Turret detecting!");
            // Turret starts shooting at player
            Shoot();
        }
        // If player not detected
        else
        {
            // Don't shoot
            return;
        }
    }
}
