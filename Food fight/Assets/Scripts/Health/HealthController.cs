using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    Vector2 startPos;

    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        if (currentHealth == 0)
        {
            transform.position = startPos;
            Respawn.Invoke();
            currentHealth = maximumHealth;
        }
    }

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    private float maximumHealth;

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public bool isInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent Respawn;

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
        }

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }

}
