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


    //=====ITEM SLOT=====//
    [SerializeField]
    private TMP_Text itemText;
    [SerializeField]
    private Image itemImage;


    //=====ITEM DESCRIPTION SLOT=====//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemDescriptionNameText;


    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryScript inventoryScript;

    public void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
    }

    public void AddItem(string itemName, string itemDescription, Sprite sprite)
    {
        this.itemName = itemName;
        this.itemSprite = sprite;
        this.itemDescription = itemDescription;

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
            inventoryScript.UseItem(itemName);
            EmptySlot();
        }

        else
        {
            inventoryScript.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
        }
        
    }
    public void OnRightClick()
    {

    }

    public void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }
}
