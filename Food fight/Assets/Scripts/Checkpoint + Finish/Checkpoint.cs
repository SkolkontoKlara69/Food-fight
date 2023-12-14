using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    HealthController healthController;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    Collider2D coll;

    private void Awake()
    {
        healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthController.UpdateCheckpoint(transform.position);
            spriteRenderer.sprite = active;
            coll.enabled = false;
        }
    }
}
