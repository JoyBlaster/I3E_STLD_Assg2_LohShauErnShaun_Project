using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : MonoBehaviour
{    
    /// <summary>
     /// Set game over variable to false
     /// </summary>
    public bool GameIsOver = false;

    /// <summary>
    /// Player health value
    /// </summary>
    [SerializeField]
    private float health = 100f;
    /// <summary>
    /// Player max health value
    /// </summary>
    [SerializeField]
    private float healthMax = 100f;

    /// <summary>
    /// Link to player hp slider UI
    /// </summary>
    public Slider healthBar;
    /// <summary>
    /// Link to player hp text UI
    /// </summary>
    public TextMeshProUGUI percentText;

    /// <summary>
    /// Handles taking dmg
    /// </summary>
    public void TakeDamage(float dmg)
    {
        Debug.Log("Owie");
        // - hp by dmg per tick
        health -= dmg;
        // If hp 0 or lower
        if (health <= 0)
        {
            health = 0;
            // Carry out Death function
            Death();
        }
    }

    /// <summary>
    /// When player is dead
    /// </summary>
    void Death()
    {
        Debug.Log("Ded");
        // Set game is over to true
        GameIsOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get percentage of player hp
        float hpPerc = (health / healthMax) * 100;
        // Display hp percentage in health bar
        healthBar.value = hpPerc;
        // Display hp percentage as text
        percentText.text = hpPerc + " %";
    }
}
