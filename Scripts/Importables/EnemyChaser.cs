using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : MonoBehaviour
{
    public NavMeshAgent enemyChase;
    public GameObject player;
    public PlayerHP hpScript;
    public GameObject enemy;

    private bool detected = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detected = true;
        }
        else
        {
            Debug.Log("Player not detected");
        }
    }

    /// <summary>
    /// While in contact with enemy objects
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
        Debug.Log(detected);
        if (detected == true)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            enemyChase.SetDestination(player.transform.position);
        }
        else
        {
            enemyChase.SetDestination(enemy.transform.position);
        }
    }
}
