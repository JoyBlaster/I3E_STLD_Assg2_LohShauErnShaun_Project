using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    // Code gets audio from Unity project itself.
    // Cannot use AudioSource due to object deleting itself
    [SerializeField]
    private AudioClip openAudio;

    // Chooses object to spawn
    [SerializeField]
    private GameObject collectibleToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnCollectible();
            Destroy(gameObject);
        }
    }

    // Spawn object function
    void SpawnCollectible()
    {
        // Start playing audio here (will not be interrupted by GameObject deletion)
        // (Which audio variable to play, location to play audio, volume)
        AudioSource.PlayClipAtPoint(openAudio,transform.position, 1f);
        //Spawn object (object to spawn, position to spawn at, rotation of object)
        Instantiate(collectibleToSpawn, transform.position,collectibleToSpawn.transform.rotation);
    }
}
