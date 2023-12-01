using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange;
    public int attackDamage;
    public float attackReady = 1;

    public UnityEvent CooldownChanged; 

    // Update is called once per frame
    void Update()
    {
        //attackReady += 

        if(attackReady == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                StartCoroutine(AttackCooldown()); 
            }
        }
        else if (attackReady > 1)
        {
            attackReady = 1;
        }
    }

    //attack
    //attackReady 1 --> 0 
    //attackReady += nummer 
    //if attackReady = 1 
    //attack

    void Attack(){
        //Attack animation här

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private IEnumerator AttackCooldown()
    {
        attackReady = 0;
        yield return new WaitForSeconds(1.0f);
        attackReady = 1;
    }

    public float remainingAttackCooldown
    {
        get
        {
            return attackReady; 
        }
    }
}
