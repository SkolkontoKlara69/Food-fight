using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarRöd;

    [SerializeField]
    private float reduceSpeed = 2;
    private float target = 1;

    public void UpdateHealthBar(HealthController healthController)
    {
        target = healthController.remainingHealthPercentage;

        //healthBarRöd.fillAmount = Mathf.MoveTowards(healthBarRöd.fillAmount, healthController.remainingHealthPercentage, reduceSpeed * Time.deltaTime);

        //healthBarRöd.fillAmount = healthController.remainingHealthPercentage;
    }

    public void Update()
    {
        healthBarRöd.fillAmount = Mathf.MoveTowards(healthBarRöd.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
