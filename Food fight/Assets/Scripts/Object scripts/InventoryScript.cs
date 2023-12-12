 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public EquippedSlot[] equipedSlots;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1;
        }

        else if (Input.GetButton("Inventory") && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Time.timeScale = 0;
            WaitTime();
        }
    }

    public IEnumerable WaitTime()
    {
        yield return new WaitForSeconds(3f);
    }
    public void AddItem(string itemName, string itemDescription, Sprite itemSprite, ItemType itemType)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFilled == false)
            {
                itemSlot[i].AddItem(itemName, itemDescription, itemSprite, itemType);
                return;
            }
        }

    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].thisItemSelected = false;
            itemSlot[i].selectedShader.SetActive(false);
        }
        for (int i = 0; i < equipedSlots.Length; i++)
        {
            equipedSlots[i].thisItemSelected = false;
            equipedSlots[i].selectedShader.SetActive(false);
        }
    }
}
public enum ItemType
{
    none,
    head,
    sword,
};
