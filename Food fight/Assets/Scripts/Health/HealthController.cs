using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    Vector2 startPos;

    SpriteRenderer spriteRenderer;

    public Transform playerYPosition;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    private float maximumHealth;
    public bool isInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent Respawn;

    public UnityEvent HealthChanged;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Start()
    {
        startPos = transform.position;
    }

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }
    public void Update()
    {
        if (currentHealth == 0)
        {
            Die();            
        }
        else
        {
            spriteRenderer.enabled = true;
        }

        if(playerYPosition.position.y < -20)
        {
            currentHealth = 0;
            HealthChanged.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible == true)
        {
            return;
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth != 0)
        {
            currentHealth -= damage;
            HealthChanged.Invoke();
            OnDamaged.Invoke();
        }
        else
        {
            OnDied.Invoke();
            //På playerns healthcontroller måste även attack-scriptet läggas in som en bool på OnDied, för att det ska stängas av när man dör. 
            //För ex. fiender ska det istället läggas in deras attacker och movement osv. 
        }

        return;
        
    }

    public void AddHealth(float addAmount)
    {
        if (currentHealth != maximumHealth)
        {
            currentHealth += addAmount;
            HealthChanged.Invoke();
        }

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }

    public void Die()
    {
        StartCoroutine(Respawned(0.5f));
    }

    IEnumerator Respawned(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        Respawn.Invoke();
        currentHealth = maximumHealth;
        HealthChanged.Invoke();
    }
}
