 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        }
    }


    public void AddItem(string itemName, Sprite itemSprite)
    {
        Debug.Log(itemName);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFilled == false)
            {
                itemSlot[i].AddItem(itemName,itemSprite);
                return;
            }
        }
        
    }
}
