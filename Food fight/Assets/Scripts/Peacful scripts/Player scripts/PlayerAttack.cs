using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange;
    public int attackDamage;
    public float attackReady = 1;

    private GameObject playerStatManager;

    public UnityEvent CooldownChanged;

    private PlayerInput playerInput;

    public AudioSource audioSource;
    public AudioClip hitSound;

    public Animator animator;

    private void Awake()
    {
        playerStatManager = GameObject.Find("PlayerStatManager");
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatManager != null)
        {
            attackDamage = playerStatManager.GetComponent<PlayerStats>().damage;
        }

        if (attackReady == 1)
        {
            if (playerInput.actions["Fire"].triggered)
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
        animator.SetTrigger("Hit");
        audioSource.clip = hitSound;
        audioSource.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy detected at position: " + enemy.transform.position); 
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
