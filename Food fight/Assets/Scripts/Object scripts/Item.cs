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
        Debug.Log("aaaaaaaaaa");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bbbbbbb");
            inventoryScript.AddItem(itemName, sprite);
            Destroy(gameObject);
        }
    }
}
