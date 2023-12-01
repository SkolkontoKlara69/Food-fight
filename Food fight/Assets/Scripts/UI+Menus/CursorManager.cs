using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public void OnGui()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /* Later, when everything is adapted to not using mouse
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    } */
}
