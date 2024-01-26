using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //SLOT APPEARANCE//
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private TMP_Text slotName;

    [SerializeField]
    private Image playerDisplayImage;

    //SLOT DATA//
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private InventoryScript inventoryScript;
    private ItemSOLibrary itemSOLibrary;

    private void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
        itemSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<ItemSOLibrary>();
    }

    //OTHER VARIEBELS//
    private bool slotInUse;

    [SerializeField]
    public GameObject selectedShader;

    [SerializeField]
    public bool thisItemSelected;

    [SerializeField]
    private Sprite emptySprite;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click");
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

     public void OnLeftClick()
    {
        if (thisItemSelected && slotInUse)
            UnEquipGear();
        else
        {
            inventoryScript.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }
    void OnRightClick()
    {
        UnEquipGear();
    }

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        if (slotInUse)
        {
            UnEquipGear();
        }

        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        this.itemName = itemName;
        this.itemDescription = itemDescription;

        playerDisplayImage.sprite = itemSprite;

        for (int i = 0; i < itemSOLibrary.itemSO.Length; i++)
        {
            if (itemSOLibrary.itemSO[i].itemname == this.itemName)
            {
                itemSOLibrary.itemSO[i].EquipItem();
            }
        }
        slotInUse = true;
    }

    public void UnEquipGear()
    {
        inventoryScript.DeselectAllSlots();

        inventoryScript.AddItem(itemName, itemDescription, itemSprite, itemType);

        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;

        playerDisplayImage.sprite = emptySprite;

        for (int i = 0; i < itemSOLibrary.itemSO.Length; i++)
        {
            if (itemSOLibrary.itemSO[i].itemname == this.itemName)
                itemSOLibrary.itemSO[i].UnEquipItem();
        }
        slotInUse = false;
    }
}
