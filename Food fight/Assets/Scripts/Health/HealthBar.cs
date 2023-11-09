using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarRöd;
    void UpdateHealthBar(HealthController healthController)
    {
        healthBarRöd.fillAmount = healthController.remainingHealthPercentage;
    }
}
