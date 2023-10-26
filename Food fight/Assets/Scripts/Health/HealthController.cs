using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
