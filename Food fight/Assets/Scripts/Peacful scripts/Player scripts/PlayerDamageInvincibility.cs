using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvincibility : MonoBehaviour
{
    public float InvincibilitySeconds;

    private InvincibilityController invincibilityController;
    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(InvincibilitySeconds);
    }
}
