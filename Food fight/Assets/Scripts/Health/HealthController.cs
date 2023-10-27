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

    public UnityEvent OnDied;

    public void TakeDamage(float damage)
    {
        if (currentHealth != 0)
        {
            currentHealth -= damage;
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
