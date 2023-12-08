using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int health, defence, damage, speed;

    [SerializeField]
    private TMP_Text healthText, defenceText, damageText, speedText;

    // Start is called before the first frame update
    void Start()
    {
        UppdateStats();
    }

    public void UppdateStats()
    {
        healthText.text = health.ToString();
        defenceText.text = defence.ToString();
        damageText.text = damage.ToString();
        speedText.text = speed.ToString();
    }
}
