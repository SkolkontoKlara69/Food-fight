using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemname;
    public int damage, health, speed, defence;


    public void EquipItem()
    {
        PlayerStats playerStats = GameObject.Find("PlayerStatManager").GetComponent<PlayerStats>();
        playerStats.damage += damage;
        playerStats.health += health;
        playerStats.speed += speed;
        playerStats.defence += defence;

        playerStats.UppdateStats();
    }
    public void UnEquipItem()
    {
        PlayerStats playerStats = GameObject.Find("PlayerStatManager").GetComponent<PlayerStats>();
        playerStats.damage -= damage;
        playerStats.health -= health;
        playerStats.speed -= speed;
        playerStats.defence -= defence;

        playerStats.UppdateStats();
    }

}
