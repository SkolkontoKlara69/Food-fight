using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    
    private HealthController healthController;
    

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invincibilitySeconds)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilitySeconds));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilitySeconds)
    {
        healthController.isInvincible = true;
        yield return new WaitForSeconds(invincibilitySeconds);
        healthController.isInvincible = false;
    }
}
