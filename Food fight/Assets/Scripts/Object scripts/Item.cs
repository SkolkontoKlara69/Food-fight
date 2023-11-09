using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    private InventoryScript inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryScript.AddItem(itemName, sprite);
            Destroy(gameObject);
        }
    }
}
