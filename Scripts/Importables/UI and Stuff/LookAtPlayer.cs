using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    /// <summary>
    /// Links player camera
    /// </summary>
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Late Update is called once per frame, AFTER Update function
    void LateUpdate()
    {
        // Face canvas object towards the player
        transform.LookAt(cam);
    }
}
