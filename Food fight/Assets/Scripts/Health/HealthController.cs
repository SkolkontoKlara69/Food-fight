using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    Vector2 checkPointPos;

    SpriteRenderer spriteRenderer;

    public Transform playerYPosition;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    private float maximumHealth;
    public bool isInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent Respawn;

    public UnityEvent HealthChanged;

    private GameObject playerStatManager;

    private float defence = 0f;

    public int voidDepth;

    public GameObject damageCanvas;

    [SerializeField]
    private float flashDuration;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(GameObject.Find("PlayerStatManager") != null)
        {
            playerStatManager = GameObject.Find("PlayerStatManager");
        }
    }
    public void Start()
    {
        checkPointPos = transform.position;        
    }

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public void Update()
    {
        if (currentHealth <= 0)        
            Die();                    

        if(playerYPosition.position.y < voidDepth)
        {
            currentHealth = 0;
            HealthChanged.Invoke();
        }
        
        if (playerStatManager != null)
        {
            defence = playerStatManager.GetComponent<PlayerStats>().defence;
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible == true)        
            return;        

        if (currentHealth < 0)        
            currentHealth = 0;       

        if (currentHealth != 0)
        {
            currentHealth -= (damage - defence);
            HealthChanged.Invoke();
            OnDamaged.Invoke();
            StartCoroutine(DamageScreen(flashDuration));
        }
        else
        {
            OnDied.Invoke();
            //P� playerns healthcontroller m�ste �ven attack-scriptet l�ggas in som en bool p� OnDied, f�r att det ska st�ngas av n�r man d�r. 
            //F�r ex. fiender ska det ist�llet l�ggas in deras attacker och movement osv. 
        }

        return;   
    }

    public void AddHealth(float addAmount)
    {
        if (currentHealth != maximumHealth)
        {
            currentHealth += addAmount;
            HealthChanged.Invoke();
        }

        if (currentHealth > maximumHealth)        
            currentHealth = maximumHealth;        
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkPointPos = pos;
    }
    public void Die()
    {
        StartCoroutine(Respawned(0.5f));
    }   


    IEnumerator Respawned(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        spriteRenderer.enabled = true;        
        currentHealth = maximumHealth;
        HealthChanged.Invoke();
    }

    IEnumerator DamageScreen(float flashDuration)
    {
        damageCanvas.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        damageCanvas.SetActive(false);
    }
}
