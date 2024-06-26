  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryScript : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject firstInventorySlot;
    //public EventSystem eventSystem;
    //public UnityEvent OnPause;
    private bool menuActivated;
    private bool initialPress;
    public ItemSlot[] itemSlot;
    public EquippedSlot[] equipedSlots;

    private PlayerInput playerInput;

    private void onload()
    { 
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("i") && menuActivated && !initialPress)
        { 
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1;
            initialPress = true;
        }
        else if (Input.GetKeyDown("i") && !menuActivated && !initialPress)
        {
            //eventSystem.firstSelectedGameObject = firstInventorySlot;
            InventoryMenu.SetActive(true);
            menuActivated = true;
            //OnPause.Invoke();
            //Time.timeScale = 0;
            initialPress = true;
            Debug.Log(Time.timeScale);
        }
        if (Input.GetKeyDown("i")) 
        {
            initialPress = false;
        }
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
