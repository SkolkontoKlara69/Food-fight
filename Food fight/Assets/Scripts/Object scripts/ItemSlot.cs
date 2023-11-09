using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{

    public string itemName;
    public Sprite itemSprite;
    public bool isFilled;

    [SerializeField]
    private TMP_Text itemText;

    [SerializeField]
    private Image itemImage;

    public void AddItem(string itemName,Sprite sprite)
    {
        this.itemName = itemName;
        this.itemSprite = sprite;
        isFilled = true;

        itemText.text = itemName;
        itemText.enabled = true;
        itemImage.sprite = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
