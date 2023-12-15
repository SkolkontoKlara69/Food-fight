using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        var healthController = collision.gameObject.GetComponent<HealthController>();

        if(healthController != null)
        {
            healthController.TakeDamage(damage);
        }
    } 
}
