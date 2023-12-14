using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    HealthController healthController;    

    private void Awake()
    {
        healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthController.UpdateCheckpoint(transform.position);
        }
    }
}
