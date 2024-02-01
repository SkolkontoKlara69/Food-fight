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

    /*public void UpdateHealthBar(EnemyHealth enemyHealth)
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        currentHealth = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>().currentHealth;
        maxHealth = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>().maxHealth;
        target = currentHealth / maxHealth; 
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime); 
    }
}
