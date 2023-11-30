using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldown : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarCyan;

    public void UpdateAttackBar(PlayerAttack attackCooldown)
    {
        healthBarCyan.fillAmount = attackCooldown.remainingAttackCooldown;
    }
}
