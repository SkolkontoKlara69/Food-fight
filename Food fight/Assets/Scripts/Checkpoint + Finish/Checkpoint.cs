using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    HealthController healthController;

    SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource audioSource;
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
            Debug.Log("touched");
            healthController.UpdateCheckpoint(transform.position);
            animator.SetBool("PlayerHasTouched", true);
            audioSource.Play();
            coll.enabled = false;
        }
    }
}
