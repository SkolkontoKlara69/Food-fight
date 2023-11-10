using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    SpriteRenderer spriteRenderer;
    public Transform enemyYPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)       
            Die();        
    }

    public void Update()
    {        
        if (enemyYPosition.position.y < -20)        
            Die();        
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Die()
    {        
        GetComponent<AI_walking>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(Despawn(0.5f));
    }

    IEnumerator Despawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);        
    }
}
