using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    [SerializeField]
    private float currentHealth;

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

    public void TakeDamage(float damage)
    {
        if (isInvincible == true)
        {
            return;
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

        if (currentHealth < 0)
        {
            currentHealth = 0;
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
