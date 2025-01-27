/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Buff Manager handles taking and storing player stat buffs across scenes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffManager : MonoBehaviour
{
    /// <summary>
    /// Create instance of BuffManager component
    /// </summary>
    public static BuffManager instance;

    /// <summary>
    /// Variables to indicate current buff count of each stat
    /// </summary>
    public int currentDmg = 0;
    public int currentSpd = 0;
    public int currentHp = 0;

    /// <summary>
    /// Link to player dmg buff UI
    /// </summary>
    public Slider dmgCount;
    /// <summary>
    /// Link to player spd buff UI
    /// </summary>
    public Slider spdCount;
    /// <summary>
    /// Link to player hp buff UI
    /// </summary>
    public Slider hpCount;

    /// <summary>
    /// Text to display current dmg buff amount
    /// </summary>
    public TextMeshProUGUI powerBuffText;
    /// <summary>
    /// Text to display current speed buff amount
    /// </summary>
    public TextMeshProUGUI speedBuffText;
    /// <summary>
    /// Text to display current hp buff amount
    /// </summary>
    public TextMeshProUGUI healthBuffText;

    /// <summary>
    /// Percentage increase by 50
    /// </summary>
    private int percentage1 = 50;
    /// <summary>
    /// Percentage increase by 25
    /// </summary>
    private int percentage2 = 25;

    /// <summary>
    /// When starting
    /// </summary>
    private void Awake()
    {
        // If there is NO BuffManager object running yet
        if (instance == null)
        {
            // Carry out this
            instance = this;
            // Set game object to DontDestroyOnLoad
            DontDestroyOnLoad(gameObject);
        }
        // If GameManager ALREADY exists
        else if (instance != null && instance != this)
        {
            // Destroy this current newly made game object
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Check buff type added
    /// </summary>
    /// <param name="buffType"> Type of buff </param>
    public void ShowBuff(string buffType)
    {
        // If buff type is health
        if (buffType == "health")
        {
            // Increase number of hp buffs by 1
            currentHp += 1;
            // Set slider buff value as currentHp
            hpCount.value = currentHp;
            // perc variable for percentage buff
            int perc = currentHp * percentage1;
            // Show percentage buff increase in Ui
            healthBuffText.text = "+ " + perc.ToString() + " %";
        }
        // If buff type is speed
        else if (buffType == "speed")
        {
            // Increase number of speed buffs by 1
            currentSpd += 1;
            // Set slider buff value as currentSpd
            spdCount.value = currentSpd;
            // perc variable for percentage buff
            int perc = currentSpd * percentage2;
            // Show percentage buff increase in Ui
            speedBuffText.text = "+ " + perc.ToString() + " %";
        }
        // If buff type is power
        else if (buffType == "power")
        {
            // Increase number of damage buffs by 1
            currentDmg += 1;
            // Set slider buff value as currentDmg
            dmgCount.value = currentDmg;
            // perc variable for percentage buff
            int perc = currentDmg * percentage1;
            // Show percentage buff increase in Ui
            powerBuffText.text = "+ " + perc.ToString() + " %";
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
