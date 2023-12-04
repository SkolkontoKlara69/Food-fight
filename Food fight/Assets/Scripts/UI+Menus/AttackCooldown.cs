using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldown : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image cyan;

    [SerializeField]
    private float reduceSpeed = 2;
    private float target = 1;

    //m�ste p� n�t s�tt fixa s� att cooldown baren inte g�r ner space trycks p� n�r attacken inte �r reda

    public void UpdateAttackBar(PlayerAttack playerAttack)
    {
        target = playerAttack.remainingAttackCooldown;

        //cyan.fillAmount = Mathf.MoveTowards(cyan.fillAmount, playerAttack.remainingAttackCooldown, reduceSpeed * Time.deltaTime); 

        //cyan.fillAmount = playerAttack.remainingAttackCooldown; 
    }

    public void Update()
    {
        cyan.fillAmount = Mathf.MoveTowards(cyan.fillAmount, target, reduceSpeed * Time.deltaTime); 
    }
}
