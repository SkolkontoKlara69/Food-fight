using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    HealthController healthController;

    SpriteRenderer spriteRenderer;    
    public Animator animator;
    Collider2D coll;

    private void Awake()
    {
        healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();      
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthController.UpdateCheckpoint(transform.position);
            animator.SetBool("PlayerHasTouched", true);
            coll.enabled = false;
        }
    }
}
