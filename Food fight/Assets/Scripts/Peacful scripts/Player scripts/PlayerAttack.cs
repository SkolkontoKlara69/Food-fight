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
        if (attackReady == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                //StartCoroutine(AttackCooldown()); denna behövs inte längre
                attackReady = 0;
            }
        }
        else if (attackReady != 1)
        {
            Cooldown();
        }

        CooldownChanged.Invoke();
    }

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

    /*private IEnumerator AttackCooldown()
    {
        attackReady = 0;
        yield return new WaitForSeconds(0.5f); allt detta behövs inte längre
        attackReady = 1;
    }*/

    void Cooldown()
    {
        attackReady = Mathf.MoveTowards(attackReady, 1, 2 * Time.deltaTime);
    }

    public float remainingAttackCooldown
    {
        get
        {
            return attackReady; 
        }
    }
}
