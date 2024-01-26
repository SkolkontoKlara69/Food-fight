using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private float target = 1;

    public void UpdateHealthBar(EnemyHealth enemyHealth)
    {
        target = enemyHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
