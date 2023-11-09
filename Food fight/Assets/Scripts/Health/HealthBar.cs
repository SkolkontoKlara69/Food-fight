using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarR�d;
    public void UpdateHealthBar(HealthController healthController)
    {
        healthBarR�d.fillAmount = healthController.remainingHealthPercentage;
    }
}
