using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //=====ITEM DATA=====//
    public string itemName;
    public Sprite itemSprite;
    public Sprite emptySprite;
    public bool isFilled;
    public string itemDescription;
    public ItemType itemType;


    //=====ITEM SLOT=====//
    [SerializeField]
    private TMP_Text itemText;
    [SerializeField]
    private Image itemImage;

    //=====EQUIPED SLOTS======//
    [SerializeField]
    private EquippedSlot headSlot, swordSlot;

    private HatOnPlayer hattScript;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryScript inventoryScript;

    public void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
        //TouchInputModule.force;
        hattScript = GameObject.Find("Hatt").GetComponent<HatOnPlayer>();
    }

    public void AddItem(string itemName, string itemDescription, Sprite sprite, ItemType itemType)
    {
        this.itemName = itemName;
        this.itemSprite = sprite;
        this.itemDescription = itemDescription;
        this.itemType = itemType;

        isFilled = true;

        itemText.text = itemName;
        itemText.enabled = true;
        itemImage.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
        
   public void OnLeftClick() 
    {
        if (thisItemSelected)
        {
            EquipGear();
            hattScript.UppdateHatt();
        }

        else
        {
            inventoryScript.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
        
    }
    public void OnRightClick()
    {

    }

    private void EquipGear()
    {
        if(itemType == ItemType.head)
        {
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.sword)
        {
            swordSlot.EquipGear(itemSprite, itemName, itemDescription);
        }

        EmptySlot();
    }

    public void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        isFilled = false;
    }

    
}
