using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarR�d;

    [SerializeField]
    private float reduceSpeed = 2;
    private float target = 1;

    public void UpdateHealthBar(HealthController healthController)
    {
        target = healthController.remainingHealthPercentage;

        //healthBarR�d.fillAmount = Mathf.MoveTowards(healthBarR�d.fillAmount, healthController.remainingHealthPercentage, reduceSpeed * Time.deltaTime);

        //healthBarR�d.fillAmount = healthController.remainingHealthPercentage;
    }

    public void Update()
    {
        healthBarR�d.fillAmount = Mathf.MoveTowards(healthBarR�d.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
