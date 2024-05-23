using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{ 
    [SerializeField]
    public GameObject inventoryObject;

    public void Start()
    {
        
    }

    public void Update()
    {
        inventoryObject = GameObject.FindWithTag("Inventory");

        if (inventoryObject != null && inventoryObject.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
       
    } 
}
