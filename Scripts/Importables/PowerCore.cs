using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerCore : Collectible
{
    /// <summary>
    /// Reference the transition animation
    /// </summary>
    public Animator transition;

    // When object is interacted
    public override void BuffTaken()
    {
        // Carry out load next function
        LoadNext();
    }

    /// <summary>
    /// Function to play animation and load scene
    /// </summary>
    public void LoadNext()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Start animation
        transition.SetTrigger("End");
        // Wait for 1 seconds
        yield return new WaitForSeconds(1f);
        // Load new scene
        SceneManager.LoadScene(levelIndex);
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
