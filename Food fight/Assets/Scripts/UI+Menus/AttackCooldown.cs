using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldown : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image cyan;

    public void UpdateAttackBar(PlayerAttack playerAttack)
    {
        cyan.fillAmount = playerAttack.remainingAttackCooldown; 
    }
}
