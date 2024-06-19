using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerOld : MonoBehaviour
{
    // Variable to check if a GameManager object is alr running
    // Static makes it shared across all game objects of the same type
    public static GameManagerOld instance;

    // Text to display current jump buff amount
    public TextMeshProUGUI jumpBuffText;
    // Text to display current speed buff amount
    public TextMeshProUGUI speedBuffText;

    // Variable to indicate current buff count
    private int currentJump = 0;
    private int currentSpeed = 0;

    // Reference to UI interaction text
    public GameObject interactionText;

    private void Awake()
    {
        // If there is NO GameManager object running yet
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

    // Increases current player score
    // Parameter scoreToAdd: Amount of points to increase by
    public void ShowBuff(string buffType)
    {
        //Add displayed buff
        if (buffType == "jump")
        {
            currentJump += 1; 
            jumpBuffText.text = "Jump: " + currentJump.ToString();
        }
        else if (buffType == "speed")
        {
            currentSpeed += 1;
            speedBuffText.text = "Speed: " + currentSpeed.ToString();
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
