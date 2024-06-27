using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerCore : Collectible
{
    // When object is interacted
    public override void BuffTaken()
    {
        // Load the next game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
