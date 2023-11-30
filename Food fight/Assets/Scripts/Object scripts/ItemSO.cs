using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemname;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public void UseItem()
    {
        GameObject.Find("Player (2)").GetComponent<PlayerAttack>().attackDamage *= 2;
    }

    public enum StatToChange
    {
        none,
        health,
        stamina,
        damage
    };
}
