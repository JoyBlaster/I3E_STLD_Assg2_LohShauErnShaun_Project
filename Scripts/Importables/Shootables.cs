using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shootables : MonoBehaviour
{
    [SerializeField]
    private float health = 50f;
    public Slider healthBar;

    /// <summary>
    /// Audio for damaging enemy
    /// </summary>
    [SerializeField]
    private AudioSource hitAudio;
    /// <summary>
    /// Audio for defeating enemy
    /// </summary>
    [SerializeField]
    private AudioSource killAudio;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        // Start playing audio here
        hitAudio.Play();
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        killAudio.Play();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }
}
