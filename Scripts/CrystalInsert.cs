/*
 * Author: Loh Shau Ern Shaun
 * Date: 30/06/2024
 * Description: 
 * Inserting crystal into the spaceship and triggering the end cutscene.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalInsert : Collectible
{
    /// <summary>
    /// Reference the transition animation
    /// </summary>
    public Animator transition;

    /// <summary>
    /// Audio for placing crystals
    /// </summary>
    public AudioSource yippee;

    /// <summary>
    /// Reference to crystal cores
    /// </summary>
    public GameObject crystalCores;

    /// <summary>
    /// When BuffTaken is done
    /// </summary>
    public override void BuffTaken()
    {
        // Carry out InsertCrystals function
        InsertCrystals();
    }

    /// <summary>
    /// When crystalas are inserted
    /// </summary>
    void InsertCrystals()
    {
        // Show the power cores
        crystalCores.SetActive(true);
        // Play yippee sfx
        yippee.Play();
        // Load animation
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /// <summary>
    /// Load scene
    /// </summary>
    /// <param name="levelIndex"> current scene index </param>
    /// <returns></returns>
    IEnumerator LoadLevel(int levelIndex)
    {
        // Start animation
        transition.SetTrigger("End");
        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);
        // Load new scene
        SceneManager.LoadScene(levelIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide the power cores
        crystalCores.SetActive(false);
    }
}
