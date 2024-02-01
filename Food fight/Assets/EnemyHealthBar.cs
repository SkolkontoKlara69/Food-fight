using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private float reduceSpeed = 1;
    public float target;

    public float currentHealth; 
    public float maxHealth;

    private EnemyHealth associatedEnemyHealth;

    void Start()
    {
        // Find the parent (enemy) of the health bar
        Transform enemyTransform = transform.parent;

        if (enemyTransform != null)
        {
            // Get the EnemyHealth component from the enemy
            associatedEnemyHealth = enemyTransform.GetComponentInChildren<EnemyHealth>();

            if (associatedEnemyHealth == null)
            {
                Debug.LogError("No EnemyHealth component found in children of the enemy.");
            }
        }
        else
        {
            Debug.LogError("EnemyHealthBar must be a child of an enemy object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (associatedEnemyHealth != null)
        {
            float target = associatedEnemyHealth.currentHealth / associatedEnemyHealth.maxHealth;
            healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
        }

        /*currentHealth = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>().currentHealth;
        maxHealth = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>().maxHealth;
        target = currentHealth / maxHealth; 
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime); */
    }
}
