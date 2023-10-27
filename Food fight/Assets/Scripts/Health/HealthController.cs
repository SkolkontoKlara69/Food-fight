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
            //P� playerns healthcontroller m�ste �ven attack-scriptet l�ggas in som en bool p� OnDied, f�r att det ska st�ngas av n�r man d�r. 
            //F�r ex. fiender ska det ist�llet l�ggas in deras attacker och movement osv. 
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
