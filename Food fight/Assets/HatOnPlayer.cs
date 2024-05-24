using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatOnPlayer : MonoBehaviour
{
    GameObject canvas;
    InventoryScript inventoryScript;
    // Start is called before the first frame 
    void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
